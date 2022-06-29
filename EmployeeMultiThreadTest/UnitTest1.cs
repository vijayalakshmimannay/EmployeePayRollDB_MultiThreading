using EmloyeePayRollUsingMultiThreading;
using System.Collections.Generic;


namespace EmployeeMultiThreadTest
{
    public class Tests
    {
        [Test]
        public void GivenListOfMultipleEmployee_AddToPayrollDataBase_TestTimeWithAndWithout_MutltiThreading()
        {
            List<ModelClass> employee = new List<ModelClass>();
            employee.Add(new ModelClass(ID: 14, NAME: "Vijaya", SALARY: 30000, START: DateTime.Now, gender: "F", PHONENO: 9703088064, ADDRESS: "KADAPA", DEPARTMENT: "ENGINEER", BASIC_PAY: 25000, DEDUCTIONS: 1300, TAXCABLE_PAY: 1000, NET_PAY: 22800));
            employee.Add(new ModelClass(ID: 15, NAME: "Aarna", SALARY: 33000, START: DateTime.Now, gender: "F", PHONENO: 9182147305, ADDRESS: "KARNOOL", DEPARTMENT: "SOFTWARE", BASIC_PAY: 33000, DEDUCTIONS: 1500, TAXCABLE_PAY: 1100, NET_PAY: 30400));
            employee.Add(new ModelClass(ID: 16, NAME: "Harsha", SALARY: 45000, START: DateTime.Now, gender: "M", PHONENO: 6005526294, ADDRESS: "CHITTOR", DEPARTMENT: "ARMY", BASIC_PAY: 20000, DEDUCTIONS: 2000, TAXCABLE_PAY: 1200, NET_PAY: 37100));
            employee.Add(new ModelClass(ID: 17, NAME: "Sita", SALARY: 45000, START: DateTime.Now, gender: "F", PHONENO: 6666754325, ADDRESS: "CHITWEL", DEPARTMENT: "MARKETNG", BASIC_PAY: 45000, DEDUCTIONS: 1900, TAXCABLE_PAY: 1300, NET_PAY: 41800));
            employee.Add(new ModelClass(ID: 17, NAME: "Laxmi", SALARY: 33000, START: DateTime.Now, gender: "F", PHONENO: 9876543212, ADDRESS: "VONTIMITTA", DEPARTMENT: "SALES", BASIC_PAY: 33000, DEDUCTIONS: 1600, TAXCABLE_PAY: 1100, NET_PAY: 30800));

            EmployeeDetails repo = new EmployeeDetails();
            DateTime start = DateTime.Now;
            repo.AddNewEmployee(employee);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Time required to add multiple employees without using Thread: " + (endTime - start));

            DateTime startThread = DateTime.Now;
            repo.AddNewEmployeeUsingThread(employee);
            DateTime endThread = DateTime.Now;
            Console.WriteLine("Time required to add multiple employees using thread: " + (endThread - startThread));
        }

    }
}