using System;
using System.Collections.Generic;
using System.Text;


    public static class Operations
    {
        public const string SHOW_CONTACTS_LIST = "1";
        public const string ADD_NEW_CONTACT = "2";
        public const string REMOVE_CONTACT = "3";
        public const string EXIT = "0";

        public static void PrintContacts(ContactList contactList)
        {
            Contact[] contacts = contactList.GetContacts();

            Console.WriteLine("Порядковый номер - Имя - номер телефона - возраст");



            for (int i = 0; i < contacts.Length; i++)
            {
                Contact contact = contacts[i];
                int contactNumber = i + 1;
                Console.WriteLine(contactNumber + ")" + contact.Name + " - " + contact.Phone + " - " + contact.Age);
            }

        }

        public static void CreateNewContact(ContactList contactList)
        {
            Contact newContact = new Contact();

            Console.Write("Введите имя: ");

            newContact.Name = Console.ReadLine();

            Console.Write("Введите номер телефона: ");

            newContact.Phone = Console.ReadLine();

            Console.Write("Введите возраст: ");

            newContact.Age = Byte.Parse(Console.ReadLine());

            contactList.Add(newContact);
        }
        public static void RemoveContact(ContactList contactList)
        {
            bool shouldRemove = true;

            do
            {
                Contact[] contacts = contactList.GetContacts();

                Console.WriteLine("Порядковый номер - Имя - номер телефона - возраст");



                for (int i = 0; i < contacts.Length; i++)
                {
                    Contact contact = contacts[i];
                    int contactNumber = i + 1;
                    Console.WriteLine(contactNumber + ")" + contact.Name + " - " + contact.Phone + " - " + contact.Age);
                }

                Console.Write("Для удаления записи введите порядковый номер: ");

                int numberOfContactToRemove = Int32.Parse(Console.ReadLine());

                if (numberOfContactToRemove <= contacts.Length)
                {
                    contactList.Remove(numberOfContactToRemove);

                    Console.WriteLine("Вы успешно удалили запись");

                    shouldRemove = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели недопустимый порядковый номер, попробуйте еще раз");
                }

            } while (shouldRemove);
        }

    }
