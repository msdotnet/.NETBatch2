// See https://aka.ms/new-console-template for more information
using QualMinds.Hrm.Core;


var organization = Employee.Organization;
Console.WriteLine($"Organization Name: {organization}");
var employee = new Employee("Avishek", "Kumar");
var employee = new Employee
{
   FirstName = "Avishek",
   LastName = "Kumar"
};
employee.FirstName = "Avishek";
Employee.Department department = new Employee.Department();
Console.WriteLine(employee.GetFullName());