namespace HB_MarsRover.Data.Interfaces
{
    public interface IBaseModel<T> where T : notnull
    {
        T Id { get; set; }
    }
}