using Debtor.Core;

namespace Debtor
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();
        public void IntroduceDebtorApp()
        {
            Console.WriteLine("Hej, witaj w aplikacji dłużnik");
        }
           decimal amountInDecimal = default(decimal);
        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwe dluznika ktorego chcesz dodac do listy");
            var userName = Console.ReadLine();

            Console.WriteLine("Podaj kwote dlugu");
            var userAmount = Console.ReadLine();

            while (!decimal.TryParse(userAmount, out amountInDecimal))
            {
                Console.WriteLine("podano niepoprawna kwote");
                Console.WriteLine("Podaj kwote dlugu");
                userAmount = Console.ReadLine();
            }    
            BorrowerManager.AddBorrower(userName, amountInDecimal); 
        }
        public void DeleteBorrower()
        {
            Console.WriteLine("Podaj nazwe dluznika ktorego chcesz usunac do listy");
            var userName = Console.ReadLine();
            BorrowerManager.DeleteBorrower(userName, amountInDecimal);
            Console.WriteLine("udalo sie usunac dluznika");      
        }
        public void ListAllBorrowers()
        {
            Console.WriteLine("Oto Lista twoich dluznikow: ");
            foreach (var borrower in BorrowerManager.ListBorrowers())
            {
                Console.WriteLine(borrower);
            }
        }
        public void AskForAction()
        {
            Console.WriteLine("Podaj czynnosc ktora chcesz wykonac: ");

            var userInput = default(string);

            while (userInput != "exit")
            {
            Console.WriteLine("add - dodawanie dluznika");
            Console.WriteLine("del - usuwanie dluznika");
            Console.WriteLine("list - wypisanie listy dluznikow");
            Console.WriteLine("exit - wyjscie z programu");

            userInput = Console.ReadLine();
            userInput = userInput.ToLower();

            switch(userInput)
            {
                case "add":
                    AddBorrower();
                        break;
                case "del":
                    DeleteBorrower();
                        break;
                case "list":
                    ListAllBorrowers();
                        break;
                case "exit":
                        break;
                    default: Console.WriteLine("podano zla wartosc");
                        break;
                }

            }
        }
    }
}
