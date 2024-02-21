using OTUS_HW_LESSON_17_part2;
using System.Diagnostics;


//1.Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
//Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
//public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;
//2.Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
//3.Оформить событие и его аргументы с использованием .NET соглашений:
//public event EventHandler FileFound;
//FileArgs – будет содержать имя файла и наследоваться от EventArgs
//4.Добавить возможность отмены дальнейшего поиска из обработчика;
//5.Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.


FileViewer newViewer = new FileViewer();
CancellationTokenSource cts = new CancellationTokenSource();
var token = cts.Token; 
newViewer.FileFound += (sender, hendler) => Console.WriteLine(hendler.DisplayMassege);
Stopwatch stopwatch = Stopwatch.StartNew();
stopwatch.Start();
var thread = new Thread(() => newViewer.GetFileNames(token, stopwatch));
thread.Start();
while (true)
{
    if (stopwatch.ElapsedMilliseconds > 1400)
    {
        cts.Cancel();
        Console.WriteLine($"Сработал токен отмены {stopwatch.ElapsedMilliseconds}");
        break; 
    }
}


Console.ReadKey();