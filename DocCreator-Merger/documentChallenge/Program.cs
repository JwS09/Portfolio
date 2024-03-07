namespace documentChallenge;

class Program
{
    static void Main(string[] args)
    {
    Console.WriteLine("Document");
    Console.WriteLine();

        bool saveAnotherDocument = true;

        while (saveAnotherDocument)
        {
            Console.Write("Enter the name of the document: ");
            string documentName = Console.ReadLine();

            Console.Write("Enter the content of the document: ");
            string documentContent = Console.ReadLine();

            if (!documentName.EndsWith(".txt"))
            {
                documentName += ".txt";
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(documentName))
                {
                    writer.Write(documentContent);
                }

                int charCount = documentContent.Length;
                Console.WriteLine($"{documentName} was successfully saved. The document contains {charCount} characters.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.Write("Do you want to save another document? (y/n): ");
            string response = Console.ReadLine();

            if (response.ToLower() != "y")
            {
                saveAnotherDocument = false;
            }
        }

    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
    }
}
