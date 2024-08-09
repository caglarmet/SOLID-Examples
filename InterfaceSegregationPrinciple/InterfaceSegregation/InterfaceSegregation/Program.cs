public interface IPrint
{
    void Print(string content);
   
}

public interface IScan
{
    void Scan(string content);
}

public interface IFax
{
    void Fax (string content);
}

// Temel Yazıcı sınıfı sadece Print Metodunu kullanacak
public class BasicPrinter : IPrint 
{ 
    public void Print(string content)
    {
        Console.WriteLine("Yazdırılıyor: " + content);
    }
}

// Çok işlevli Yazıcı Tüm Özellikleri kullanacaktır.
public class MultiFunctionPrinter : IPrint, IScan, IFax
{
    public void Print(String content)
    {
        Console.WriteLine ("Yazdırılıyor: " + content);
    }

    public void Scan(String content)
    {
        Console.WriteLine("Taranıyor: " + content);
    }

    public void Fax (String content) 
    { 
        Console.WriteLine ( "Fax Gönderiliyor: " + content);
        
    }
}

public class Program
{
    public static void Main (string[] args)
    {
        //Basit Printer Çalışacak
        IPrint basicPrinter = new BasicPrinter();
        basicPrinter.Print ("Basit Yazıcı İle Yazdırılıyor");

        //MultiFuntion Printer ÇalışacakI
        IPrint multiFunctionPrinter = new MultiFunctionPrinter();
        multiFunctionPrinter.Print("Çok İşlevli Printer ile Yazdırılıyor ");

        IScan multiFunctionalScan = new MultiFunctionPrinter();
        multiFunctionalScan.Scan("Belge Çok İşlevli Printer ile Taranıyor");

        IFax multiFunctionFax = new MultiFunctionPrinter();
        multiFunctionFax.Fax("Çok İşlevli Fax ile Fax Gönderiliyor. ");

        Console.ReadLine();
    }
}