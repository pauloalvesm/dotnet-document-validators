using DocumentValidators.CNH.Validators;

namespace DocumentValidators.CNH.Models;

public class CNHModel
{
    private readonly string _cnhNumber;

    public string CnhNumber => _cnhNumber;

    public CNHModel(string cnhNumber)
    {
        _cnhNumber = cnhNumber;
    }

    public bool Validate()
    {
        return CNHValidator.IsValidCnh(_cnhNumber);
    }
}
