public class Topla
{
    public int Hesapla(int x, int y) {
       
        return x + y;


    }
}

public class Yazdir
{
    public void EkranaYaz(string mesaj)
    {
        Console.WriteLine(mesaj);
    }
}

public class program
{
    public static void Main(string[] args) { 
        
        Topla topla = new Topla();
        int sonuc = topla.Hesapla(15, 28);

        Yazdir yazdir = new Yazdir();
        yazdir.EkranaYaz("Toplamın Sanocu:" + sonuc);

        Console.ReadLine();

        
    }
}