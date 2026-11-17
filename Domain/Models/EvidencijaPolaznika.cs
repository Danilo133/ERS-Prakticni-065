using Domain.Enums;

namespace Domain.Models;

public sealed class EvidencijaPolaznika
{
    public string ImePolaznika{ get ; init ;}=string.Empty;
    public StatusPolaznika Status{ get ; set ;}=StatusPolaznika.Upisan;

    public EvidencijaPolaznika(){}

    public EvidencijaPolaznika(string imePolaznika,StatusPolaznika status=StatusPolaznika.Upisan)
    {
        ImePolaznika=imePolaznika;
        Status=status;
    }
}