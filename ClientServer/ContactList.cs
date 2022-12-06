namespace MyNamespace
{
    

   public class ContactList
    {
        private Contact[] _contacts;
        public ContactList(int max)
        {
            _contacts = new Contact[max];

            _contacts[0] = new Contact
            {
                Name = "Роман",
                Phone = "9991110001",
                Age = 24

            };

            _contacts[1] = new Contact
            {
                Name = "Максим",
                Phone = "9991110002",
                Age = 23

            };

            _contacts[2] = new Contact
            {
                Name = "Александр",
                Phone = "9991110003",
                Age = 27

            };
        }
        public Contact[] GetContacts()
        {
            int contactsCount = Count();
            Contact[] result = new Contact[contactsCount];
            for (int i = 0; i < contactsCount; i++)
            {
                result[i] = _contacts[i];
            }
            return result;
        }

        public void Add(Contact newContact)
        {
            _contacts[Count()] = newContact;
        }

        public void Remove(int selectedContactIndex)
        {
            int contactsCount = Count();
            int contactIndex = selectedContactIndex - 1;
            do
            {
                _contacts[contactIndex] = _contacts[contactIndex + 1];
                contactIndex++;
            } while (_contacts[contactIndex] != null);

        }
        private int Count()
        {
            int counter = 0;
            do
            {
                counter++;
            } while (_contacts[counter] != null);

            return counter;
            

        }


    }
}
