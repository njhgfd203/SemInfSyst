
using System.Net.Http;
using System.Text;

// Создаем один экземпляр HttpClient для всего приложения
HttpClient httpClient = new HttpClient();

while (true) // Бесконечный цикл для ввода данных
{
    Console.WriteLine("\nВведите фамилию студента (или 'q' для выхода):");
    string lastName = Console.ReadLine()!;

    // Если пользователь хочет выйти
    if (lastName.ToLower() == "q")
    {
        Console.WriteLine("Выход из программы...");
        break;
    }

    // Если ничего не ввели
    if (string.IsNullOrWhiteSpace(lastName))
    {
        Console.WriteLine("Фамилия не должна быть пустой!");
        continue;
    }

    StringContent content = new StringContent(lastName, Encoding.UTF8, "text/plain");

    try
    {
        using var response = await httpClient.PostAsync("https://localhost:7213/student", content);
        string responseText = await response.Content.ReadAsStringAsync();
        Console.WriteLine("\nОтвет от сервера:");
        Console.WriteLine(responseText);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Что-то пошло не так: {ex.Message}");
    }
}

Console.WriteLine("Для выхода нажмите любую клавишу...");
Console.ReadKey();