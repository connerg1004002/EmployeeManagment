[TestClass]
public class EmployeeManagementTests {
  //Full time tests
  [TestMethod]
  public void CalculatePay_ShouldReturnBaseSalaryPlusAnnualBonus() {
    FullTimeEmployee fullTime = new FullTimeEmployee("Jana Jansen", 0, "Math", 60000, 12000);

    decimal result = fullTime.CalculatePay(null);

    Assert.AreEqual(fullTime.BaseSalary + fullTime.AnnualBonus, result);
  }

  [TestMethod]
  public void CalculatePay_ShouldReturnOnlyBaseSalary_WhenAnnualBonusIsZero() {
    FullTimeEmployee fullTime = new FullTimeEmployee("Jana Jansen", 0, "Math", 60000, 0);

    decimal result = fullTime.CalculatePay(null);

    Assert.AreEqual(fullTime.BaseSalary, result);
  }


  //Part time tests
  [TestMethod]
  public void CalculatePay_ShouldReturnCorrectAmount_WhenGivenHourlyRateAndHours() {
    PartTimeEmployee partTime = new PartTimeEmployee("Scott Pilgrim", 1, "Janitorial", new decimal(14.50), 80);

    decimal result = partTime.CalculatePay(null);

    Assert.AreEqual(partTime.HourlyRate * partTime.HoursWorked, result);
  }

  [TestMethod]
  public void CalculatePay_ShouldReturnZero_WhenHoursWorkedIsZero() {
    PartTimeEmployee partTime = new PartTimeEmployee("Scott Pilgrim", 1, "Janitorial", new decimal(14.50), 0);

    decimal result = partTime.CalculatePay(null);

    Assert.AreEqual(0, result);
  }


  //Contractor tests
  [TestMethod]
  public void CalculatePay_ShouldReturnCorrectAmountForContractor() {
    Contractor contracted = new Contractor("Dale Dimmadome", 2, "Construction", 120000, new DateTime(2025, 2, 27), false);

    decimal onPayday = contracted.CalculatePay(new DateTime(2025, 2, 27));
    contracted.WasPayed = false;

    decimal pastPayday = contracted.CalculatePay(new DateTime(2025, 4, 2));
    contracted.WasPayed = false;

    decimal beforePayday = contracted.CalculatePay(new DateTime(2025, 1, 16));

    contracted.WasPayed = true;
    decimal pastPaydayAlreadyPayed = contracted.CalculatePay(new DateTime(2025, 3, 3));


    Assert.AreEqual(120000, onPayday);
    Assert.AreEqual(120000, pastPayday);
    Assert.AreEqual(0, beforePayday);
    Assert.AreEqual(0, pastPaydayAlreadyPayed);
  }


  //ToString tests
  [TestMethod]
  public void ToString_ShouldReturnCorrectFormat() {
    Employee employee = new Employee("Wall-E", 4, "Trash", 3);

    string result = employee.ToString();

    Assert.AreEqual("Name: Wall-E, ID: 4, Department: Trash, BaseSalary: 3", result);
  }

  [TestMethod]
  public void ToString_ShouldIncludeAnnualBonus() {
    FullTimeEmployee fullTime = new FullTimeEmployee("Jana Jansen", 0, "Math", 60000, 12000);

    string result = fullTime.ToString();

    Assert.AreEqual("Full time, Name: Jana Jansen, ID: 0, Department: Math, BaseSalary: 60000, AnnualBonus: 12000", result);
  }

  [TestMethod]
  public void ToString_ShouldIncludeHourlyRateAndHoursWorked() {
    PartTimeEmployee partTime = new PartTimeEmployee("Scott Pilgrim", 1, "Janitorial", new decimal(14.5), 80);

    string result = partTime.ToString();

    Assert.AreEqual("Part time, Name: Scott Pilgrim, ID: 1, Department: Janitorial, HourlyRate: 14.5, HoursWorked: 80", result);
  }

  [TestMethod]
  public void ToString_ShouldIncludeContractExpiryDate() {
    Contractor contracted = new Contractor("Dale Dimmadome", 2, "Construction", 120000, new DateTime(2025, 2, 27), false);

    string result = contracted.ToString();

    Assert.AreEqual("Contracted, Name: Dale Dimmadome, ID: 2, Department: Construction, BaseSalary: 120000, ContractExpiryDate: 2/27/2025, WasPayed: False", result);
  }
}
