namespace PandaPe.Data.Models.Base
{
    public class EntityBase<TId> : EntityWithTypedId<TId>
    {
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public EntityBase()
        {
            InsertDate = DateTime.UtcNow;
            ModifyDate = DateTime.UtcNow;
        }
    }
}
