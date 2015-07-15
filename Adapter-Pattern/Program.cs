using System;
using System.Collections.Generic;

namespace Adapter_Pattern
{

    /// <summary>
    /// The 'Client' class
    /// </summary>
    public class ThirdPartyBillingSystem
    {
        private readonly ITarget _employeeSource;

        public ThirdPartyBillingSystem(ITarget employeeSource)
        {
            _employeeSource = employeeSource;
        }

        public void ShowEmployeeList()
        {
            List<string> employee = _employeeSource.GetEmployeeList();
            //To DO: Implement you business logic

            Console.WriteLine("######### Çalışan Listesi ##########");
            foreach (var item in employee)
            {
                Console.Write(item);
            }

        }
    }

    /// <summary>
    /// The 'ITarget' interface
    /// </summary>
    public interface ITarget
    {
        List<string> GetEmployeeList();
    }

    /// <summary>
    /// The 'Adaptee' class
    /// </summary>
    public class HrSystem
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];

            employees[0] = new[] { "100", "Ahmet", "Team Leader" };
            employees[1] = new[] { "101", "Mehmet", "Developer" };
            employees[2] = new[] { "102", "Hasan", "Developer" };
            employees[3] = new[] { "103", "Hüseyin", "Tester" };

            return employees;
        }
    }


    /// <summary>
    /// The 'Adapter' class
    /// </summary>
    public class EmployeeAdapter : HrSystem, ITarget
    {
        public List<string> GetEmployeeList()
        {
            List<string> employeeList = new List<string>();
            string[][] employees = GetEmployees();
            foreach (string[] employee in employees)
            {
                employeeList.Add(employee[0]);
                employeeList.Add(",");
                employeeList.Add(employee[1]);
                employeeList.Add(",");
                employeeList.Add(employee[2]);
                employeeList.Add("\n");
            }

            return employeeList;
        }
    }

    /// 
    /// Adapter Design Pattern Demo
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            ITarget itarget = new EmployeeAdapter();
            ThirdPartyBillingSystem client = new ThirdPartyBillingSystem(itarget);
            client.ShowEmployeeList();

            Console.ReadKey();
        }
    }
}
