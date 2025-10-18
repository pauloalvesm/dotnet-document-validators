namespace DocumentValidators.CNPJ.Models;

public class CNPJModel
{
    private readonly string _cnpj;

    public string Value => _cnpj;

    public CNPJModel() { }

    public CNPJModel(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
        {
            throw new ArgumentException("CNPJ cannot be null or empty.");
        }

        _cnpj = Clean(cnpj);
    }

    private string Clean(string cnpj)
    {
        return new string(cnpj.Where(char.IsDigit).ToArray());
    }
    
    public bool HasValidLength()
    {
        return _cnpj.Length == 14;
    }

    public bool HasAllSameDigits()
    {
        return _cnpj.Distinct().Count() == 1;
    }
}
