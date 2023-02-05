using Newtonsoft.Json;

namespace Adressbok.Services
{
    public class ContactService
    {
        /* fields */
        private List<Contact> contacts = new();
        private readonly FileService jsonFile = new();

        /* Constructor */
        public ContactService()
        {
            jsonFile.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";

            UpdateContactList();
        }

        /* Method for updating the JSON file */
        private void UpdateContactList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<List<Contact>>(jsonFile.Read());
                if (items != null)
                    contacts = items;
            }
            catch { }
        }


        /* Create a new contact */
        public void CreateContact()
        {
            Console.Clear();

            Contact contact = new();

            Console.WriteLine("Skapa en ny kontakt");

            Console.Write("Ange förnamn: ");
            contact.FirstName = Console.ReadLine() ?? "";

            Console.Write("Ange efternamn: ");
            contact.LastName = Console.ReadLine() ?? "";

            Console.Write("Ange e-postadress: ");
            contact.Email = Console.ReadLine() ?? "";

            Console.Write("Ange telefonnummer: ");
            contact.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Ange adress: ");
            contact.Adress = Console.ReadLine() ?? "";

            Console.Write("Ange postkod: ");
            contact.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Ange ort: ");
            contact.Locality = Console.ReadLine() ?? "";

            contacts.Add(contact);
            jsonFile.Save(JsonConvert.SerializeObject(contacts));
            Console.ReadKey();
        }

        /* Show All Contacts */
        public void ShowAllContacts()
        {
            Console.Clear();

            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                Console.WriteLine($"{contact.Email}");
                Console.WriteLine($"{contact.PhoneNumber}");
            }
            Console.ReadKey();
        }

        /* Show a specifik contact using email */
        public void ShowSpecificContact()
        {
            Console.Clear();
            Console.Write("Ange e-postadress: ");
            var email = Console.ReadLine() ?? string.Empty;

            var contact = contacts.Find(contact => contact.Email.Contains(email));
            if (contact != null)
            {
                Console.Clear();
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"E-postadress: {contact.Email}");
                Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact.Adress}, {contact.PostalCode} {contact.Locality}");
            }
            Console.ReadKey();
        }

        /* Delete a specific contact using email */
        public void RemoveSpecificContact()
        {
            Console.Clear();
            Console.WriteLine("Ta bort en kontakt");
            Console.Write("Ange e-postadress: ");
            var email = Console.ReadLine() ?? string.Empty;

            Console.Write($"Är du säker på att du vill ta bort kontakten med e-postadressen {email}? y / n : ");
            var response = Console.ReadLine();

            if (response == "y")
            {
                var contact = contacts.Find(contact => contact.Email.Contains(email));
                if (contact != null)
                {
                    contacts.Remove(contact);
                    jsonFile.Save(JsonConvert.SerializeObject(contacts));
                }
            }
        }
    }
}
