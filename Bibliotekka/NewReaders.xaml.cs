using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для NewReaders.xaml
    /// </summary>
    public partial class NewReaders : Page
    {
        Entities4 entities = new Entities4();
        public NewReaders()
        {
            InitializeComponent();
            listReaders.ItemsSource = entities.Readers.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.AddReaders(entities, nameReaders,surnameReaders, phoneReaders, listReaders);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.DeleteReaders(entities, listReaders);
        }

        private void ListReaders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UIHelper.ListReader(entities, listReaders, nameReaders, surnameReaders,phoneReaders );
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorAndBooks());
        }

        private void cleanButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.CleanReaders(nameReaders, surnameReaders, phoneReaders);
        }
    }
}
