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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bibliotekka
{
    /// <summary>
    /// Логика взаимодействия для LinkBooks.xaml
    /// </summary>
    public partial class LinkBooks : Page
    {

        Entities4 entities = new Entities4();
        public LinkBooks()
        {
            InitializeComponent();
           
            foreach (var books in entities.Books)
                booksComboBox.Items.Add(books);
            foreach (var author in entities.Author)
                authorsComboBox.Items.Add(author);
            linkedItemsList.ItemsSource = entities.AuthorBooks.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewBooks());
        }

        private void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.LinkButton(entities, linkedItemsList, authorsComboBox, booksComboBox);
        }

        private void UnlinkButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.UnLinkDelete(entities, linkedItemsList);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BooksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AuthorsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BooksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AuthorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void linkedItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
