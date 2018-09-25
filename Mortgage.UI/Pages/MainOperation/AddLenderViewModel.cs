using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.UI.Pages.MainOperation
{
    using System.ComponentModel;
    using System.Windows.Input;
    using Domain.Lenders;
    using Domain.Services;
    using MVVMC;
    using ReactiveUI;
    using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
    using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

    public class AddLenderViewModel : MVVMCViewModel<MainOperationController>, IReactiveObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
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
