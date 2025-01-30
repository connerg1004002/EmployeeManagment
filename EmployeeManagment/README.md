# How to run

### Employee Setup

The employee types are `FullTimeEmployee`, `PartTimeEmployee`, and `Contractor`

The constructors of each type are as follows : 

```
FullTimeEmployee(int id, string name, string department, decimal baseSalary, decimal annualBonus)
```

```
PartTimeEmployee(int id, string name, string department, decimal hourlyRate, int hoursWorked)
```

```
Contractor(int id, string name, string department, decimal baseSalary, DateTime contractExpiryDate, bool wasPayed)
```

Create the employee type you want with the arguements filled in to start


### Employee Use
Each Employee has a `string ToString()` and `decimal CalculatePay(DateTime? date)` function

Use these to retrieve information about the employee