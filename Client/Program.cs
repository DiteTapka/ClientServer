namespace Server
{
    

class Program
{
    static void Main(string[] args)
    {
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
                    Operations.PrintContacts(_contactList);
                    break;

                case Operations.ADD_NEW_CONTACT:
                    Operations.CreateNewContact(_contactList);
                    break;

                case Operations.REMOVE_CONTACT:
                    Operations.RemoveContact(_contactList);
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



    }
}