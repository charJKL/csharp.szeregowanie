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
using System.Windows.Shapes;

using Szeregowanie.ViewModel;


namespace Szeregowanie.View
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        public static bool DatagridHasError = false;

        public Lobby()
        {
            InitializeComponent();
            DataContext = new LobbyViewModel();
        }

        private void FindSoultion(object sender, RoutedEventArgs e)
        {
            if ( TasksList.Items.Count < 2)
            {
                ShowPopupAboutEmptyTasksList();
                return;
            }

            if( CheckIfDataGridHasError())
            {
                ShowPopupAboutErrorOccurInDataGrid();
                return;
            }

            OutDate.Visibility = Visibility.Hidden;
            ((LobbyViewModel)DataContext).FindSolution();
        }

        private void FillWithRandom(object sender, RoutedEventArgs e)
        {
            
            ((LobbyViewModel)DataContext).CreateRandomData();
            string message = "Wygenerowałem losowe zadania.\n";
            MessageBox.Show(message, "Generator.", MessageBoxButton.OK, MessageBoxImage.Information);
            OutDate.Visibility = Visibility.Visible;
        }

        private void LoadDataFromFile(object sender, RoutedEventArgs e)
        {
            
            var errors = ((LobbyViewModel)DataContext).LoadDataFromFile();
            string message = "";
            if ( errors.Count == 0)
            {
                message = "Wczytałem dane z pliku.\nWszystkie dane zostały wczytane prawidłowo.";
                MessageBox.Show(message, "Wczytaj plik.", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if( errors.ElementAt(0) == "Cancel")
            {
                return;
            }

            message = "Mam dane ale nie obyło się bez problemów:\n";
            foreach (var error in errors)
                message += " " + error + ".\n";
            MessageBox.Show(message, "Wczytaj plik.", MessageBoxButton.OK, MessageBoxImage.Warning);
            OutDate.Visibility = Visibility.Visible;
        }

        private void ClearData(object sender, RoutedEventArgs e)
        {
            DataContext = new LobbyViewModel();
        }

        private bool CheckIfDataGridHasError()
        {
            return Lobby.DatagridHasError;                
        }

        private void ShowPopupAboutErrorOccurInDataGrid()
        {
            string message = "Błąd danych.\nPopraw błędy w czasach zadań.";
            MessageBox.Show(message, "Błąd danych.", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowPopupAboutEmptyTasksList()
        {
            string message = "Brak zadań.\nUzupełnij listę zadań do uszeregowania.";
            MessageBox.Show(message, "Brak zadań.", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void DetectChanges(object sender, DataGridBeginningEditEventArgs e)
        {
            OutDate.Visibility = Visibility.Visible;
        }


    }
}

