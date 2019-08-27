using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LocationPhotoLibrary
{
    /// <summary>
    /// Interaction logic for AddAdress.xaml
    /// </summary>
    public partial class AddAdress : Window
    {
        private OwnerDetails _window;
        private OwnerSet _owner;
        private List<BuildingPhoto> buildingPhotos;

        public AddAdress(OwnerDetails window, OwnerSet owner)
        {
            buildingPhotos = new List<BuildingPhoto>();
            InitializeComponent();
            _owner = owner;
            _window = window;
        }

        private void AddPhoto(object sender, RoutedEventArgs e)
        {
            if (buildingPhotos.Count < 15)
            {
                var ofd = new OpenFileDialog
                {

                    Filter = "Images |*.png;*.jpg;*.gif;*.jpeg"
                };
                if (ofd.ShowDialog() == true)
                {
                    var img = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
                    buildingPhotos.Add(new BuildingPhoto
                    {
                        Image = img,
                        Guid = Guid.NewGuid()
                    });
                    GeneratePhotoList();
                }
            }
            else
            {
                MessageBox.Show("Too many Photos", "Photos", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        public void GeneratePhotoList()
        {
            for (var i = 0; i < buildingPhotos.Count; ++i)
            {
                var col = 0;
                var row = 0;
                if (i < 4)
                {
                    col = i;
                }
                else if (i < 8)
                {
                    row = 1;
                    col = i - 4;
                }
                else if (i < 12)
                {
                    row = 2;
                    col = i - 8;
                }
                else if (i < 16)
                {
                    row = 3;
                    col = i - 12;
                }

                var border = new Border();
                border.SetValue(Grid.RowProperty, row);
                border.SetValue(Grid.ColumnProperty, col);
                border.BorderThickness = new Thickness(1);

                var img = new Image { Source = buildingPhotos[i].Image };
                img.MaxHeight = 100;
                img.HorizontalAlignment = HorizontalAlignment.Center;
                img.VerticalAlignment = VerticalAlignment.Top;
                border.MouseEnter += (s, e) =>
                {
                    var b = (Border)s;
                    b.BorderBrush = Brushes.Gray;
                };
                border.MouseLeave += (s, e) =>
                {
                    var b = (Border)s;
                    b.BorderBrush = Brushes.White;
                };
                border.Child = img;
                Photos.Children.Add(border);

            }
        }

        public struct BuildingPhoto
        {
            public BitmapImage Image { get; set; }
            public Guid Guid { get; set; }
        }
    }
}
