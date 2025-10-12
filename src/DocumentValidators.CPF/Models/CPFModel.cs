namespace DocumentValidators.CPF.Models;

public class CPFModel
{
    private readonly string _cpf;

    public string Value => _cpf;

    public CPFModel() {}

    public CPFModel(string cpf) 
    {
        if (string.IsNullOrWhiteSpace(cpf)) 
        {
            throw new ArgumentNullException("CPF cannot be null or empty.");
        }

        _cpf = Clean(cpf);
    }

    public bool HasValidLength() 
    {
        bool result = _cpf.Length == 11;
        return result;
    }

    public bool HasAllSameDigits() 
    {
        bool result = _cpf.Distinct().Count() == 1;
        return result;
    }

    private string Clean(string cpf) 
    {
        string result = new string(cpf.Where(char.IsDigit).ToArray());
        return result;
    }
}
