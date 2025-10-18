using DocumentValidators.CNPJ.Models;

namespace DocumentValidators.CNPJ.Validators;

public class CNPJValidator
{
    private readonly CNPJModel _cnpj;

    public CNPJValidator(CNPJModel cnpj)
    {
        _cnpj = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
    }

    public bool Validate()
    {
        if (!_cnpj.HasValidLength())
        {
            return false;
        }

        if (_cnpj.HasAllSameDigits())
        {
            return false;
        }

        return ValidateCheckDigits();
    }

    private bool ValidateCheckDigits()
    {
        string cnpjNumber = _cnpj.Value;

        int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpjNumber.Substring(0, 12);
        int sum = 0;

        for (int i = 0; i < 12; i++)
        {
            sum += (tempCnpj[i] - '0') * multiplier1[i];
        }

        int remainder = sum % 11;
        int digit1 = (remainder < 2) ? 0 : 11 - remainder;

        if (digit1 != (cnpjNumber[12] - '0'))
        {
            return false;
        }

        tempCnpj += digit1;
        sum = 0;

        for (int i = 0; i < 13; i++)
        {
            sum += (tempCnpj[i] - '0') * multiplier2[i];
        }

        remainder = sum % 11;
        int digit2 = (remainder < 2) ? 0 : 11 - remainder;

        return digit2 == (cnpjNumber[13] - '0');
    }
}
