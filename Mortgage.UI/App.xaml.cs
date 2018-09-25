using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Mortgage.UI
{
    using System.IO;
    using System.Threading;
    using Domain.Infrastructure;
    using Domain.Infrastructure.Utilities;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            EnsureAppData();
            StartupConfiguration.Migrate();
            ConfigureCulture();

            base.OnStartup(e);
        }

        private void ConfigureCulture()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
        }

        private void EnsureAppData()
        {
            if (!Directory.Exists("App_Data"))
            {
                Directory.CreateDirectory("App_Data");
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
