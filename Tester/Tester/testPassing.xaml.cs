using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Tester
{
    public partial class testPassing : Window
    {
        private Test test;
        private int currentQuestionIndex;
        private int correctAnswersCount;

        public testPassing(Test test)
        {
            InitializeComponent();
            this.test = test;
            currentQuestionIndex = 0;
            correctAnswersCount = 0;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < test.Questions.Count)
            {
                Question question = test.Questions[currentQuestionIndex];
                QuestionTextBlock.Text = question.QuestionText;
                ChoicesListView.Items.Clear();

                foreach (string choice in question.Choices)
                {
                    ChoicesListView.Items.Add(choice);
                }
            }
            else
            {
                MessageBox.Show($"Вы ответили на все вопросы. Правильных ответов: {correctAnswersCount} из {test.Questions.Count}");
                Close();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestionIndex < test.Questions.Count)
            {
                Question question = test.Questions[currentQuestionIndex];
                List<string> selectedChoices = new List<string>();

                foreach (string item in ChoicesListView.SelectedItems)
                {
                    selectedChoices.Add(item);
                }

                bool isCorrect = CompareAnswers(question.CorrectAnswers, selectedChoices);

                if (isCorrect)
                {
                    correctAnswersCount++;
                }

                currentQuestionIndex++;
                DisplayQuestion();
            }
        }

        private bool CompareAnswers(List<int> correctAnswers, List<string> selectedChoices)
        {
            if (correctAnswers.Count != selectedChoices.Count)
            {
                return false;
            }

            correctAnswers.Sort();
            selectedChoices.Sort();

            for (int i = 0; i < correctAnswers.Count; i++)
            {
                if (correctAnswers[i] != ChoicesListView.Items.IndexOf(selectedChoices[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
