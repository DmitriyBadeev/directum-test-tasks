using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;

namespace DataAccess;

public class MessagesDbContext : IMessagesDbContext
{
    private readonly ApplicationEfContext _context = new();

    public IContactRepository Contacts { get; }
    public IUserRepository Users { get; }
    public IMessageRepository Messages { get; }

    public MessagesDbContext()
    {
        Users = new UserRepository(_context);
        Contacts = new ContactRepository(_context);
        Messages = new MessageRepository(_context);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}