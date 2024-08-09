public abstract class CreditCalculate
{
    public abstract double CalculateInterest(double principle, int month);
}

public class Individual : CreditCalculate
{
    private readonly double rate = 1.89;
    public override double CalculateInterest(double principle,  int month)
    {
        return (principle  * month);
    }
}

public class Home : CreditCalculate 
{
    private readonly double rate = 0.32;
    public override double CalculateInterest(double principle, int month)
    {
        return (principle * rate * month);
    }
}

public class Car : CreditCalculate
{
    private readonly double rate = 0.79;
    public override double CalculateInterest(double principle, int month)
    {
        return (principle * rate * month);
    }
}

public class Education : CreditCalculate 
{
    private readonly double rate = 0.88;
    public override double CalculateInterest(double principle, int month)
    {
        return (principle * rate * month);
    }
}

public class program
{
    public static void Main(string[] args)
    {
        CreditCalculate individual = new Individual();
        CreditCalculate car = new Car();
        CreditCalculate home = new Home();
        CreditCalculate education = new Education();

        double individualInterest = individual.CalculateInterest(1000000, 48);
        double carInterest = car.CalculateInterest(80000, 5);
        double homeInterest = home.CalculateInterest(2000000, 60);
        double educationInterest = education.CalculateInterest(100000, 6);

        Console.WriteLine("Bireysel Kredi Faizi: " + individualInterest);
        Console.WriteLine("Araba Kredi Faizi: " + carInterest);
        Console.WriteLine("Ev Kredi Faizi: " + homeInterest);
        Console.WriteLine("Öğrenim Kredi Faizi:" + educationInterest);


    }
}