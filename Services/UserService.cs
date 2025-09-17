using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserService : IUser
{
    //Inyectar el contexto de la base de dato
    private readonly SafpContext _context;
    //Inyectar servicio para hash
    private readonly PasswordHasher<object> _passwordHasher;
    //Constructor
    public UserService(SafpContext safpContext)
    {
        _context = safpContext;
        _passwordHasher = new PasswordHasher<object>();
    }
    public async Task<User> GetUser(User user)
    {
        try
        {
            User userExist = await _context.Users.FirstOrDefaultAsync(u => u.username == user.username);
            if (userExist is null)
            {
                return null;
            }
            var result = _passwordHasher.VerifyHashedPassword(null, userExist.password, user.password);
            if (result != PasswordVerificationResult.Success)
            {
                return null;
            }
            return userExist;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    //Método para crear un nuevo usuario
    public async Task<User> PostUser(User user)
    {
        try
        {
            if (user.username.Equals("") || user.password.Equals(""))
            {
                return null;
            }
            string hashPassword = _passwordHasher.HashPassword(null, user.password);
            User userCreated = new User(user.username, hashPassword);
            _context.Users.Add(userCreated);
            await _context.SaveChangesAsync();
            return userCreated;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}