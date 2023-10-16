using System;
using Microsoft.UI.Xaml.Controls;

namespace Presentation.Models.Navigation
{
    public sealed class NavigationItem
    {
        public NavigationItem(NavigationViewItem viewItem, Type pageType)
        {
            Item = viewItem;
            PageType = pageType;
        }

        public NavigationViewItem Item { get; }

        public Type PageType { get; }
    }
}