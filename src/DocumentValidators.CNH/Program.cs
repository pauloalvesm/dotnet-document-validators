using DocumentValidators.CNH.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** CNH Validator **********");

        Console.Write("Enter the Driver's License number (CNH) for validation: ");
        string cnhInput = Console.ReadLine();

        CNHModel cnhInstance = new CNHModel(cnhInput);

        bool isValid = cnhInstance.Validate();

        Console.WriteLine(isValid ? "Valid CNH!" : "Invalid CNH!");
        
        Console.ReadKey();
    }
}