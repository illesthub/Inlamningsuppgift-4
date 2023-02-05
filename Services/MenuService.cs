namespace Adressbok.Services
{
    internal class MenuService
    {
        public static void MainMenu()

        {
            Console.WriteLine("Välkommen till Adressboken");
            Console.WriteLine("1. Skapa en kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa en specifik kontakt");
            Console.WriteLine("4. Ta bort en specifik kontakt");
            Console.WriteLine("Välj ett av alternativen ovan:");
            var option = Console.ReadLine();

            var service = new ContactService();

            Console.Clear();

            switch (option)
            {
                case "1": service.CreateContact(); break;
                case "2": service.ShowAllContacts(); break;
                case "3": service.ShowSpecificContact(); break;
                case "4": service.RemoveSpecificContact(); break;
            }

        }
    }
}
