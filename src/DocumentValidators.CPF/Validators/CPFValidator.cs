using DocumentValidators.CPF.Models;

namespace DocumentValidators.CPF.Validators;

public class CPFValidator
{
    private readonly CPFModel _cpf;

    public CPFValidator(CPFModel cpf)
    {
        _cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
    }

    public bool Validate() 
    {
        if (!_cpf.HasValidLength()) 
        {
            return false;
        }

        if (_cpf.HasAllSameDigits()) 
        {
            return false;
        }

        return ValidateCheckDigits();
    }

    private bool ValidateCheckDigits() 
    {
        string cpfNumber = _cpf.Value;
        
        int sum = 0;
        for (int i = 0; i < 9; i++) 
        {
            sum += (cpfNumber[i] - '0') * (10 - i);
        }

        int remainder = sum % 11;
        int firstDigit = (remainder < 2) ? 0 : 11 - remainder;

        if (firstDigit != (cpfNumber[9] - '0')) 
        {
            return false;
        }

        sum = 0;
        for (int i = 0; i < 10; i++) 
        {
            sum += (cpfNumber[i] - '0') * (11 - i);
        }

        remainder = sum % 11;
        int secondDigit = (remainder < 2) ? 0 : 11 - remainder;

        return secondDigit == (cpfNumber[10] - '0');
    }
}
