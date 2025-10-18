using DocumentValidators.RG.Models;

namespace DocumentValidators.RG.Validators;

public class RGValidator
{
    public static bool Validate(RGModel model)
    {
        string rg = model.Rg;

        if (string.IsNullOrEmpty(rg)) 
        {
            return false;
        }
            
        rg = new string(rg.Where(char.IsDigit).ToArray());

        if (rg.Length != 9) 
        {
            return false;
        }

        if (rg.Distinct().Count() == 1) 
        {
            return false;
        }
            
        return true;
    }
}
