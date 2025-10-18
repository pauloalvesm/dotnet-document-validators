using DocumentValidators.CNPJ.Models;
using DocumentValidators.CNPJ.Validators;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** CNPJ Validator **********");

        Console.Write("\nEnter the CNPJ for validation: ");
        string input = Console.ReadLine();

        Console.Write("---------- Result ----------\n");

        try
        {
            CNPJModel cnpj = new CNPJModel(input);

            CNPJValidator validator = new CNPJValidator(cnpj);

            bool isValid = validator.Validate();

            Console.WriteLine(isValid ? "Valid CNPJ!" : "Invalid CNPJ!");
        }
        
        catch (ArgumentException exception)
        {
            Console.Write($"Error: {exception.Message}");
        }

        Console.ReadKey();
    }
}