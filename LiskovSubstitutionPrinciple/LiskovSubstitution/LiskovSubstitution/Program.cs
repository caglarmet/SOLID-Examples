public class Car
{
    public virtual void StartEngine()
    {
        Console.WriteLine("Araba Motoru Çalıştırılıyor...");
    }
    public virtual void Drive()
    {
        Console.WriteLine("Araba İlerliyor...");
    }
}

public class ElectricCar : Car
{
    public override void StartEngine()
    {
        Console.WriteLine("Motor Sessiz Çalışıyor");
    }

    public override void Drive()
    {
        Console.WriteLine("Araç Sessiz ilerliyor");
    }
}

public class GasolineCar : Car 
{
    public override void StartEngine()
    {
        Console.WriteLine("Benzinli Araba Motoru Çalıştırılıyor");
    }

    public override void Drive()
    {
        Console.WriteLine("Benzinli araba ses çıkartarak ilerliyor");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Car myElectricCar = new GasolineCar();
        myElectricCar.StartEngine();
        myElectricCar.Drive();

        Car myGasolineCar = new ElectricCar(); 
        myGasolineCar.StartEngine();
        myGasolineCar.Drive();

        Console.ReadLine();
    }
}