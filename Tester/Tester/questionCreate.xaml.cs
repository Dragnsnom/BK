using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tester
{
    public partial class questionCreate : Window
    {

        private ObservableCollection<Question> questionsList; // Список вопросов
        private int numberOfQuestions; // Количество вопросов в тесте


        public questionCreate()
        {
            InitializeComponent();
            questionsList = new ObservableCollection<Question>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            // Создание объекта вопроса
            string questionText = QuestionTextBox.Text;
            List<string> choices = ChoicesTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> correctAnswers = new List<int>();

            // Проверка наличия выбранных правильных ответов
            foreach (var item in ChoicesListBox.SelectedItems)
            {
                correctAnswers.Add(ChoicesListBox.Items.IndexOf(item));
            }

            // Проверка валидности данных
            if (string.IsNullOrWhiteSpace(questionText) || choices.Count < 2 || correctAnswers.Count == 0)
            {
                MessageBox.Show("Пожалуйста, введите корректные данные для вопроса.");
                return;
            }

            // Создание объекта Question и добавление его в список вопросов
            Question newQuestion = new Question(questionText, choices, correctAnswers);
            questionsList.Add(newQuestion);

            // Очистка полей ввода
            QuestionTextBox.Clear();
            ChoicesTextBox.Clear();
            ChoicesListBox.SelectedItems.Clear();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Проверка, что пользователь добавил достаточное количество вопросов
            if (questionsList.Count < numberOfQuestions)
            {
                MessageBox.Show($"Пожалуйста, добавьте еще {numberOfQuestions - questionsList.Count} вопросов.");
                return;
            }

            // Диалоговое окно для выбора места сохранения JSON файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                // Создание объекта Test и сохранение его в JSON файл
                Test test = new Test("Название теста"); // Замените на актуальное название
                test.Questions.AddRange(questionsList);
                test.SaveToJson(saveFileDialog.FileName);
                MessageBox.Show("Тест сохранен в JSON файл.");
                Close();
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // Очистка ListBox
            ChoicesListBox.Items.Clear();

            // Получение текста из TextBox
            string inputText = ChoicesTextBox.Text;

            // Разделение текста на строки по символу Enter
            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Добавление каждой строки в ListBox
            foreach (string line in lines)
            {
                ChoicesListBox.Items.Add(line);
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            // Очистка ListBox
            ChoicesListBox.Items.Clear();

            // Получение текста из TextBox
            string inputText = ChoicesTextBox.Text;

            if (e.Key == Key.Return)
            {
                foreach (char c in inputText)
                {
                    ChoicesListBox.Items.Add(c.ToString());
                }

            }
        }
    }
}
