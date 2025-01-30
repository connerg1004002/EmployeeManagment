//Abstract employee class
public abstract class Employee {
  //Private variables exposed by public variables

  private int _id;
  private string _name;
  private string _department;
  private decimal _baseSalary;

  //The public variables
  public int ID { get => _id; set => _id = value; }
  public string Name { get => _name; set => _name = value; }
  public string Department { get => _department; set => _department = value; }
  public decimal BaseSalary { get => _baseSalary; set => _baseSalary = value; }


  //Normal virtual functions
  public virtual decimal CalculatePay(DateTime? date) {
    return BaseSalary;
  }

  public override string ToString() {
    return $"Employee {Name} has ID {ID} in department {Department}, with a salary of {BaseSalary}";
  }
  
  public virtual void DisplayEmployeeDetails() {
    Console.WriteLine(this.ToString());
  }
}


//Full time gets a bonus as well
public class FullTimeEmployee : Employee {
  private decimal _annualBonus;

  public decimal AnnualBonus { get => _annualBonus; set => _annualBonus = value; }


  //Constructor
  public FullTimeEmployee(int id, string name, string department, decimal baseSalary, decimal annualBonus) {
    ID = id;
    Name = name;
    Department = department;
    BaseSalary = baseSalary;
    AnnualBonus = annualBonus;
  }


  //Add bonus to pay
  public override decimal CalculatePay(DateTime? date) {
    return BaseSalary + AnnualBonus;
  }

  public override string ToString() {
    return $"Full time employee {Name} has ID {ID} in department {Department}, with a salary of {BaseSalary} and annual bonus of {AnnualBonus}";
  }
};


//Part time are payed hourly
public class PartTimeEmployee : Employee {
  private decimal _hourlyRate;
  private int _hoursWorked;

  public decimal HourlyRate { get => _hourlyRate; set => _hourlyRate = value; }
  public int HoursWorked { get => _hoursWorked; set => _hoursWorked = value; }


  //Constructor
  public PartTimeEmployee(int id, string name, string department, decimal hourlyRate, int hoursWorked) {
    ID = id;
    Name = name;
    Department = department;
    HourlyRate = hourlyRate;
    HoursWorked = hoursWorked;
  }


  //Convert pay to hourly
  public override decimal CalculatePay(DateTime? date) {
    return HoursWorked * HourlyRate;
  }

  public override string ToString() {
    return $"Part time employee {Name} has ID {ID} in department {Department}, with an hourly rate of {HourlyRate} and has worked {HoursWorked} hours";
  }
};



//Contracted employee payed by the contract
public class Contractor : Employee {
  private DateTime _contractExpiryDate;
  private bool _wasPayed;

  public DateTime ContractExpiryDate { get => _contractExpiryDate; set => _contractExpiryDate = value; }
  public bool WasPayed { get => _wasPayed; set => _wasPayed = value; }


  //Constructor
  public Contractor(int id, string name, string department, decimal baseSalary, DateTime contractExpiryDate, bool wasPayed) {
    ID = id;
    Name = name;
    Department = department;
    BaseSalary = baseSalary;
    ContractExpiryDate = contractExpiryDate;
    WasPayed = wasPayed;
  }


  //If date is on expiration date or after, pay them.
  //If not then no pay
  public override decimal CalculatePay(DateTime? date) {
    if (date == null)
      return 0;

    if (!WasPayed && date >= ContractExpiryDate) {
      WasPayed = true;
      return BaseSalary;
    }
    return 0;
  }

  public override string ToString() {
    return $"Contracted employee {Name} has ID {ID} in department {Department}, and will be payed {BaseSalary} on {ContractExpiryDate:d}.  Has {(WasPayed ? "" : "not ")}been payed";
  }
};