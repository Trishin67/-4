using System;

class Wizard
{
    public string Name { get; set; }
    public int Mana { get; set; }

    public Wizard(string name, int mana)
    {
        Name = name;
        Mana = mana;
    }

    public void CastSpell(string spellName, int requiredMana)
    {
        if (Mana >= requiredMana)
        {
            Console.WriteLine($"{Name} колдует! {spellName}");
            Mana -= requiredMana;
        }
        else
        {
            int manaNeeded = requiredMana - Mana;
            Console.WriteLine($"Для использования {spellName} не хватает {manaNeeded} единиц маны. Хлебните зелья!");
        }
    }
}

class Package
{
    public string Description { get; set; }
    public double Weight { get; set; }

    public Package(string description, double weight)
    {
        Description = description;
        Weight = weight;
    }
}

class ShippingService
{
    private double weightLimit;
    private double totalWeightSent;

    public ShippingService(double limit)
    {
        weightLimit = limit;
        totalWeightSent = 0;
    }

    public void SendPackage(Package package)
    {
        if (totalWeightSent + package.Weight <= weightLimit)
        {
            Console.WriteLine($"Посылка отправлена: {package.Description}, Вес: {package.Weight} кг");
            totalWeightSent += package.Weight;
        }
        else
        {
            Console.WriteLine("Превышен лимит веса для отправки посылок.");
        }
    }
}

class Orc
{
    public static int GoldCarriedByAllOrcs { get; private set; }
    public int GoldCarried { get; private set; }

    public Orc()
    {
        GoldCarriedByAllOrcs += 2;
        if (GoldCarriedByAllOrcs > 5)
        {
            GoldCarriedByAllOrcs -= 2;
            GoldCarried = 0;
        }
        else
        {
            GoldCarried = 2;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Задача 1: Волшебник и заклинания");
        Wizard wizard = new Wizard("Гарри", 10);
        wizard.CastSpell("Огненный шар", 5);
        wizard.CastSpell("Ледяная стрела", 15);

        Console.WriteLine("\nЗадача 2: Посылки и сервис отправки");
        ShippingService shippingService = new ShippingService(10);
        Package package1 = new Package("Книга", 1.5);
        Package package2 = new Package("Электроника", 3.0);

        shippingService.SendPackage(package1);
        shippingService.SendPackage(package2);

        Console.WriteLine("\nЗадача 3: Орки и золото");
        Orc orc1 = new Orc();
        Orc orc2 = new Orc();
        Orc orc3 = new Orc();
        Orc orc4 = new Orc();
        Orc orc5 = new Orc();
        Orc orc6 = new Orc();

        Console.WriteLine($"Золото, переносимое всеми орками: {Orc.GoldCarriedByAllOrcs}");
    }
}