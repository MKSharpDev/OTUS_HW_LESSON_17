using System.Linq;

using System.Collections;

//1.Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
//Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
//public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;
//2.Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
//3.Оформить событие и его аргументы с использованием .NET соглашений:
//public event EventHandler FileFound;
//FileArgs – будет содержать имя файла и наследоваться от EventArgs
//4.Добавить возможность отмены дальнейшего поиска из обработчика;
//5.Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.

internal class Program
{
    public delegate double NewDelegate(Client c);

    private static void Main(string[] args)
    {
        List<Client> clients = new List<Client>();
        clients.Add(new Client() { Name = "Yan", Assets = 1005000000 }); ;
        clients.Add(new Client() { Name = "Van", Assets = 2131 }); ;
        clients.Add(new Client() { Name = "Hag", Assets = 800 }); ;
        clients.Add(new Client() { Name = "Gan", Assets = 1500 }); ;


        NewDelegate GetDoubleDelegate = new(GetDoubl);
        var richieRich = clients.GetMax(x => x.Assets);

        Console.WriteLine($"{richieRich.Name} is Richie Rich");
        Console.ReadLine();
    }
    static double GetDoubl(Client client)
    {
        return client.Assets;
    }
}


public class Client
{
    public string Name { get; set; }
    public int Assets { get; set; }
}

public static class NewExtension
{
    public static T GetMax<T>(this IEnumerable<T> items, Func<T, double> getParameter) where T : class
    {

        double maxValue = 0;

        T target = items.First();
        foreach ( var item in items)
        {
            if (getParameter(item) > maxValue)
            {
                maxValue = getParameter(item);
                target = item;
            }
        }
        return target;
    }
}