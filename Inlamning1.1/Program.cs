// See https://aka.ms/new-console-template for more information

/*
 * Följande funktionalitet måste finnas med i applikationen för att kunna uppnå kravet för godkänt (G):

1 Det ska vara möjligt att lägga till en ny kontaktperson.
2 Det ska vara möjligt att lista  upp samtliga kontakter på ett snyggt och prydligt sätt, som du själv väljer.
3 Det ska vara möjligt att sen detaljerad information om en specifik kontaktperson.
4 Efter att den detaljerade informationen om en kontaktperson visats. Ska vara möjligt att att kunna uppdatera kontaktpersonen.
5 Efter att den detaljerade informationen om en kontaktperson visats. Ska vara möjligt att att kunna ta bort kontaktpersonen.
6 Du ska kommentera din kod med hjälp av korta kommentarer.

Följande funktionalitet måste finnas med i applikationen för att kunna uppnå kravet för väl godkänt (VG):

Samtliga krav för kravet godkänt (G) måste uppfyllas.
Alla menyer ska hanteras med hjälp av en Service.
Alla hjälpklasser/services ska använda sig av ett interface.
Det ska vara möjligt att spara ner listan till en fil med filformatet .json.
Det ska vara möjligt att hämta listan från en fil som är sparad med filformatet .json.
Det ska vara enkelt att kunna ange och uppdatera sökvägen till där filen ska vara sparad. 
 */

using Inlamning1;
using System.Transactions;
string mainMenu = $"Addressbook! \nSelect an option by entering a number shown: \n1 Add Contact \n2 View all contacts \n3 Search for a contact \n" +
                  $"4 Search for a contact using ID number \nPress x and then enter to exit the program";
Console.WriteLine(mainMenu);
var addressBook = new AddressBook();
var userInput = Console.ReadLine();
int searchNumber;

while (true)
{
    switch (userInput)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Enter contact name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter contact address:");
            var address = Console.ReadLine();
            Console.WriteLine("Enter contact email:");
            var email = Console.ReadLine();           
            addressBook.AddContact(name, address, email);
            Console.WriteLine("Contact added! Press any key to return to main menu");
            Console.ReadKey();
            break; 
        case "2":
            addressBook.DisplayAllContacts(); //visar alla kontakter med hjälp av metoden DisplayAllContacts
            
            try
            {
                searchNumber = Int32.Parse(Console.ReadLine());
                addressBook.DisplayContact(searchNumber);
                Console.WriteLine("Press 1 to edit the contact, 2 to delete the contact or any other key to return to main menu.");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1": //edit the contact
                        Console.Clear();
                        Console.WriteLine("Enter new contact name:");
                        var newName = Console.ReadLine();
                        Console.WriteLine("Enter new contact address:");
                        var newAddress = Console.ReadLine();
                        Console.WriteLine("Enter new contact email:");
                        var newEmail = Console.ReadLine();
                        addressBook.EditContact(searchNumber, newName, newAddress, newEmail);   
                        break;
                    case "2":
                        addressBook.DeleteContact(searchNumber);//delete contact
                        Console.WriteLine("Contact successfully deleted! Returning to main menu.");
                        Console.ReadKey();
                        break;
                    default:
                        break;

                }
            }
            catch
            {
                Console.WriteLine("Returning to main menu."); 
                Console.ReadKey();
            }
            break;           
        case "3":
            Console.Clear();
            Console.WriteLine("Search for a contact name");
            var searchPhrase = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Search result: ");
            addressBook.DisplayMatchingContacts(searchPhrase);
            Console.ReadKey();
            break;           
        case "4":
            Console.Clear();
            Console.WriteLine("Search for a contact using user ID number");  //ÄNDRA TILL DELETE FUNKTION
            searchNumber = Int32.Parse(Console.ReadLine());
            addressBook.DisplayContact(searchNumber);
            Console.ReadKey();
            break;
        case "x":
            return;
        default:
            Console.WriteLine("Select an option by pressing 1-4");
            Console.ReadKey();
            break;

    }
    Console.Clear();
    Console.WriteLine(mainMenu);
    userInput = Console.ReadLine(); 
}



