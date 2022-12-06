
using MyNamespace;
using System.Net.Http;
using System.Threading.Channels;

class Program
{
    public static void Main(string[] args)
    {
        var httpclient = new HttpClient();
        ContactList _contactList = new ContactList(100);
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("для просморта записной книжки нажмите (1)");
            Console.WriteLine("для добавления записи в книжку нажмите (2)");
            Console.WriteLine("для удаления записи в кнжику нажмите (3)");
            Console.WriteLine("длы выхода нажмите (0)");

            string operation = Console.ReadLine();

            switch (operation)
            {
                case Operations.SHOW_CONTACTS_LIST:
                    PrintContact();
                    break;

                case Operations.ADD_NEW_CONTACT:
                    CreateContact();
                    break;

                case Operations.REMOVE_CONTACT:
                    DeleteContact();
                    break;

                case Operations.EXIT: //выход
                    return;

                default:
                    Console.WriteLine("Вы нажали неизветсную цифру");
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
            Console.Clear();
        }
    }
    private static void CreateContact()
    {
        var httpclient = new HttpClient();
        var response = httpclient.PostAsync("http://localhost:5213/Issue",null).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);
    }
    private static void DeleteContact()
    {
        var httpclient = new HttpClient();
        var response = httpclient.DeleteAsync("http://localhost:5213/Issue").Result;
        var content = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);
    }
    private static void PrintContact()
    {
        var httpclient = new HttpClient();
        var response = httpclient.GetAsync("http://localhost:5213/Issue").Result;
        var content = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);
    }
}
