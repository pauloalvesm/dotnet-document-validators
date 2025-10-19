using DocumentValidators.RG.Models;
using DocumentValidators.RG.Validators;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** CPF validator **********");

        Console.Write("Enter your ID number for validation (numbers only): ");
        string inputRg = Console.ReadLine();

        try
        {
            RGModel rgModel = new RGModel(inputRg);
            bool isValid = RGValidator.Validate(rgModel);
            Console.WriteLine(isValid ? "Valid ID (format)!" : "Invalid ID!");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        Console.ReadKey();
    }
}