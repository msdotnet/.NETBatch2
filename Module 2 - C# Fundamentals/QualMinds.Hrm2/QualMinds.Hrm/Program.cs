using QualMinds.Hrm.Core;
using QualMinds.Hrm.Extensions;
Employee employee = new();

var fullName = employee.ReturnFullName("Avishek", "Kumar");
Console.WriteLine(employee.FirstName);
employee.GetTotalLetterCountOfFullName(fullName);
Console.WriteLine(employee.FirstName);