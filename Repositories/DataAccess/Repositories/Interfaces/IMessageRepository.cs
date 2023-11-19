using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

/// <summary>
/// Репозиторий для доступа к сообщениям пользователей
/// </summary>
public interface IMessageRepository
{
    /// <summary>
    /// Получение списка сообщений пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Список сообщений</returns>
    Task<IReadOnlyList<Message>> GetUserMessages(long userId);

    /// <summary>
    /// Поиск сообщения по строке в списке сообщений пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="searchTerm">Поисковая строка</param>
    /// <returns>Список сообщений</returns>
    Task<IReadOnlyList<Message>> SearchMessagesByContent(long userId, string searchTerm);

    /// <summary>
    /// Добавление нового сообщения
    /// </summary>
    /// <param name="message">Модель сообщения</param>
    Task AddMessage(Message message);
}