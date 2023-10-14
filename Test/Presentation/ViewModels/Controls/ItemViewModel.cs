using CommunityToolkit.Mvvm.ComponentModel;
using Presentation.Enumerations;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Presentation.ViewModels
{
    public class ItemViewModel : ObservableObject
    {
        public ICollection<ItemViewModel> Children { get; set; } = new ObservableCollection<ItemViewModel>();
        public bool IsExpanded { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
    }
}