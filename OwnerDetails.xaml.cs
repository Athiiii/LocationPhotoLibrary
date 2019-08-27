using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LocationPhotoLibrary
{
    /// <summary>
    /// Interaction logic for OwnerDetails.xaml
    /// </summary>
    public partial class OwnerDetails : Window
    {
        private readonly MainWindow _window;
        private OwnerSet owner;
        private string icon;
        private List<AdressSet> Adresses;

        public OwnerDetails(MainWindow window, int id)
        {
            Adresses = new List<AdressSet>();
            _window = window;
            ShowDetails(id);
            InitializeComponent();
            Display();
        }

        private void Display()
        {
            Title.Content = owner.AssignedPerson;
            var img = new Image
            {
                Height = 50,
                Width = 50
            };
            img.Source = new BitmapImage(new Uri($"pack://application:,,,/{icon}"));
            CompanyIcon.Content = img;
            Mail.Content = owner.Email;
            Phone.Content = owner.Phone;
            AdressList.ItemsSource = Adresses;
        }

        private void ShowDetails(int id)
        {
            using (var context = new LocationPhotoManagerEntities())
            {
                owner = context.OwnerSet.First(x => x.Id == id);
                owner.AdressSet.ToList().ForEach(x => Adresses.Add(x));
            }
            icon = owner.Company ? "Photos/Icon/Company.png" : "Photos/Icon/Person.png";
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _window.Show();
            Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }

        private void CreateAdress(object sender, RoutedEventArgs e)
        {
            Hide();
            new AddAdress(this, owner).Show();
        }
        private void ShowDetails(object sender, RoutedEventArgs e)
        {
            Hide();

        }
    }
}
