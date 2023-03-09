namespace Contract
{
    public interface IRepositoryMenager 
    {
        IUserRepository User { get; }
        Task SaveAsync();
    }
}
