using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

/// <summary>
/// Репозиторий для доступа к данным пользователей
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Получения пользователя по ИД
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Модель пользователя</returns>
    Task<User?> GetById(long userId);
    
    /// <summary>
    /// Получения пользователя по имени
    /// </summary>
    /// <param name="userName">Имя пользователя</param>
    /// <returns>Модель пользователя</returns>
    Task<User?> GetByName(string userName);

    /// <summary>
    /// Поиск по имени
    /// </summary>
    /// <param name="searchTerm">Поисковый запрос</param>
    /// <returns>Список моделей пользователей</returns>
    Task<IReadOnlyList<User>> SearchByName(string searchTerm);

    /// <summary>
    /// Добавление нового пользователя 
    /// </summary>
    /// <param name="user">Модель пользователя</param>
    /// <returns>Идентификатор пользователя</returns>
    Task<long> AddUser(User user);

    /// <summary>
    /// Обновление данных пользователя
    /// </summary>
    /// <param name="user">Модель пользователя</param>
    Task UpdateUser(User user);
}