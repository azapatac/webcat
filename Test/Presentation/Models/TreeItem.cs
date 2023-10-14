using System.Collections.ObjectModel;

namespace Presentation.Models
{
    public class TreeItem
    {
        public ObservableCollection<TreeItem> Children { get; set; } = new ObservableCollection<TreeItem>();
        public string Icon { get; set; }
        public bool IsExpanded { get; set; }
        public string Name { get; set; }
    }
}
