using Presentation.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Presentation.Views
{
    public sealed partial class CanvasPage : Page
    {
        readonly CanvasPageViewModel context;
        public CanvasPage()
        {
            InitializeComponent();
            context = DataContext as CanvasPageViewModel;
        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            context.PointerPressed(sender, e);
        }

        private void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            context.PointerMoved(sender, e);  
        }

        private void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            context.PointerReleased(sender, e);
        }
    }
}