using Domain.Models;
namespace Domain.Validation;
public sealed class ZapisValidator
{
    public const int MinTrajanjeMinuta=20;
    public const int MaxTrajanjeMinuta=90;
    public const int MinGrupniPolazak=2;
    public const int MaxGrupniPolaznika=15;
    public(bool IsValid,string Code,string Message)Validiraj(Zapis? zapis)
    {
        if(zapis is null)
        {
            return(false,"validacija.null_zapis","Zapis ne sme biti null.");
        }
        if(string.IsNullOrWhiteSpace(zapis.Naziv))
        {
            return(false,"validacija.naziv_prazan","Naziv casa ne sme biti prazan.");
        }
        if(string.IsNullOrWhiteSpace(zapis.Opis))
        {
            return(false,"validacija.opis_prazan","Opis casa ne sme biti prazan");
        }
        if(zapis.TrajanjeMinuta<MinTrajanjeMinuta || zapis.TrajanjeMinuta>MaxTrajanjeMinuta)
        {
            return(false,"validacija.trajanje_neispravno",$"Trajanje casa mora biti izmedju {MinTrajanjeMinuta} i {MaxTrajanjeMinuta} minuta.");
        }
        if(zapis.Polaznici is null || zapis.Polaznici.Any(p=>string.IsNullOrWhiteSpace(p.ImePolaznika)))
        {
            return(false,"validacija.polaznik_prazan","Svi polaznici moraju imati uneto ime.");
        }
        var jedinstvenaImena=zapis.Polaznici.Select(p=>p.ImePolaznika.Trim().ToLowerInvariant()).Distinct().Count();
        if(jedinstvenaImena!=zapis.Polaznici.Count)
        {
            return(false,"validacija.duplikat_polaznika","Ime polaznika na istom casu moraju biti jedinstvena.");
        }
        switch(zapis)
        {
            case IndividualniCas ind:
                if(string.IsNullOrWhiteSpace(ind.ImeInstruktora))
                {
                    return(false,"validacija.instruktor_prazan","Ime instruktora je obavezno za indivvidualni cas.");
                }
                if(ind.Polaznici.Count!=1)
                {
                    return(false,"validacija.individualni_broj_polaznika","Individualni cas mora imati tacno jednog polaznika.");
                }
            break;
            case GrupniCas grp:
                if(grp.BrojPolaznika<MinGrupniPolazak || grp.BrojPolaznika>MaxGrupniPolaznika)
                {
                    return(false,"validacija.grupni_broj_polaznika",$"Grupni cas mora imati izmedju {MinGrupniPolazak} i {MaxGrupniPolaznika} polaznika.");
                }
                if(grp.Polaznici.Count!=grp.BrojPolaznika)
                {
                    return(false,"validacija.grupni_polaznici_nepoklapanje","Broj unetih polaznika mora odgovarati zadatom broju polaznika.");
                }
            break;
            default:
                return(false,"validacija.nepoznati_tip","Nepoznat tip zapisa.");
        }
        return (true,string.Empty,string.Empty);
    }
}