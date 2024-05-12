using Newtonsoft.Json;
Console.WriteLine("Hello, World!");
string jsonStr = await File.ReadAllTextAsync("data.json");
var model = JsonConvert.DeserializeObject<MainDto>(jsonStr);
Console.WriteLine(jsonStr);
//Json to C#
//C# to Json

foreach (var questions in model.questions)
{
    Console.WriteLine(questions.questionNo);
}

string jsonMth = await File.ReadAllTextAsync("Months.json");
var Model = JsonConvert.DeserializeObject<MyanmarMonths>(jsonMth);
Console.WriteLine(jsonMth);

foreach (var Tbl_Months in Model.Tbl_Months)
{
    Console.WriteLine(Tbl_Months.MonthMm);
}
Console.ReadLine();

static string ToNumber(string num)
{
    num = num.Replace("", "0");
    num = num.Replace("", "1");
    num = num.Replace("", "2");
    num = num.Replace("", "3");
    num = num.Replace("", "4");
    num = num.Replace("", "5");
    num = num.Replace("", "6");
    num = num.Replace("", "7");
    num = num.Replace("", "8");
    num = num.Replace("", "9");
    num = num.Replace("", "10");

    return num;
}
public class MainDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}


public class MyanmarMonths
{
    public Tbl_Months[] Tbl_Months { get; set; }
}

public class Tbl_Months
{
    public int Id { get; set; }
    public string MonthMm { get; set; }
    public string MonthEn { get; set; }
    public string FestivalMm { get; set; }
    public string FestivalEn { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
}

