public interface IMessageSender
{
    public void Send(string message);
}

// E-Posta Gönderme Sınıfı
public class EmailSender : IMessageSender
{ 
    public void Send(string message)
    {
        Console.WriteLine("E-Posta Gönderiliyor" + message);
    } 
}

// Sms Gönderme Sınıfı
public class SmsSender : IMessageSender
{
    public void Send (string message)
    {
        Console.WriteLine ("Sms Gönderiliyor" +  message);
    }
}

public class MessageService
{
    private readonly IMessageSender _messageSender;
    public MessageService (IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }
    public void Send(string message)
    { 
        _messageSender.Send(message);
    }
}

public class Program
{
    public static void Main (string[] args)
    {
        IMessageSender emailSender = new EmailSender();
        MessageService emailService = new MessageService(emailSender);
        emailService.Send(" \nMerhaba, bu bir e-posta mesajıdır!\n");

        IMessageSender smsSender = new SmsSender();
        MessageService smsService = new MessageService(smsSender);
        smsService.Send(" \nMerhaba, bu bir SMS mesajıdır!");

        Console.ReadLine();
    }
}