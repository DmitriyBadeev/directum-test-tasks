using DataAccess;
using DataAccess.Models;

Console.WriteLine("Start testing db...");
await TestDb();

async Task TestDb()
{
    using var dbContext = new MessagesDbContext();

    Console.WriteLine("-------------");
    
    Console.WriteLine("Создание пользователей");
    
    var user1 = new User { Name = "Дмитрий", Password = "123", State = State.Online };
    var user2 = new User { Name = "Даниил", Password = "12345", State = State.Online };

    var userId1 = await dbContext.Users.AddUser(user1);
    var userId2 = await dbContext.Users.AddUser(user2);
    
    Console.WriteLine($"Пользователи с id = {userId1}, {userId2} созданы");

    var userById = await dbContext.Users.GetById(userId1);
    var userByName = await dbContext.Users.GetByName("Дмитрий");
    var searchUser = await dbContext.Users.SearchByName("мит");
    
    Console.WriteLine($"Получение пользователя по id = {userId1}: {userById?.Name}");
    Console.WriteLine($"Получение пользователя по имени = \"Дмитрий\": {userByName?.Id}");
    Console.WriteLine($"Поиск пользователя по строке = \"мит\": {string.Join(", ", searchUser.Select(u => u.Name))}");
    
    
    Console.WriteLine("Обновление статуса пользователя на offline");
    
    var userWithOldState = await dbContext.Users.GetById(userId1);
    userWithOldState!.State = State.Offline;
    await dbContext.Users.UpdateUser(userWithOldState);
    var userWithNewState = await dbContext.Users.GetById(userId1);
    
    Console.WriteLine($"Обновленный статус пользователя: {userWithNewState?.State}");
    
    
    Console.WriteLine("-------------");
    
    Console.WriteLine("Создание контакта между пользователями");

    var contact = new Contact { UserId = userId1, ContactUserId = userId2 };
    await dbContext.Contacts.AddContact(contact);
    
    Console.WriteLine("Контакт создан");
    
    Console.WriteLine($"Список контактов пользователя с id = {userId1}");
    var contacts = await dbContext.Contacts.GetContactList(userId1);
    Console.WriteLine(string.Join(", ", contacts.Select(c => c.ContactUser.Name)));
    
    
    Console.WriteLine("Поиск контакта по имени Дан");
    var searched = await dbContext.Contacts.SearchByName(userId1, "Дан");
    Console.WriteLine(string.Join(", ", searched.Select(c => c.ContactUser.Name)));

    Console.WriteLine("Обновление времени последней беседы");
    var firstContact = contacts.First();
    firstContact.LastUpdateTime = DateTime.Now.ToUniversalTime();
    await dbContext.Contacts.UpdateContact(firstContact);
    var updatedFirstContact = (await dbContext.Contacts.GetContactList(userId1)).First();
    Console.WriteLine($"Обновленное временя последней беседы: {updatedFirstContact.LastUpdateTime}");
    
    Console.WriteLine("Удаление контактов");
    var allContacts = await dbContext.Contacts.GetContactList(userId1);

    Console.WriteLine($"Кол-во контактов до удаления: {allContacts.Count}");
    foreach (var contactToRemove in allContacts.ToList())
    {
        await dbContext.Contacts.RemoveContact(contactToRemove);
    }
    
    var allContactsAfter = await dbContext.Contacts.GetContactList(userId1);
    Console.WriteLine($"Кол-во контактов после удаления: {allContactsAfter.Count}");
    
    
    Console.WriteLine("-------------");
    
    Console.WriteLine("Создание сообщений");
    var message1 = new Message { UserId = userId1, ReceiveUserId = userId2, Content = "Привет, Даниил"};
    var message2 = new Message { UserId = userId2, ReceiveUserId = userId1, Content = "Привет, Дмитрий"};
    var message3 = new Message { UserId = userId2, ReceiveUserId = userId1, Content = "Как дела?"};
    
    await dbContext.Messages.AddMessage(message1);
    await dbContext.Messages.AddMessage(message2);
    await dbContext.Messages.AddMessage(message3);
    
    Console.WriteLine("Получение сообщений");
    
    var messages1 = await dbContext.Messages.GetUserMessages(userId1);
    var messages2 = await dbContext.Messages.GetUserMessages(userId2);
    
    Console.WriteLine($"Сообщения Дмитрия: {string.Join("; ", messages1.Select(m => m.Content))}");
    Console.WriteLine($"Сообщения Даниила: {string.Join("; ", messages2.Select(m => m.Content))}");
    
    
    Console.WriteLine("Поиск по сообщениям Дмитрия: дел");
    var searchedMessages = await dbContext.Messages.SearchMessagesByContent(userId1, "дел");
    Console.WriteLine($"Найденные сообщения: {string.Join("; ", searchedMessages.Select(m => m.Content))}");

}
