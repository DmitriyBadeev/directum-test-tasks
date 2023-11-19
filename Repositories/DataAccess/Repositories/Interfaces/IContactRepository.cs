using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

/// <summary>
/// Репозиторий для доступа к данным контактов пользователей
/// </summary>
public interface IContactRepository
{
    /// <summary>
    /// Получение контакта пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя-владельца контакта</param>
    /// <param name="contactUserId">Идентификатор пользователя, на который ссылается контакт</param>
    /// <returns>Модель контакта</returns>
    Task<Contact?> GetUserContact(long userId, long contactUserId);

    /// <summary>
    /// Получение списка контактов пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Список контактов</returns>
    Task<IReadOnlyList<Contact>> GetContactList(long userId);

    /// <summary>
    /// Поиск контакта по имени в списке контактов пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="searchTerm">Поисковая строка</param>
    /// <returns>Список контактов, удовлетворяющих поисковой строке</returns>
    Task<IReadOnlyList<Contact>> SearchByName(long userId, string searchTerm);

    /// <summary>
    /// Добавление нового контакта
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="contact">Модель контакта</param>
    Task AddContact(Contact contact);

    /// <summary>
    /// Обновление данных контакта
    /// </summary>
    /// <param name="contact">Модель контакта</param>
    Task UpdateContact(Contact contact);

    /// <summary>
    /// Удаление контакта
    /// </summary>
    /// <param name="contact">Модель контакта</param>
    Task RemoveContact(Contact contact);
}