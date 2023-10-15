using Presentation.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Presentation.Views
{
    public sealed partial class CanvasPage : Page
    {
        readonly CanvasPageViewModel vm;
        public CanvasPage()
        {
            InitializeComponent();
            vm = DataContext as CanvasPageViewModel;
        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            vm.Canvas_PointerPressed(sender, e);
        }

        private void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            vm.Canvas_PointerMoved(sender, e);  
        }

        private void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            vm.Canvas_PointerReleased(sender, e);
        }
    }
}