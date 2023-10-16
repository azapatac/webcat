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

        private void MyCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            context.PointerMoved(e);
        }
    }
}