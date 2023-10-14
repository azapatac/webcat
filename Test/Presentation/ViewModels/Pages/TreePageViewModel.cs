using CommunityToolkit.Mvvm.ComponentModel;
using Presentation.Enumerations;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Presentation.ViewModels
{
    public class TreePageViewModel : ObservableObject
    {
        public ICollection<ItemViewModel> Items { get; set; }
        public TreePageViewModel()
        {
            Items = GetData();
        }

        private ObservableCollection<ItemViewModel> GetData()
        {
            var items = new ObservableCollection<ItemViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                var folders = new ItemViewModel() { Name = $"Folder {i}" };
                for (int j = 1; j <= 20; j++)
                {
                    var item = new ItemViewModel() { Name = $"Item_{j}.txt", Type = ItemType.File };
                    folders.Children.Add(item);
                }
                items.Add(folders);
            }

            return items;
        }
    }
}