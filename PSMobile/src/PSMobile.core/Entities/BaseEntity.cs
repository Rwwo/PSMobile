using System.Globalization;

namespace PSMobile.core.Entities;
public abstract class BaseEntity: Entity
{
    public abstract void Deletar();
    public abstract void ReAtivar();

}

public abstract class Entity
{

}

public abstract class InputModel
{
    public CultureInfo _ptBR = CultureInfo.GetCultureInfo("pt-BR");
}
