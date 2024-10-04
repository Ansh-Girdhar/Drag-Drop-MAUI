using DragandDrop.Models;
using System.Collections.ObjectModel;

namespace DragandDrop
{
    public partial class MainPage : ContentPage
    {
        // ObservableCollection to hold file attachments
        public ObservableCollection<FileAttachment> FilePaths { get; set; }

        public MainPage()
        {
            InitializeComponent();
            // Initialize the collection
            FilePaths = new ObservableCollection<FileAttachment>();
            // Bind the collection to the view
            BindingContext = this;
        }

        // Method to handle dropped files
        private void OnFilesDropped(IList<FileAttachment> attachments)
        {
            foreach (var attachment in attachments)
            {
                // Add each attachment to the ObservableCollection
                FilePaths.Add(attachment);
            }
        }

        // Loaded event handler to register the drop zone
        private void ContentPage_Loaded(object sender, EventArgs e)
        {
#if WINDOWS
            if (DropZone?.Handler?.PlatformView is Microsoft.UI.Xaml.UIElement nativeView)
                Platforms.Windows.DragDropHelper.RegisterDrop(nativeView, OnFilesDropped);
#endif
        }
    }
}
