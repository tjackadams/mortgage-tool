namespace Mortgage.UI.Pages.MainOperation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;
    using Domain.Infrastructure;
    using MVVMC;
    using ReactiveUI;
    using Views;
    using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
    using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

    public class ViewLendersViewModel : MVVMCViewModel<MainOperationController>, IReactiveObject
    {
        public ViewLendersViewModel()
        {
            using (var db = new MortgageDbContext())
            {
                LenderNames = (from l in db.Lenders
                        select new ComboBoxLenderName(l.Id, l.Name)
                    ).ToList();

                LenderNames.Insert(0, ComboBoxLenderName.None());
            }
        }
        private Guid _selectedLender;

        public List<ComboBoxLenderName> LenderNames { get; set; }

        public Guid SelectedLender
        {
            get { return _selectedLender; }
            set { this.RaiseAndSetIfChanged(ref _selectedLender, value); }
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
    }
}