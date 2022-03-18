namespace Domain.Base
{
    public abstract class BaseModel
    {
    }

    public abstract class BaseModel<TID> : BaseModel
    {
        public TID Id { get; set; } = default!;
    }
}
