namespace documentMerger;

class Program
{
    static void Main(string[] args)
     {
        {
            Console.WriteLine("Document Merger");
            Console.WriteLine();

            bool mergeAnotherDocument = true;

            while (mergeAnotherDocument)
            {
                Console.Write("Enter the name of the first text file: ");
                string firstFileName = Console.ReadLine();

                if (!File.Exists(firstFileName))
                {
                    Console.WriteLine($"The file '{firstFileName}' does not exist.");
                    continue;
                }

                Console.Write("Enter the name of the second text file: ");
                string secondFileName = Console.ReadLine();

                if (!File.Exists(secondFileName))
                {
                    Console.WriteLine($"The file '{secondFileName}' does not exist.");
                    continue;
                }

                Console.Write($"Enter new filename (default: {Path.GetFileNameWithoutExtension(firstFileName)}{Path.GetFileNameWithoutExtension(secondFileName)}.txt): ");
                string mergedFileName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(mergedFileName))
                {
                    mergedFileName = $"{Path.GetFileNameWithoutExtension(firstFileName)}{Path.GetFileNameWithoutExtension(secondFileName)}.txt";
                }
                else if (!mergedFileName.EndsWith(".txt"))
                {
                    mergedFileName += ".txt";
                }

                try
                {
                    string firstFileContent = File.ReadAllText(firstFileName);
                    string secondFileContent = File.ReadAllText(secondFileName);
                    string mergedContent = firstFileContent + secondFileContent;

                    File.WriteAllText(mergedFileName, mergedContent);

                    int charCount = mergedContent.Length;
                    Console.WriteLine($"{mergedFileName} was successfully saved. The document contains {charCount} characters.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.Write("Do you want to merge another document? (y/n): ");
                string response = Console.ReadLine();

                if (response.ToLower() != "y")
                {
                    mergeAnotherDocument = false;
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}