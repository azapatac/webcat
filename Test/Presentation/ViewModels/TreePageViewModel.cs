using CommunityToolkit.Mvvm.ComponentModel;
using Presentation.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Presentation.ViewModels
{
    public class TreePageViewModel : ObservableObject
    {
        public ICollection<TreeItem> Items { get; set; }
        public TreePageViewModel()
        {
            Items = new ObservableCollection<TreeItem>();

            for (int i = 1; i <= 10; i++)
            {
                var folders = new TreeItem() { Name = $"Folder {i}" };
                for (int j = 1; j <= 20; j++)
                {
                    var item = new TreeItem() { Name = $"Item {j}" , Icon = "Assets/StoreLogo.png" };
                    folders.Children.Add(item);
                }
                Items.Add(folders);
            }
        }
    }
}