using Presentation.Enumerations;
using Presentation.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Presentation.Templates
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FolderTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var explorerItem = (ItemViewModel)item;
            if (explorerItem.Type == ItemType.Folder) return FolderTemplate;

            return FileTemplate;
        }
    }
}