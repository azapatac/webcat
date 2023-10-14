using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;

namespace Presentation
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (Window.Current.Content is null)
            {
                Window.Current.Content = new Shell();

                Ioc.Default.ConfigureServices(
                    new ServiceCollection()
                    .BuildServiceProvider());
            }

            if (e.PrelaunchActivated == false)
            {
                CoreApplication.EnablePrelaunch(true);
                Window.Current.Activate();
            }
        }
    }
}
