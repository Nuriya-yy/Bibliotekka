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
    /// Логика взаимодействия для NewBooks.xaml
    /// </summary>
    public partial class NewBooks : Page
    {
        Entities4 entities= new Entities4();
        public NewBooks()
        {
            InitializeComponent();
            foreach(var book in entities.Books)
                booksBox.Items.Add(book);
            foreach (var author in entities.Author)
                authorBox.Items.Add(author);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void booksBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void authorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.AddBooks(entities, booksBox, nameBook);
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.DeleteBook(entities, booksBox);
        }

        private void ClearBookButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.CleanButton(nameBook);
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.AddAuthor(entities, authorBox, nameAuthor,FirstNameAuthor,LastNameAuthor);
        }

        private void DeleteAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.DeleteAuthor(entities, authorBox);
        }

        private void ClearAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.CleanButton(nameAuthor,FirstNameAuthor,LastNameAuthor);
        }

        private void AuthorBooks_Click(object sender, RoutedEventArgs e)
        {
            LinkBooks linkBooksPage = new LinkBooks();
            NavigationService.Navigate(linkBooksPage);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AuthorAndBooks authorandbooks = new AuthorAndBooks();
            NavigationService.Navigate(authorandbooks);
        }
    }
}
