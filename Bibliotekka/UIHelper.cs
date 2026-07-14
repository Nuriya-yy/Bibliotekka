using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bibliotekka
{
    public static class UIHelper
    {
        public static void CleanButton(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = string.Empty;
            }
        }
      
        public static void DeleteBook(Entities4 entities, ComboBox booksBox)
        {
            if (booksBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для удаления!",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            Books selectedBook = (Books)booksBox.SelectedItem;

            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить книгу \"{selectedBook.NameBook}\"?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    entities.Books.Remove(selectedBook);
                    entities.SaveChanges();
                    booksBox.Items.Remove(selectedBook);

                    MessageBox.Show("Книга успешно удалена!",
                                    "Успех",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении книги: {ex.Message}",
                                    "Ошибка",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        public static void DeleteAuthor(Entities4 entities, ComboBox authorBoxx)
        {
            if (authorBoxx.SelectedItem == null)
            {
                MessageBox.Show("Выберите автора для удаления!", "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            Author selectAuthor = (Author)authorBoxx.SelectedItem;
            MessageBoxResult result =
                   MessageBox.Show("Вы точно хотите удалить выбранного автора?", "Потверждение удаления",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    entities.Author.Remove(selectAuthor);
                    entities.SaveChanges();
                    authorBoxx.Items.Remove(selectAuthor);

                    MessageBox.Show("Автор успешно удален!",
                                    "Успех",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении автора: {ex.Message}",
                                    "Ошибка",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        public static void AddBooks(Entities4 entities, ComboBox booksBox, TextBox nameBook)
        {
            if (string.IsNullOrWhiteSpace(nameBook.Text))
            {
                MessageBox.Show("Введите название книги!",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            bool bookExists = entities.Books.Any(b => b.NameBook == nameBook.Text.Trim());

            if (bookExists)
            {
                MessageBox.Show($"Книга \"{nameBook.Text.Trim()}\" уже существует в базе данных!",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }
            Books newBook = new Books
            {
                NameBook = nameBook.Text.Trim(),
            };

            try
            {
                entities.Books.Add(newBook);
                entities.SaveChanges();

                booksBox.Items.Add(newBook);

                nameBook.Text = string.Empty;

                MessageBox.Show($"Книга \"{newBook.NameBook}\" успешно добавлена!",
                                "Успех",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении книги: {ex.Message}",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        public static void AddAuthor(Entities4 entities, ComboBox authorBox, TextBox nameAuthor, TextBox FirstNameAuthor, TextBox LastNameAuthor)
        {
            if (string.IsNullOrWhiteSpace(nameAuthor.Text))
            {
                MessageBox.Show("Введите имя автора!",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(FirstNameAuthor.Text))
            {
                MessageBox.Show("Введите фамилию автора!",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            bool authorExists = entities.Author.Any(a =>
                a.Name == nameAuthor.Text.Trim() &&
                a.FirstName == FirstNameAuthor.Text.Trim() &&
                a.LastName == LastNameAuthor.Text.Trim());

            if (authorExists)
            {
                MessageBox.Show($"Автор \"{nameAuthor.Text.Trim()} {FirstNameAuthor.Text.Trim()}\" уже существует!",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            Author newAuthor = new Author
            {
                Name = nameAuthor.Text.Trim(),
                FirstName = FirstNameAuthor.Text.Trim(),
                LastName = string.IsNullOrWhiteSpace(LastNameAuthor.Text) ? null : LastNameAuthor.Text.Trim()
            };

            try
            {
                entities.Author.Add(newAuthor);
                entities.SaveChanges();

                authorBox.Items.Add(newAuthor);

                nameAuthor.Text = string.Empty;
                FirstNameAuthor.Text = string.Empty;
                LastNameAuthor.Text = string.Empty;

                MessageBox.Show($"Автор \"{newAuthor.Name} {newAuthor.FirstName}\" успешно добавлен!",
                                "Успех",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении автора: {ex.Message}",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        public static void AddReaders(Entities4 entities, TextBox Name, TextBox FirstNAme,TextBox Nomber, ListBox listReaders)
        {
            if(Name==null|| FirstNAme==null|| Nomber==null)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Error); 
                return;
            }
            bool readers = entities.Readers.Any(a =>
               a.Name == Name.Text.Trim() &&
               a.FirstName == FirstNAme.Text.Trim() &&
               a.Phone == Nomber.Text.Trim());

            if (readers)
            {
                MessageBox.Show($"Читатель \"{Name.Text.Trim()} {FirstNAme.Text.Trim()}\" уже существует!",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            Readers readers_ = new Readers
            {
                Name = Name.Text.Trim(),
                FirstName = FirstNAme.Text.Trim(),
                Phone = Nomber.Text.Trim(), 
            };

            try
            {
                entities.Readers.Add(readers_);
                entities.SaveChanges();

                Name.Text = string.Empty;
                FirstNAme.Text = string.Empty;
                Nomber.Text = string.Empty;

                MessageBox.Show($"Читатель \"{readers_.Name} {readers_.FirstName}\" успешно добавлен!",
                                "Успех",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                listReaders.ItemsSource = null;
                listReaders.ItemsSource = entities.Readers.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении читателя: {ex.Message}",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }

        }

        public static void DeleteReaders(Entities4 entities, ListBox readersList)
        {
            if (readersList.SelectedItem == null)
            {
                MessageBox.Show("Выберите читателя для удаления!", "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            Readers selectReaders = (Readers)readersList.SelectedItem;
            MessageBoxResult result =
                   MessageBox.Show("Вы точно хотите удалить выбранного читателя?", "Потверждение удаления",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    entities.Readers.Remove(selectReaders);
                    entities.SaveChanges();

                    readersList.ItemsSource = null;
                    readersList.ItemsSource = entities.Readers.ToList();

                    MessageBox.Show("Читатель успешно удален!",
                                    "Успех",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении читателя: {ex.Message}",
                                    "Ошибка",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        public static void ListReader(Entities4 entities, ListBox listReaders, TextBox name, TextBox firstName, TextBox nomber)
        {
         if (listReaders.SelectedItem == null) 
                return;

         if(listReaders.SelectedItem is Readers selectedReaders)
            {
                name.Text = selectedReaders.Name;
                firstName.Text = selectedReaders.FirstName;
                nomber.Text = selectedReaders.Phone;
           }

           
        }

        public static void CleanReaders(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = string.Empty;
            }
        }

        public static void UnLinkDelete(Entities4 entities, ListBox listLink)
        {
            if (listLink.SelectedItem == null)
            {
                MessageBox.Show("Выберите связь для удаления!", "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            AuthorBooks selectedLink = (AuthorBooks)listLink.SelectedItem;
            MessageBoxResult result =
                   MessageBox.Show("Вы точно хотите удалить выбранную связь?", "Потверждение удаления",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    entities.AuthorBooks.Remove(selectedLink);
                    entities.SaveChanges();

                    listLink.ItemsSource = null;
                    listLink.ItemsSource = entities.AuthorBooks.ToList();

                    MessageBox.Show("Связь успешно удалена!",
                                    "Успех",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении связи: {ex.Message}",
                                    "Ошибка",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        public static void LinkButton(Entities4 entities, ListBox listLink, ComboBox authorBox, ComboBox booksBox)
        {
            try
            {
                if (authorBox.SelectedItem == null || booksBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите автора и книгу для связи!", "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
                }

                var selectedAuthor = (Author)authorBox.SelectedItem;
                var selectedBook = (Books)booksBox.SelectedItem;

                var existingLink = entities.AuthorBooks
                    .FirstOrDefault(ab => ab.AuthorID == selectedAuthor.id &&
                                          ab.BooksID == selectedBook.id);

                if (existingLink != null)
                {
                    MessageBox.Show("Эта связь уже существует!", "Информация",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
                }

                var newLink = new AuthorBooks
                {
                    AuthorID = selectedAuthor.id,
                    BooksID = selectedBook.id
                };

                entities.AuthorBooks.Add(newLink);
                entities.SaveChanges();

                listLink.ItemsSource = null; 
                listLink.ItemsSource = entities.AuthorBooks.ToList();

                MessageBox.Show("Связь успешно создана!", "Успех",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании связи: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //выдача

        public static void CleanLoans(params ComboBox[] comboBoxes)
        {
            foreach (var cmBox in comboBoxes)
            {
                cmBox.SelectedItem = null;
                cmBox.SelectedValue = null;
            }
        }
      
        public static void AddLoan(Entities4 entities, ComboBox readersComboBox, ComboBox booksComboBox,
                                   DatePicker loanDatePicker, DatePicker dueDatePicker, ListBox loansListBox)
        {
            try
            {
                if (readersComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите читателя!", "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                if (booksComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите книгу!", "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
                if (loanDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Выберите дату выдачи!", "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
                if (dueDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Выберите дату возврата!", "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                if (dueDatePicker.SelectedDate < loanDatePicker.SelectedDate)
                {
                    MessageBox.Show("Дата возврата не может быть раньше даты выдачи!", "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                var selectedReader = (Readers)readersComboBox.SelectedItem;
                var selectedBook = (Books)booksComboBox.SelectedItem;

                var existingLoan = entities.Loans
                    .FirstOrDefault(l => l.BooksID == selectedBook.id && l.IsReturned == false);

                if (existingLoan != null)
                {
                    MessageBox.Show($"Книга \"{selectedBook.NameBook}\" уже выдана другому читателю!",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
                var newLoan = new Loans
                {
                    ReadersID = selectedReader.id,
                    BooksID = selectedBook.id,
                    LoanDate = loanDatePicker.SelectedDate.Value,
                    DueDate = dueDatePicker.SelectedDate.Value,
                    IsReturned = false
                };

                entities.Loans.Add(newLoan);
                entities.SaveChanges();

                RefreshLoansList(entities, loansListBox);

                MessageBox.Show($"Книга \"{selectedBook.NameBook}\" выдана читателю {selectedReader.Name}!",
                    "Успех",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выдаче книги: {ex.Message}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        public static void ReturnBook(Entities4 entities, ListBox loansListBox)
        {
            try
            {
                if (loansListBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите запись о выдаче для возврата книги!",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                var selectedLoan = (Loans)loansListBox.SelectedItem;
                if (selectedLoan.IsReturned == true)
                {
                    MessageBox.Show("Эта книга уже была возвращена!",
                        "Информация",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
                }

                MessageBoxResult result = MessageBox.Show(
                    $"Вернуть книгу \"{selectedLoan.Books.NameBook}\" читателю {selectedLoan.Readers.Name}?",
                    "Подтверждение возврата",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    selectedLoan.IsReturned = true;

                    entities.SaveChanges();
                    RefreshLoansList(entities, loansListBox);

                    MessageBox.Show("Книга успешно возвращена!",
                        "Успех",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при возврате книги: {ex.Message}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public static void DeleteLoan(Entities4 entities, ListBox loansListBox)
        {
            try
            {
                if (loansListBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите запись о выдаче для удаления!",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                var selectedLoan = (Loans)loansListBox.SelectedItem;

                MessageBoxResult result = MessageBox.Show(
                    $"Удалить запись о выдаче книги \"{selectedLoan.Books.NameBook}\" читателю {selectedLoan.Readers.Name}?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    entities.Loans.Remove(selectedLoan);
                    entities.SaveChanges();

                    RefreshLoansList(entities, loansListBox);

                    MessageBox.Show("Запись успешно удалена!",
                        "Успех",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи: {ex.Message}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public static void RefreshLoansList(Entities4 entities, ListBox loansListBox, string filter = "All")
        {
            try
            {
                if (loansListBox == null || entities == null || entities.Loans == null)
                    return;

                var loans = entities.Loans.ToList();

                switch (filter)
                {
                    case "Active":
                        loans = loans.Where(l => l.IsReturned == false).ToList();
                        break;
                    case "Returned":
                        loans = loans.Where(l => l.IsReturned == true).ToList();
                        break;
                    case "Overdue":
                        loans = loans.Where(l => l.IsReturned == false && l.DueDate < DateTime.Today).ToList();
                        break;
                    default:
                        loans = loans.ToList();
                        break;
                }

                loansListBox.ItemsSource = null;
                loansListBox.ItemsSource = loans;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RefreshLoansList error: {ex.Message}");
            }
        }

        public static void CleanLoanFields(ComboBox readersComboBox, ComboBox booksComboBox,
                                          DatePicker loanDatePicker, DatePicker dueDatePicker)
        {
            readersComboBox.SelectedItem = null;
            readersComboBox.SelectedValue = null;

            booksComboBox.SelectedItem = null;
            booksComboBox.SelectedValue = null;

            loanDatePicker.SelectedDate = DateTime.Today;
            dueDatePicker.SelectedDate = null;
        }
    }
}