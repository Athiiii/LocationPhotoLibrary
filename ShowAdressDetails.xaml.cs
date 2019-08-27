using System.Windows;

namespace LocationPhotoLibrary
{
    /// <summary>
    /// Interaction logic for ShowAdressDetails.xaml
    /// </summary>
    public partial class ShowAdressDetails : Window
    {
        private AdressSet _adress;
        private OwnerSet _owner;
        private OwnerDetails _window;
        public ShowAdressDetails(OwnerSet owner, AdressSet adress, OwnerDetails window)
        {
            _adress = adress;
            _owner = owner;
            _window = window;

            InitializeComponent();
        }

        public void LoadPhotos()
        {

        }
    }
}
