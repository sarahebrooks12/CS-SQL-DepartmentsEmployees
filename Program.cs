using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;
using System;
using System.Collections.Generic;

namespace DepartmentsEmployees
{
    class Program
    //Control F5 to run app
    //F5 debugger
    {
        static void Main(string[] args)
        {

            DepartmentRepository departmentRepo = new DepartmentRepository();

            Console.WriteLine("Getting All Departments:");
            Console.WriteLine();

            List<Department> allDepartments = departmentRepo.GetAllDepartments();

            foreach (Department dept in allDepartments)
            {
                Console.WriteLine($"{dept.Id} {dept.DeptName}");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Department with Id 1");

            Department singleDepartment = departmentRepo.GetDepartmentById(1);

            Console.WriteLine($"{singleDepartment.Id} {singleDepartment.DeptName}");




            //Department legalDept = new Department
            //{
            //    DeptName = "Legal"
            //};

            //departmentRepo.AddDepartment(legalDept);

            //Console.WriteLine("-------------------------------");
            //Console.WriteLine("Added the new Legal Department!");

            //departmentRepo.UpdateDepartment(1, new Department() { DeptName = "New Department" });

            //Console.WriteLine("Here's your updated department:");
            //Console.WriteLine(departmentRepo.GetDepartmentById(1).DeptName);

            //Console.WriteLine("Now let's delete a department.");
            //departmentRepo.DeleteDepartment(4);
            //List<Department> newDeps = departmentRepo.GetAllDepartments();
            //foreach (Department dep in newDeps)
            //{
            //    Console.WriteLine(dep.DeptName);
            //}

            //Console.ReadLine();

            EmployeeRepository employeeRepo = new EmployeeRepository();

            Console.WriteLine("Getting all Employees:");
            Console.WriteLine();


            List<Employee> allEmployees = employeeRepo.GetEmployees();
            foreach (Employee empl in allEmployees)
            {
                Console.WriteLine(empl.FirstName);
                Console.WriteLine(empl.LastName);
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Employees with Id 1");

            Employee singleEmployee = employeeRepo.GetEmployeeById(1);

            Console.WriteLine($"{singleEmployee.Id} {singleEmployee.FirstName} {singleEmployee.LastName}");




            //public List<Employee> GetAllEmployeesWithDepartment() < ---Employee objects should have a Department property
            //public void AddEmployee(Employee employee)
            //public void UpdateEmployee(int id, Employee employee) < ---Use the SQL UPDATE statement
            //public void DeleteEmployee(int id)
            //COPY AND PASTE ABOVE THIS LINE
        }
    }
}