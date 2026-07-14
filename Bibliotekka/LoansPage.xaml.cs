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
    public partial class LoansPage : Page
    {
        Entities4 entities = new Entities4();
        private string currentFilter = "All";

        public LoansPage()
        {
            InitializeComponent();

            foreach (var books in entities.Books)
                booksComboBox.Items.Add(books);
            foreach (var readers in entities.Readers)
                readersComboBox.Items.Add(readers);
        }

        private void ReadersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BooksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddLoanButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.AddLoan(entities, readersComboBox, booksComboBox,
                           LoanDatePicker, ReturnDatePicker, LoansListBox);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.CleanLoans(readersComboBox, booksComboBox);
            LoanDatePicker.SelectedDate = DateTime.Today;
            ReturnDatePicker.SelectedDate = null;
        }

        private void ReturnBookButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.ReturnBook(entities, LoansListBox);
        }

        private void DeleteLoanButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.DeleteLoan(entities, LoansListBox);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorAndBooks());
        }

        private void LoansListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LoansListBox.SelectedItem == null)
                return;

            var selectedLoan = (Loans)LoansListBox.SelectedItem;

            readersComboBox.SelectedItem = selectedLoan.Readers;
            booksComboBox.SelectedItem = selectedLoan.Books;
            LoanDatePicker.SelectedDate = selectedLoan.LoanDate;
            ReturnDatePicker.SelectedDate = selectedLoan.DueDate;
        }
        private void AllRadio_Checked(object sender, RoutedEventArgs e)
        {
            currentFilter = "All";
            UIHelper.RefreshLoansList(entities, LoansListBox, currentFilter);
        }

        private void ActiveRadio_Checked(object sender, RoutedEventArgs e)
        {
            currentFilter = "Active";
            UIHelper.RefreshLoansList(entities, LoansListBox, currentFilter);
        }

        private void ReturnedRadio_Checked(object sender, RoutedEventArgs e)
        {
            currentFilter = "Returned";
            UIHelper.RefreshLoansList(entities, LoansListBox, currentFilter);
        }

        private void OverdueRadio_Checked(object sender, RoutedEventArgs e)
        {
            currentFilter = "Overdue";
            UIHelper.RefreshLoansList(entities, LoansListBox, currentFilter);
        }
    }
}