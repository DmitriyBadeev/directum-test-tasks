using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

/// <inheritdoc />
internal class MessageRepository : IMessageRepository
{
    private readonly ApplicationEfContext _efContext;

    public MessageRepository(ApplicationEfContext efContext)
    {
        _efContext = efContext;
    }

    public async Task<IReadOnlyList<Message>> GetUserMessages(long userId)
    {
        var user = await GetUserWithMessages(userId);
        return user?.ReceiveMessages.AsReadOnly() ?? new List<Message>().AsReadOnly();
    }

    public async Task<IReadOnlyList<Message>> SearchMessagesByContent(long userId, string searchTerm)
    {
        var messages = await GetUserMessages(userId);

        return messages
            .Where(message => message.Content.Contains(searchTerm))
            .ToList()
            .AsReadOnly();
    }

    public async Task AddMessage(Message message)
    {
        await _efContext.Messages.AddAsync(message);
        await _efContext.SaveChangesAsync();
    }
    
    private async Task<User?> GetUserWithMessages(long userId)
    {
        return await _efContext.Users
            .Include(user => user.SendMessages)
            .Include(user => user.ReceiveMessages)
            .FirstOrDefaultAsync(user => user.Id == userId);
    }
}