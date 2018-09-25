namespace Mortgage.UI.Pages.MainOperation
{
    using System;
    using System.Collections.Generic;
    using MVVMC;

    public class MainOperationController : Controller
    {
        public override void Initial() => ExecuteNavigation();
        public void Search() => ExecuteNavigation();
        public void AddLender() => ExecuteNavigation();
        public void EditLender(object parameter)
        {
            var viewBag = new Dictionary<string, object>();
            var id = parameter is Guid guid ? guid : default;
            viewBag.Add("Id", id);
            ExecuteNavigation(parameter,viewBag);
        }

        public void ViewLenders() => ExecuteNavigation();
    }
}
