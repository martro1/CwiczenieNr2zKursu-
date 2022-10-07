namespace Debtor.Core
{
    public class BorrowerManager
    {
        private List<Borrower> Borrowers { get; set; }

        private string FileName { get; set; } = "borrowers.txt";
        public BorrowerManager()
        {
            Borrowers = new List<Borrower>();

            if (!File.Exists(FileName))
            {
                return;
            }
            var fileLines = File.ReadAllLines(FileName);

            foreach(var line in fileLines)
            {
                var lineItems = line.Split(';');

                if (decimal.TryParse(lineItems[1], out var amountInDecimal))
                {
                    AddBorrower(lineItems[0], amountInDecimal,false);
                }
            }
        }
        public void AddBorrower(string name, decimal amount, bool shouldSaveToFile = true)
        {
            var borrower = new Borrower
            {
                Name = name,
                Amount = amount,
            };
            Borrowers.Add(borrower);

            if (shouldSaveToFile)
            {
                File.WriteAllLines(FileName, new List<string> { borrower.ToString() });
            }
        }
        public void DeleteBorrower(string name, decimal amount, bool shouldSaveToFile = true)
        {
            foreach (var borrower in Borrowers)
            {
                if(borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    break;
                }
            }
            if (shouldSaveToFile)
            {
                var borrowersToSave = new List<string>();

                foreach (var borrower in borrowersToSave)
                {
                    borrowersToSave.Add(borrower.ToString());
                }
                File.Delete(FileName);
                File.WriteAllLines(FileName, borrowersToSave); 
            }
        }

        public List<string> ListBorrowers()
        {
            var borrowersStrings = new List<string>();
            var indexer = 1;
            foreach(var borrower in Borrowers)
            {
                var borrowerString = indexer + ". " + borrower.Name + " - " + borrower.Amount + " zł";
                indexer++;
                borrowersStrings.Add(borrowerString);
            }
            return borrowersStrings;
        }

    }
}
