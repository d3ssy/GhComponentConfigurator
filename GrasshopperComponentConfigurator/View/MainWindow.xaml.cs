using System.Windows;
using System.Windows.Input;
using GrasshopperComponentConfigurator.ViewModel;
using Microsoft.Win32;

namespace GrasshopperComponentConfigurator.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
            this.MouseDown += CloseWindow;
        }

        private void GenerateComponentTemplate_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".cs";
            saveFileDialog.Filter = "C# file (*.cs)|*.cs";

            if (saveFileDialog.ShowDialog() == true)
            {
                var path = saveFileDialog.FileName;
                _viewModel.WriteTemplateToFile(_viewModel.GenerateTemplate(), path);
            }
        }

        private void CloseWindow_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseWindow(object sender, MouseEventArgs e)
        {
            if (CloseButton.IsEnabled == false && e.RightButton == MouseButtonState.Pressed)
                CloseButton.IsEnabled = true;
            else if (CloseButton.IsEnabled == true && e.RightButton == MouseButtonState.Pressed)
                CloseButton.IsEnabled = false;
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
