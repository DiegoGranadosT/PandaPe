namespace PandaPe.Data.Models.Base
{
    public abstract class EntityWithTypedId<TId> : IEntityWithTypedId<TId>
    {
        public TId Id { get; set; }
    }
}
