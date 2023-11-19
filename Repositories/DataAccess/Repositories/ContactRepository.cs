using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

/// <inheritdoc />
internal class ContactRepository : IContactRepository
{
    private readonly ApplicationEfContext _efContext;

    public ContactRepository(ApplicationEfContext efContext)
    {
        _efContext = efContext;
    }

    public async Task<Contact?> GetUserContact(long userId, long contactUserId)
    {
        var user = await GetUserWithContacts(userId);

        return user?.Contacts.Find(contact => contact.ContactUserId == contactUserId);
    }

    public async Task<IReadOnlyList<Contact>> GetContactList(long userId)
    {
        var user = await GetUserWithContacts(userId);
        
        return user?.Contacts.AsReadOnly() ?? new List<Contact>().AsReadOnly();
    }

    public async Task<IReadOnlyList<Contact>> SearchByName(long userId, string searchTerm)
    {
        var user = await GetUserWithContacts(userId);

        return user?.Contacts
                .Where(c => c.ContactUser.Name.Contains(searchTerm))
                .ToList()
                .AsReadOnly() 
            ?? new List<Contact>().AsReadOnly();
    }

    public async Task AddContact(Contact contact)
    {
        await _efContext.Contacts.AddAsync(contact);
        await _efContext.SaveChangesAsync();
    }

    public async Task UpdateContact(Contact contact)
    {
        _efContext.Contacts.Update(contact);
        await _efContext.SaveChangesAsync();
    }

    public async Task RemoveContact(Contact contact)
    {
        _efContext.Contacts.Remove(contact);
        await _efContext.SaveChangesAsync();
    }

    private async Task<User?> GetUserWithContacts(long userId)
    {
        return await _efContext.Users
            .Include(user => user.Contacts)
            .ThenInclude(contact => contact.ContactUser)
            .FirstOrDefaultAsync(user => user.Id == userId);
    }
}