public class Program {
  public static void Main() {
    //Instantiate
    FullTimeEmployee fullTime = new FullTimeEmployee(0, "Jana Jansen", "Math", 60000, 12000);
    PartTimeEmployee partTime = new PartTimeEmployee(1, "Scott Pilgrim", "Janitorial", new decimal(14.501), 80);
    Contractor contracted = new Contractor(2, "Dale Dimmadome", "Construction", 120000, new DateTime(2025, 2, 27), false);


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