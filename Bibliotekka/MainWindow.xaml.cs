using System.Windows;
using System.Windows.Controls;

namespace Bibliotekka
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_page1_Click_1(object sender, RoutedEventArgs e)
        {
            // Скрываем главную страницу
            MainPageGrid.Visibility = Visibility.Collapsed;

            // Показываем Frame и загружаем страницу
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new AuthorAndBooks());
        }

        // Метод для возврата на главную страницу (вызывается из других страниц)
        public void ShowMainPage()
        {
            MainPageGrid.Visibility = Visibility.Visible;
            MainFrame.Visibility = Visibility.Collapsed;
            MainFrame.Content = null; // Очищаем содержимое Frame
        }
    }
}