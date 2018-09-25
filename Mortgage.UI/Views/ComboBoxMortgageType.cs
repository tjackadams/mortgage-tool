using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.UI.Views
{
    public class ComboBoxMortgageType
    {
        public ComboBoxMortgageType(int id, string mortgageType)
        {
            Id = id;
            MortgageType = mortgageType;
        }

        public int Id { get; private set; }
        public string MortgageType { get; private set; }
    }
}
