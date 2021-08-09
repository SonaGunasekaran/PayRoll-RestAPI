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
        public void ReadAllDataFromServer()
        {
            int expected = 1;
            List<Employeedata> employeeList = new PayRollJson().ReadServer();
            Assert.AreEqual(expected, employeeList.Count);
        }
        [TestMethod]
        public void WriteIntoServer()
        {
            Employeedata data= new Employeedata{ id = 2, Name = "Mickel", Salary = 80000 };
            new PayRollJson().WriteIntoJsonServer(data);
        }


    }
}
