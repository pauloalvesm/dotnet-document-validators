namespace DocumentValidators.CNPJ.Models;

public class CNPJModel
{
    public static bool ValidateCnpj(string cnpj)
    {
        if (string.IsNullOrEmpty(cnpj)) 
        {
            return false;
        }
            

        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        if (cnpj.Length != 14) 
        {
            return false;
        }

        if (cnpj.Distinct().Count() == 1) 
        {
            return false;
        }

        int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj.Substring(0, 12);
        int sum = 0;

        for (int i = 0; i < 12; i++) 
        {
            sum += (tempCnpj[i] - '0') * multiplier1[i];
        }
            
        int remainder = sum % 11;
        int digit1 = (remainder < 2) ? 0 : 11 - remainder;

        tempCnpj += digit1;
        sum = 0;

        for (int i = 0; i < 13; i++) 
        {
            sum += (tempCnpj[i] - '0') * multiplier2[i];
        }
            

        remainder = sum % 11;
        int digit2 = (remainder < 2) ? 0 : 11 - remainder;

        return cnpj.EndsWith(digit1.ToString() + digit2.ToString());
    }
}
