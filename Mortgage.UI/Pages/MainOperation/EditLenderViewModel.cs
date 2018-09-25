using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.UI.Pages.MainOperation
{
    using System.ComponentModel;
    using MVVMC;
    using ReactiveUI;
    using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
    using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

    public class EditLenderViewModel : MVVMCViewModel, IReactiveObject
    {
        public override void Initialize()
        {
            Id = ViewBag["Id"] is Guid guid ? guid : default;
        }

        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { this.RaiseAndSetIfChanged(ref _id, value); }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        void IReactiveObject.RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            var handler = this.PropertyChanging;
            handler?.Invoke(this, args);
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        void IReactiveObject.RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = this.PropertyChanged;
            handler?.Invoke(this, args);
        }
    }
}
