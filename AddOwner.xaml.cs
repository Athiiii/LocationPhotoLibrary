using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LocationPhotoLibrary
{
    /// <summary>
    /// Interaction logic for AddOwner.xaml
    /// </summary>
    public partial class AddOwner : Window
    {
        MainWindow _window;
        public AddOwner(MainWindow window)
        {
            _window = window;
            InitializeComponent();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (Person.Text == string.Empty)
            {
                MessageBox.Show("Assigned Person can't be empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else
            {
                using (var context = new LocationPhotoManagerEntities())
                {
                    context.OwnerSet.Add(new OwnerSet
                    {
                        AssignedPerson = Person.Text,
                        Company = (bool)IsCompany.IsChecked,
                        Email = Mail.Text,
                        Phone = Phone.Text
                    });
                    context.SaveChanges();
                }
                Close();
                _window.Show();
                _window.UpdateView();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _window.UpdateView();
            _window.Show();
            Close();
        }
    }
}
