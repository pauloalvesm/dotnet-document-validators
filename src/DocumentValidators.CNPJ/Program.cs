using DocumentValidators.CNPJ.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** CNPJ validator **********");

        Console.Write("Enter the CNPJ for validation: ");
        string cnpj = Console.ReadLine();

        bool isValid = CNPJModel.ValidateCnpj(cnpj);

        Console.Write("---------- Result ----------\n");

        Console.Write(isValid ? "Valid CNPJ!" : "Invalid CNPJ!");

        Console.ReadKey();
    }
}