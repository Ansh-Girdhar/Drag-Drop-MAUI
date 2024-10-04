#if WINDOWS
using DragandDrop.Models;
using Microsoft.UI.Xaml;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace DragandDrop.Platforms.Windows
{
    internal class DragDropHelper
    {
        public static void RegisterDrop(UIElement element, Action<IList<FileAttachment>> onFilesDropped)
        {
            element.Drop += async (s, e) =>
            {
                if (e.DataView.Contains(StandardDataFormats.StorageItems))
                {
                    var items = await e.DataView.GetStorageItemsAsync();
                    var attachments = new List<FileAttachment>();
                    foreach (var item in items)
                    {
                        if (item is StorageFile file)
                            attachments.Add(new FileAttachment(file.Name, file.Path));
                    }

                    if (attachments.Count > 0)
                    {
                        onFilesDropped?.Invoke(attachments);
                    }
                }
            };
        }
    }
}
#endif