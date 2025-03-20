using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SuperButtonApp
{
    public partial class MainWindow : Window
    {
        private Action changeTransparency;
        private Action changeBackground;
        private Action showMessage;

        public MainWindow()
        {
            InitializeComponent();

            changeTransparency = () =>
            {
                this.Opacity = this.Opacity == 1.0 ? 0.5 : 1.0;
                
            };

            changeBackground = () =>
            {
                this.Background = this.Background == Brushes.Gray ? Brushes.Yellow : Brushes.Gray;
            };

            showMessage = () =>
            {
                MessageBox.Show("Hello, World!");
            };
        }

        private void BtnTransparency_Click(object sender, RoutedEventArgs e)
        {
            changeTransparency();
        }

        private void BtnBackground_Click(object sender, RoutedEventArgs e)
        {
            changeBackground();
        }

        private void BtnHelloWorld_Click(object sender, RoutedEventArgs e)
        {
            showMessage();
        }

        private void BtnSuperMegaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Я супермегакнопка,\nі цього мене не позбавиш!");

            if (chkTransparency.IsChecked == true) changeTransparency();
            if (chkBackground.IsChecked == true) changeBackground();
            if (chkMessage.IsChecked == true) showMessage();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
