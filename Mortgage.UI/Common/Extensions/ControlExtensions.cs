namespace Mortgage.UI.Common.Extensions
{
    using System.Windows;

    public static class ControlExtensions
    {
        public static readonly DependencyProperty IsVisibleProperty = 
            DependencyProperty.RegisterAttached("IsVisible", typeof(bool), 
                typeof(ControlExtensions), new PropertyMetadata(true));

        public static void SetIsVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsVisibleProperty, value);
        }

        public static bool GetIsVisible(DependencyObject obj)
        {
            return (bool) obj.GetValue(IsVisibleProperty);
        }
    }
}
