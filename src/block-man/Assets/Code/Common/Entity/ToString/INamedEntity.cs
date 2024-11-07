using Entitas;

namespace Code.Common.Entity.ToString
{
    public interface INamedEntity: IEntity
    {
        string EntityName(IComponent[] components);
        string BaseToString();
    }
}