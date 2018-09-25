using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.UI.Views
{
    using System.ComponentModel;

    public enum MortgageType
    {
        [Description("Standard Residential")]
        StandardResidential,
        [Description("Buy to Let")]
        BuyToLet,
        [Description("Holiday Let")]
        HolidayLet,
        [Description("Self Build")]
        SelfBuild,
        [Description("HMO")]
        HousesInMultipleOccupation,
        [Description("Portfolio")]
        Portfolio
    }
}
