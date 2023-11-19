namespace DataAccess.Models;

/// <summary>
/// Модель сообщения пользователя
/// </summary>
public class Message
{
    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// ИД пользователя, отправившего сообщение
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Пользователь, отправивший сообщение
    /// </summary>
    public User User { get; set; } = default!;
    
    /// <summary>
    /// ИД пользователя, получившего сообщение
    /// </summary>
    public long ReceiveUserId { get; set; }
    
    /// <summary>
    /// Пользователь, получивший сообщение
    /// </summary>
    public User ReceiveUser { get; set; } = default!;
    
    /// <summary>
    /// Дата и время отправки сообщения
    /// </summary>
    public DateTime LastUpdateTime { get; set; }
    
    /// <summary>
    /// Дата и время получения сообщения
    /// </summary>
    public DateTime DeliveryTime { get; set; }
    
    /// <summary>
    /// Текст сообщения
    /// </summary>
    public string Content { get; set; } = default!;
}