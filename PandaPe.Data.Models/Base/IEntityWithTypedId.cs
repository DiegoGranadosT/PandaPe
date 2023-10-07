namespace PandaPe.Data.Models.Base
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
