namespace DocumentValidators.CNH.Validators;

public class CNHValidator
{
    public static bool IsValidCnh(string cnhNumber)
    {
        if (string.IsNullOrEmpty(cnhNumber))
            return false;

        cnhNumber = new string(cnhNumber.Where(char.IsDigit).ToArray());

        if (cnhNumber.Length != 11) 
        {
            return false;
        }

        if (cnhNumber.Distinct().Count() == 1) 
        {
            return false;
        }
            
        int[] d = new int[11];
        for (int i = 0; i < 11; i++) 
        {
            d[i] = cnhNumber[i] - '0';
        }
            
        int s1 = 0, s2 = 0;
        for (int i = 0; i < 9; i++)
        {
            s1 += d[i] * (9 - i);
            s2 += d[i] * (1 + i);
        }

        int dv1 = s1 % 11;
        if (dv1 >= 10) dv1 = 0;

        int dv2 = s2 % 11;
        if (dv2 >= 10) dv2 = 0;

        return dv1 == d[9] && dv2 == d[10];
    }
}
