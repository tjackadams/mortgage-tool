namespace Mortgage.UI.Pages.MainOperation
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using Common.Threading;
    using Domain.Infrastructure;
    using Domain.Infrastructure.Extensions;
    using DynamicData;
    using DynamicData.Binding;
    using Microsoft.EntityFrameworkCore;
    using MVVMC;
    using ReactiveUI;
    using Views;
    using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
    using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

    public class SearchViewModel : MVVMCViewModel<MainOperationController>, IReactiveObject, IDisposable
    {
        private bool _acceptSelfEmployment;
        private bool _isBusy;

        private List<ComboBoxLenderName> _lenderNames;

        private List<ComboBoxMortgageType> _mortgageTypes;

        private SourceList<LendersView> _rootList;

        private Guid _selectedLender;

        private int _selectMortgageType;

        private decimal _selfEmploymentMinimumIncome;

        private int _selfEmploymentYearsBooks;

        private decimal _purchasePrice;

        public decimal PurchasePrice
        {
            get => _purchasePrice;
            set => this.RaiseAndSetIfChanged(ref _purchasePrice, value);
        }

        private decimal _loanAmount;

        public decimal LoanAmount
        {
            get => _loanAmount;
            set => this.RaiseAndSetIfChanged(ref _loanAmount, value);
        }

        private decimal _loanToValue;

        public decimal LoanToValue
        {
            get => _loanToValue;
            set => this.RaiseAndSetIfChanged(ref _loanToValue, value);
        }

        public SearchViewModel()
        {
            IsBusy = true;
            _rootList = new SourceList<LendersView>();

            this.WhenAnyValue(x => x.PurchasePrice)
                .Throttle(TimeSpan.FromMilliseconds(200))
                .Subscribe(x =>
                {
                    if (PurchasePrice == default)
                    {
                        return;
                    }

                    if (this.LoanAmount == default)
                    {
                        LoanToValue = 0;
                    }

                    LoanToValue = (LoanAmount / PurchasePrice) * 100;
                });

            this.WhenAnyValue(x => x.LoanAmount)
                .Throttle(TimeSpan.FromMilliseconds(200))
                .Subscribe(x =>
                {
                    if (LoanAmount == default) return; 
                    if (this.PurchasePrice == default)
                    {
                        LoanToValue = 0;
                    }

                    LoanToValue = (LoanAmount / PurchasePrice) * 100;
                });

            this.WhenAnyValue(x => x.LoanToValue)
                .Throttle(TimeSpan.FromMilliseconds(200))
                .Subscribe(x =>
                {
                    if (LoanToValue == default) return;
                    if (this.PurchasePrice == default)
                    {
                        LoanAmount = 0;
                    }

                    LoanAmount = (LoanToValue / 100) * PurchasePrice;
                });



            var selectedLenderFilter = this.WhenValueChanged(x => x.SelectedLender)
                .Select(SelectedLenderPredicate);

            var acceptSelfEmploymentFilter = this.WhenValueChanged(x => x.AcceptSelfEmployment)
                .Select(AcceptSelfEmploymentPredicate);

            var loader =_rootList
                .Connect()     
                .Filter(selectedLenderFilter)
                .Filter(acceptSelfEmploymentFilter)
                .ObserveOnDispatcher()
                .Bind(out _lenders)
                .Subscribe();

            Task.Run(InitializeAsync).ContinueWith(res => _rootList.AddRange(res.Result));
            _cleanUp = new CompositeDisposable(loader);
        }

        private Func<LendersView, bool> AcceptSelfEmploymentPredicate(bool accept)
        {
            return lender => lender.SelfEmployment == accept;
        }

        private Func<LendersView, bool> SelectedLenderPredicate(Guid selectedLender)
        {
            if (selectedLender == Guid.Empty)
            {
                return lender => true;
            }

            return lender => lender.Id == selectedLender;
        }

        public bool AcceptSelfEmployment
        {
            get => _acceptSelfEmployment;
            set
            {
                if (!value)
                {
                    SelfEmploymentMinimumIncome = default;
                    SelfEmploymentYearsBooks = default;
                }

                this.RaiseAndSetIfChanged(ref _acceptSelfEmployment, value);
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }

        public List<ComboBoxLenderName> LenderNames
        {
            get => _lenderNames;
            set => this.RaiseAndSetIfChanged(ref _lenderNames, value);
        }

        private ReadOnlyObservableCollection<LendersView> _lenders;

        public ReadOnlyObservableCollection<LendersView> Lenders
        {
            get => _lenders;
            set => this.RaiseAndSetIfChanged(ref _lenders, value);
        }


        public List<ComboBoxMortgageType> MortgageTypes
        {
            get => _mortgageTypes;
            set => this.RaiseAndSetIfChanged(ref _mortgageTypes, value);
        }

        public Guid SelectedLender
        {
            get => _selectedLender;
            set => this.RaiseAndSetIfChanged(ref _selectedLender, value);
        }

        public int SelectedMortgageType
        {
            get => _selectMortgageType;
            set => this.RaiseAndSetIfChanged(ref _selectMortgageType, value);
        }

        public decimal SelfEmploymentMinimumIncome
        {
            get => _selfEmploymentMinimumIncome;
            set => this.RaiseAndSetIfChanged(ref _selfEmploymentMinimumIncome, value);
        }

        public int SelfEmploymentYearsBooks
        {
            get => _selfEmploymentYearsBooks;
            set => this.RaiseAndSetIfChanged(ref _selfEmploymentYearsBooks, value);
        }

        public event PropertyChangingEventHandler PropertyChanging;

        void IReactiveObject.RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            var handler = PropertyChanging;
            handler?.Invoke(this, args);
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        void IReactiveObject.RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, args);
        }

        public async Task<List<LendersView>> InitializeAsync()
        {
            try
            {
                _mortgageTypes = default(MortgageType)
                    .ToDictionary()
                    .Select(mt => new ComboBoxMortgageType(mt.Key, mt.Value))
                    .ToList();

                using (var db = new MortgageDbContext())
                {
                    LenderNames =
                        await (from l in db.Lenders
                               select new ComboBoxLenderName(l.Id, l.Name)
                            ).ToListAsync();

                    LenderNames.Insert(0, new ComboBoxLenderName(Guid.Empty, "None"));

                    return await (from l in db.Lenders
                                            select new LendersView
                                            {
                                                Citizenship = l.Citizenship.GetDescription(),
                                                CriteriaUrl = l.CriteriaUrl,
                                                Id = l.Id,
                                                FirstTimeBuyer = l.FirstTimeBuyer,
                                                MaximumAge = l.MaximumAge,
                                                MinimumIncome = l.MinimumIncome,
                                                Name = l.Name,
                                                NewBuilds = l.NewProperty.AcceptBuyToLet || l.NewProperty.AcceptResidential,
                                                PrimaryContact = l.PrimaryContactInformation.ToString(),
                                                RatesUrl = l.RatesUrl,
                                                SecondaryContact = l.SecondaryContactInformation.ToString(),
                                                SelfEmployment = l.SelfEmployment.Accept,
                                                SelfEmploymentMinimumIncome = l.SelfEmployment.MinimumIncome,
                                                SelfEmploymentYearsBooks = l.SelfEmployment.YearsBooks
                                            }).ToListAsync();
                }

                //this.ObservableForProperty(x => x.SelectedLender)
                //    .Subscribe(_ => { Lenders = _rootList.CreateDerivedCollection(x => x, x => SelectedLender == Guid.Empty || x.Id == SelectedLender); });

                //this.WhenAnyValue(x => x.AcceptSelfEmployment, x => x.SelfEmploymentMinimumIncome, x => x.SelfEmploymentYearsBooks)
                //    .Subscribe(_ =>
                //    {
                //        Lenders = _rootList.CreateDerivedCollection(x => x,
                //            x => (!AcceptSelfEmployment || x.SelfEmployment == AcceptSelfEmployment) &&
                //                (SelfEmploymentMinimumIncome == default || x.SelfEmploymentMinimumIncome >= SelfEmploymentMinimumIncome) &&
                //                (SelfEmploymentYearsBooks == default || x.SelfEmploymentYearsBooks >= SelfEmploymentYearsBooks));
                //    });
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void Dispose()
        {
            _cleanUp.Dispose();
        }

        private readonly IDisposable _cleanUp;
    }
}