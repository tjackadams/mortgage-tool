using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.UI.Views
{
    using System.Diagnostics;
    using System.Windows.Input;
    using Utilities;

    public class LendersView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrimaryContact { get; set; }
        public string SecondaryContact { get; set; }
        public string CriteriaUrl { get; set; }
        public string RatesUrl { get; set; }
        public string Citizenship { get; set; }
        public bool NewBuilds { get; set; }
        public decimal MinimumIncome { get; set; }
        public int MaximumAge { get; set; }
        public bool FirstTimeBuyer { get; set; }
        public bool SelfEmployment { get; set; }
        public decimal SelfEmploymentMinimumIncome { get; set; }
        public int SelfEmploymentYearsBooks { get; set; }

        private CommandImplementation<object> _navigateCriteriaUrlCommand;
        public ICommand NavigateCriteriaUrlCommand        {

            get
            {
                if (_navigateCriteriaUrlCommand == null)
                {
                    _navigateCriteriaUrlCommand = new CommandImplementation<object>(OpenUrl, _ => !string.IsNullOrEmpty(CriteriaUrl));
                }

                return _navigateCriteriaUrlCommand;
            }
        }

        private CommandImplementation<object> _navigateRatesUrlCommand;
        public ICommand NavigateRatesUrlCommand        {

            get
            {
                if (_navigateRatesUrlCommand == null)
                {
                    _navigateRatesUrlCommand = new CommandImplementation<object>(OpenUrl, _ => !string.IsNullOrEmpty(RatesUrl));
                }

                return _navigateRatesUrlCommand;
            }
        }

        private void OpenUrl(object url)
        {
            Process.Start(url as string);
        }
    }
}
