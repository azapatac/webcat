using Presentation.Models.Navigation;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;
using NavigationViewBackRequestedEventArgs = Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs;
using NavigationViewItemInvokedEventArgs = Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs;

namespace Presentation
{
    public sealed partial class Shell : UserControl
    {
        private readonly IReadOnlyCollection<NavigationItem> NavigationItems;

        public Shell()
        {
            this.InitializeComponent();

            NavigationItems = new[]
            {
                new NavigationItem(TreeItem, typeof(TreePage)),
                new NavigationItem(CanvasItem, typeof(CanvasPage)),
            };

            // Set the custom title bar to act as a draggable region
            Window.Current.SetTitleBar(TitleBarBorder);
        }

        // Navigates to a sample page when a button is clicked
        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (NavigationItems.FirstOrDefault(item => item.Item == args.InvokedItemContainer)?.PageType is Type pageType)
            {
                NavigationFrame.Navigate(pageType);
            }
        }

        // Sets whether or not the back button is enabled
        private void NavigationFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            NavigationView.IsBackEnabled = ((Frame)sender).BackStackDepth > 0;
        }

        // Navigates back
        private void NavigationView_OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (NavigationFrame.BackStack.LastOrDefault() is PageStackEntry entry)
            {
                NavigationView.SelectedItem = NavigationItems.First(item => item.PageType == entry.SourcePageType).Item;
                NavigationFrame.GoBack();
            }
        }

        // Select the introduction item when the shell is loaded
        private void Shell_OnLoaded(object sender, RoutedEventArgs e)
        {
            NavigationView.SelectedItem = TreeItem;
            NavigationFrame.Navigate(typeof(TreePage));
        }
    }
}