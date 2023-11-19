namespace DataAccess.Models;

/// <summary>
/// Модель с данными пользователя
/// </summary>
public class User
{
    /// <summary>
    /// ИД пользователя
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; } = default!;

    /// <summary>
    /// Состояние пользователя: онлайн, офлайн
    /// </summary>
    public string State { get; set; } = default!;

    /// <summary>
    /// Список контактов пользователя
    /// </summary>
    public List<Contact> Contacts { get; set; } = default!;

    /// <summary>
    /// Контакты, которые ссылаются на пользователя
    /// </summary>
    public List<Contact> LinkedContacts { get; set; } = default!;
    
    /// <summary>
    /// Список сообщений, отправленных пользователем
    /// </summary>
    public List<Message> SendMessages { get; set; } = default!;
    
    /// <summary>
    /// Список сообщений, полученных пользователем
    /// </summary>
    public List<Message> ReceiveMessages { get; set; } = default!;
}

public static class State
{
    public const string Online = "Online";
    public const string Offline = "Offline";
}