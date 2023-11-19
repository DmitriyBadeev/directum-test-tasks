namespace DataAccess.Models;

/// <summary>
/// Модель с данными о контактах пользователя
/// </summary>
public class Contact
{
    /// <summary>
    /// Идентификатор контакта
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// ИД пользователя, владельца контакта
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Пользователь, владелец контакта
    /// </summary>
    public User User { get; set; } = default!;

    /// <summary>
    /// ИД пользователя, на который ссылается контакт
    /// </summary>
    public long ContactUserId { get; set; }
    
    /// <summary>
    /// Пользователь, на который ссылается контакт
    /// </summary>
    public User ContactUser { get; set; } = default!;

    /// <summary>
    /// Дата и время последней беседы с контактом
    /// </summary>
    public DateTime LastUpdateTime { get; set; }
}