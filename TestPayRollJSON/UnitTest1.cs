using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayRollRestAPI;
using System;
using System.Collections.Generic;

namespace TestPayRollJSON
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRetrieveDataFromServer()
        {
            int expected = 1;
            List<Employeedata> emp = new PayRollJson().ReadServer();
            Assert.AreEqual(expected, emp.Count);
        }
        [TestMethod]
        public void TestAddSingleData()
        {
            Employeedata data = new Employeedata { id = 2, Name = "Mickel", Salary = 80000 };
            new PayRollJson().AddDataIntoJsonServer(data);
        }
        [TestMethod]
        public void AddMultipleData()
        {
            List<Employeedata> emp = new List<Employeedata>
            {
                new Employeedata{id=3,Name="Stefan",Salary=70000},
                new Employeedata{id=4,Name="Damon",Salary=60000},
                new Employeedata{id=5,Name="Joey",Salary=90000}

            };
            new PayRollJson().AddMultipleDataIntoServer(emp);
            emp = new PayRollJson().ReadServer();
            int expected = 5;
            Assert.AreEqual(expected, emp.Count);
        }
        [TestMethod]
        public void TestUpdateSalary()
        {
            bool expected = true;
            Employeedata employee = new Employeedata { id = 4, Name = "Damon", Salary = 65000 };
            bool actual = new PayRollJson().UpdateDetailInJsonServer(employee);
            Assert.AreEqual(expected, actual);
        }
    }
}
