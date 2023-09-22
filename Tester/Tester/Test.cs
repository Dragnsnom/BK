using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public class Test
{
    [JsonProperty("TestName")] // Название теста
    public string TestName { get; set; }

    [JsonProperty("Questions")] // Список вопросов в тесте
    public List<Question> Questions { get; set; }

    public Test(string testName)
    {
        TestName = testName;
        Questions = new List<Question>();
    }

    // Метод для сохранения теста в JSON
    public void SaveToJson(string filePath)
    {
        string json = JsonConvert.SerializeObject(this, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public static Test LoadFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Test>(json);
        }
        else
        {
            throw new FileNotFoundException("JSON файл с тестом не найден.");
        }
    }
}
