public interface IUser
{
    public Task<User> GetUser(User user);
    public Task<User> PostUser(User user);
}