var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "������ ��������� ��������!");

// ���������������� ������� � ��� ���������
var students = new Dictionary<string, (string FullName, string Group, int Score)>
{
    {"������", ("������ ���� ��������", "���-22-06", 38)},
    {"������", ("������ ���� ��������", "���-22-07", 45)},
    {"�������", ("������� ������� ����������", "���-22-08", 28)}
};

app.MapPost("/student", async (HttpContext httpContext) =>
{
    using StreamReader reader = new StreamReader(httpContext.Request.Body);
    string lastName = await reader.ReadToEndAsync();

    if (students.TryGetValue(lastName, out var student))
    {
        return $"����: {DateTime.Now:dd.MM.yyyy HH:mm}\n" +
               $"�������: {student.FullName}\n" +
               $"������: {student.Group}\n" +
               $"������� ����: {student.Score}";
    }
    else
    {
        return $"����: {DateTime.Now:dd.MM.yyyy HH:mm}\n������ �������� ���";
    }
});

app.Run();