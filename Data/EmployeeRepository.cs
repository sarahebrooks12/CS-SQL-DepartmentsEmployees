using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Models;
using System.Data.SqlClient;

namespace DepartmentsEmployees.Data
{
    class EmployeeRepository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DepartmentsEmployees;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }
        public List<Employee> GetEmployees()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, FirstName, LastName, DepartmentId FROM Employee";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Employee> employees = new List<Employee>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int firstNameColumnPosition = reader.GetOrdinal("FirstName");
                        int lastNameColumnPosition = reader.GetOrdinal("LastName");
                        int deptIdColumnPosition = reader.GetOrdinal("DepartmentId");
                        string firstNameValue = reader.GetString(firstNameColumnPosition);
                        string lastNameValue = reader.GetString(lastNameColumnPosition);
                        int deptIdValue = reader.GetInt32(deptIdColumnPosition);

                        Employee employee = new Employee
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            DepartmentId = deptIdValue
                        };

                        employees.Add(employee);
                    }
                    reader.Close();
                    return employees;
                }
            }
        }
        public Employee GetEmployeeById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT FirstName, LastName, DepartmentId FROM Employee WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Employee employee = null;

                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            Id = id,
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId"))
                        };
                    }

                    reader.Close();

                    return employee;
                }
            }
        }
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Department (FirstName, LastName, DeptId) OUTPUT INSERTED.Id Values (@firstName, @lastName, @deptId)";
                    cmd.Parameters.Add(new SqlParameter("@firstName", employee.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", employee.LastName));
                    cmd.Parameters.Add(new SqlParameter("@deptId", employee.DepartmentId));
                    int id = (int)cmd.ExecuteScalar();
                    employee.Id = id;
                }
            }
        }
        public void UpdateEmployee(int id, Employee employee)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Employee
                                     SET FirstName = @firstName, LastName = @lastName
                                     WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@firstName", employee.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@firstName", employee.LastName));
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Employee WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //COPY AND PASTE ABOVE THIS LINE
    }
}
