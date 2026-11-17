namespace Domain.Models;
public sealed class IndividualniCas:Zapis
{
    public string ImeInstruktora{ get ; init ;}=string.Empty;
    public override string TipZapisa => "Individualni cas";
}