using Microsoft.Win32;
using System.Windows;

namespace Tester
{
    public partial class MainWindow : Window
    {
        private Test test;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateQuestion_Click(object sender, RoutedEventArgs e)
        {
            questionCreate questionWindow = new questionCreate();
            questionWindow.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var exit = MessageBox.Show(
                "Вы действительно хотите закрыть приложение?",
                "Выход из приложения", MessageBoxButton.YesNo);
            if (exit == MessageBoxResult.Yes)
                this.Close(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Test loadedTest = Test.LoadFromJson(filePath); // Загрузите тест из файла, если у вас есть такой метод
                testPassing testWindow = new testPassing(loadedTest);
                testWindow.ShowDialog();
            }
        }
    }
}
