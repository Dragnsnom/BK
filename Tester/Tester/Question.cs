using System.Collections.Generic;

public class Question
{
    public string QuestionText { get; set; }
    public List<string> Choices { get; set; }
    public List<int> CorrectAnswers { get; set; }
    public Question(string questionText, List<string> choices, List<int> correctAnswers)
    {
        QuestionText = questionText;
        Choices = choices;
        CorrectAnswers = correctAnswers;
    }
}