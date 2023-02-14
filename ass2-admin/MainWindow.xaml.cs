using Microsoft.Win32;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ass2_admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private readonly UserPreferenceChangedEventHandler? UserPreferenceChanged;
        List<Style>? gridStyles;
        public MainWindow()
        {
            AdminAPP rest = new();
            Instance = this;
            InitializeComponent();
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(WindowsAccentBrush.SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            BgUpdate();
            MakeStyles();
            productGrid.RowStyle = gridStyles?[0];
            productGrid.CellStyle = gridStyles?[1];
            productGrid.ColumnHeaderStyle = gridStyles?[2];
        }

        public void UpdateGrid()
        {
            productGrid.ItemsSource = AdminAPP.products;
        }

        public static MainWindow? Instance { get; set; }

        public void BgUpdate()
        {
            Background = WindowsAccentBrush.Brush;
        }
        public void MakeStyles()
        {
            // initialise style list
            gridStyles = new List<Style>();
            //create a new stylem target datagrid rows
            Style st1 = new() { TargetType = typeof(DataGridRow) };
            //add a setter for background property to set it to transparent
            st1.Setters.Add(new Setter(BackgroundProperty, Brushes.Transparent));
            //add a setter for border to set it to 0px
            st1.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));

            Style st2 = new() { TargetType = typeof(DataGridCell) };
            st2.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Color.FromArgb(63, 255, 255, 255))));
            st2.Setters.Add(new Setter(PaddingProperty, new Thickness(5)));
            st2.Setters.Add(new Setter(MarginProperty, new Thickness(1)));
            st2.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));
            st2.Setters.Add(new Setter(FontWeightProperty, FontWeights.DemiBold));

            Style st4 = new() { TargetType = typeof(DataGridColumnHeader) };
            st4.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Color.FromArgb(31, 0, 0, 0))));
            st4.Setters.Add(new Setter(PaddingProperty, new Thickness(5)));
            st4.Setters.Add(new Setter(MarginProperty, new Thickness(1)));
            st4.Setters.Add(new Setter(ForegroundProperty, Brushes.White));

            Style st5 = new () { TargetType = typeof(DataGridCell) };
            st5.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Color.FromArgb(31, 255, 255, 255))));
            st5.Setters.Add(new Setter(PaddingProperty, new Thickness(5)));
            st5.Setters.Add(new Setter(MarginProperty, new Thickness(1)));
            st5.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));

            // add each style to the style list
            gridStyles.Add(st1);
            gridStyles.Add(st2);
            gridStyles.Add(st4);
            gridStyles.Add(st5);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminAPP.GetProducts();
        }
    }
}
