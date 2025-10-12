using DocumentValidators.CPF.Models;
using DocumentValidators.CPF.Validators;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** CPF validator **********");

        Console.Write("\nEnter tge CPF for validation: ");
        string input = Console.ReadLine();

        Console.Write("---------- Result ----------\n");

        try
        {
            CPFModel cpf = new CPFModel(input);
            CPFValidator validator = new CPFValidator(cpf);

            bool IsValid = validator.Validate();

            Console.WriteLine(IsValid ? "Valid CPF!" : "Invalid CPF!");
        }
        catch (ArgumentException exception)
        {
            Console.Write($"Error: {exception.Message}");
        }

        Console.ReadKey();
    }
}