using System.Windows;
using System.Windows.Controls;

namespace Bibliotekka
{
    public partial class AuthorAndBooks : Page
    {
        public AuthorAndBooks()
        {
            InitializeComponent();
        }

        private void back_homeButton_Click(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Window.GetWindow(this);
            if (mainWindow is MainWindow)
            {
                ((MainWindow)mainWindow).ShowMainPage();
            }
        }

        private void addBook_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new NewBooks());
        }

        private void readersButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new NewReaders());
        }

        private void loansButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Visibility=Visibility.Visible;
            MainFrame.Navigate(new LoansPage());
        }
    }
}