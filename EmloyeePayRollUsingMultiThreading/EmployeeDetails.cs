using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmloyeePayRollUsingMultiThreading
{
    public class EmployeeDetails
    {
       
        public static string dbpath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayRoll;Integrated Security=True";
        public List<ModelClass> employeeList = new List<ModelClass>();
        public void CreateNewContact(ModelClass model)
        {
            SqlConnection connect = new SqlConnection(dbpath);
            using (connect)
            {
                connect.Open();
                SqlCommand sql = new SqlCommand("SP_EmployeeDetails", connect);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@NAME", model.NAME);
                sql.Parameters.AddWithValue("@SALARY", model.SALARY);
                sql.Parameters.AddWithValue("@START", model.START);
                sql.Parameters.AddWithValue("@GENDER", model.gender);
                sql.Parameters.AddWithValue("@PHONENO", model.PHONENO);
                sql.Parameters.AddWithValue("@ADDRESS", model.ADDRESS);
                sql.Parameters.AddWithValue("@DEPARTMENT", model.DEPARTMENT);
                sql.Parameters.AddWithValue("@BASIC_PAY", model.BASIC_PAY);
                sql.ExecuteNonQuery();
                Console.WriteLine("Record created successfully.");
                connect.Close();
            }
        }
        public void AddNewEmployee(List<ModelClass> employeeList)
        {
            foreach (ModelClass employee in employeeList)
            {
                this.CreateNewContact(employee);
                Console.WriteLine("Employee Added: " + employee.NAME);
            }
        }
        public void AddNewEmployeeUsingThread(List<ModelClass> employeeList)
        {
            foreach (ModelClass employee in employeeList)
            {
                Task Thread = new Task(() =>
                {
                    this.CreateNewContact(employee);
                    Console.WriteLine("Employee Added: " + employee.NAME);
                });
                Thread.Start();
            }
            Console.WriteLine(this.employeeList.Count);
        }
        public void addEmployeePayRoll(ModelClass emp)
        {
            employeeList.Add(emp);

        }
        public int EmployeeCount()
        {
            return this.employeeList.Count;
        }


    }

}


