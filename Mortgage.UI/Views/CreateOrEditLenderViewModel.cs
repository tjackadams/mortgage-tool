using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.UI.Views
{
    using ReactiveUI;

    public class CreateOrEditLenderViewModel : ReactiveObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }
    }
}
