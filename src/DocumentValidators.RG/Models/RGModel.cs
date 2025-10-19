namespace DocumentValidators.RG.Models
{
    public class RGModel
    {
        public string Rg { get; }

        public RGModel(string rg)
        {
            Rg = rg ?? throw new ArgumentNullException(nameof(rg), "The RG value cannot be null.");
        }
    }
}
