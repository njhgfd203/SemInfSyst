var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Сервер студентов работает!");

// Модифицированный словарь с ФИО студентов
var students = new Dictionary<string, (string FullName, string Group, int Score)>
{
    {"Иванов", ("Иванов Иван Иванович", "АДБ-22-06", 38)},
    {"Петров", ("Петров Петр Петрович", "АДБ-22-07", 45)},
    {"Сидоров", ("Сидоров Алексей Николаевич", "АДБ-22-08", 28)}
};

app.MapPost("/student", async (HttpContext httpContext) =>
{
    using StreamReader reader = new StreamReader(httpContext.Request.Body);
    string lastName = await reader.ReadToEndAsync();

    if (students.TryGetValue(lastName, out var student))
    {
        return $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}\n" +
               $"Студент: {student.FullName}\n" +
               $"Группа: {student.Group}\n" +
               $"Средний балл: {student.Score}";
    }
    else
    {
        return $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}\nТакого студента нет";
    }
});

app.Run();