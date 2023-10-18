using System.Linq;

using System.Collections;

List<Client> clients = new List<Client>();
clients.Add(new Client() { Name = "Yan", Assets = 1005000000});;
clients.Add(new Client() { Name = "Van", Assets = 2131 }); ;
clients.Add(new Client() { Name = "Hag", Assets = 800 }); ;
clients.Add(new Client() { Name = "Gan", Assets = 1500 }); ;


var richieRich = clients.GetMax(x => x.Assets);

Console.WriteLine($"{richieRich.Name} is Richie Rich");
Console.ReadLine();
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