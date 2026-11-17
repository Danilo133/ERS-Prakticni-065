namespace Domain.Models;
public sealed class GrupniCas:Zapis
{
    public int BrojPolaznika{ get ; init ;}
    public override string TipZapisa => "Grupni cas";
}