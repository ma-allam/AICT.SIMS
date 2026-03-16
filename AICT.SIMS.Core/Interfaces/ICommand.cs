namespace AICT.SIMS.Core.Interfaces
{
    public interface ICommand<Input, Output>
    {
        Task<Output> HandleAsync(Input input);
    }
}
