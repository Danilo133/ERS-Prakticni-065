using Domain.Enums;
namespace Domain.Models;
public abstract class Zapis
{
    public Guid Id{ get ; init ;}=Guid.NewGuid();
    public string Naziv{ get ; init;}=string.Empty;
    public string Opis{get ; init ;}=string.Empty;
    public DateTimeOffset KreiranUtc{ get ; init  ;}=DateTimeOffset.UtcNow;

    public int TrajanjeMinuta{get ; init ;}

    public StatusObrade Status{get ; protected set ;}=StatusObrade.Upisan;
    public List<EvidencijaPolaznika> Polaznici{get ; init ;}=[];
    public abstract string TipZapisa{get ;}

    public ( bool Uspesno,string KodGreske,string Poruka) EvidentirajPrisustvo(string imePolaznika)
    {
        if(string.IsNullOrWhiteSpace(imePolaznika))
        {
            return (false,"validacija.polaznik_prazan","Ime polaznika ne sme biti prazno.");
        }
        var polaznik=Polaznici.FirstOrDefault(p=>p.ImePolaznika.Equals(imePolaznika.Trim(),StringComparison.OrdinalIgnoreCase));

        if(polaznik is null)
        {
            return (false,"odsustvo.nije_upisan","Polaznik nije upisan na ovaj cas.");
        }   
        if(polaznik.Status==StatusPolaznika.Prisutan)
        {
            return(false,"odsustvo.vec_prisutan","Nije moguce opravdati odsustvo polazniku koji je vec bio  prisutan.");
        }
        if(polaznik.Status==StatusPolaznika.OpravdanoOdsutan)
        {
            return(false,"odsustvo.vec_opravdano","Odsustvo za ovog polaznika je vec opravdano.");
        }
        polaznik.Status=StatusPolaznika.OpravdanoOdsutan;
        OsveziStatusZapisa();
        return (true,string.Empty,string.Empty);
    }
    public void PostaviStatus(StatusObrade status)=>Status=status;
    private void OsveziStatusZapisa()
    {
        if(Polaznici.Count>0 && Polaznici.All(p=>p.Status !=StatusPolaznika.Upisan))
        {
            Status=StatusObrade.Zavrsen;
        }
        else if(Polaznici.Any(p=>p.Status != StatusPolaznika.Upisan))
        {
            Status=StatusObrade.UObradi;
        }
    }
}