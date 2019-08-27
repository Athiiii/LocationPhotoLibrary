using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LocationPhotoLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<OwnerDisplay> owners;
        public MainWindow()
        {
            UpdateView();
            InitializeComponent();

            OwnerList.ItemsSource = owners;
        }

        public void UpdateView()
        {
            owners = new ObservableCollection<OwnerDisplay>();

            // get All owners
            using (var context = new LocationPhotoManagerEntities())
            {
                context.OwnerSet.ToList().ForEach(x => owners.Add(new OwnerDisplay
                {
                    Owner = x,
                    Icon = x.Company
                        ? Properties.Settings.Default.Company
                        : Properties.Settings.Default.Person
                }));
            }
            if (OwnerList != null)
                OwnerList.ItemsSource = owners;
        }

        private void NewOwner(object sender, RoutedEventArgs e)
        {
            Hide();
            new AddOwner(this).Show();
        }

        private void ShowDetails(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new OwnerDetails(this, ((OwnerDisplay)((ListBox)sender).SelectedItem).Owner.Id).Show();
            Hide();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var tag = (OwnerSet)((Button)sender).Tag;
            using (var context = new LocationPhotoManagerEntities()) 
            {
                context.OwnerSet.Remove(context.OwnerSet.FirstOrDefault(x => x.Id == tag.Id));
                context.SaveChanges();
            }
            UpdateView();
        }
    }
    public struct OwnerDisplay
    {
        public OwnerSet Owner { get; set; }
        public string Icon { get; set; }
    }
}
