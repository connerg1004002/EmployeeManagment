public class Program {
  public static void Main() {
    //Instantiate
    FullTimeEmployee fullTime = new FullTimeEmployee("Jana Jansen", 0, "Math", 60000, 12000);
    PartTimeEmployee partTime = new PartTimeEmployee("Scott Pilgrim", 1, "Janitorial", new decimal(14.5), 80);
    Contractor contracted = new Contractor("Dale Dimmadome", 2, "Construction", 120000, new DateTime(2025, 2, 27), false);


    //Print info
    Console.WriteLine(fullTime);
    Console.WriteLine();
    Console.WriteLine(partTime);
    Console.WriteLine();
    Console.WriteLine(contracted);
    Console.WriteLine();
    Console.WriteLine();


    //Print their expected pay
    Console.WriteLine($"{fullTime.Name} should be payed {fullTime.CalculatePay(null)}\n");
    Console.WriteLine($"{partTime.Name} should be payed {partTime.CalculatePay(null)}\n");
    Console.WriteLine($"{contracted.Name} should be payed {contracted.CalculatePay(new DateTime(2025, 2, 28))}\n");
  }
};