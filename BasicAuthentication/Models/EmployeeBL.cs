using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.Models
{
    //step 2:
    public class EmployeeBL
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> empList = new List<Employee>();
            for(int i =0; i < 10; i++)
            {
                if (i > 5)
                {
                    empList.Add(new Employee()
                    {
                        ID = i,
                        Name = "Name" + i,
                        Salary = 1000 + i,
                        Gender = "Male"
                    });
                }
                else {
                    empList.Add(new Employee()
                    {
                        ID = i,
                        Name = "Name" + i,
                        Salary = 1000 + i,
                        Gender = "Female"
                    });
                }
            }
            return empList;
        }
    }
}