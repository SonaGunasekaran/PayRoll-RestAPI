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
            List<Employeedata> employeeList = new PayRollJson().ReadFromServer();
            Assert.AreEqual(expected, employeeList.Count);
        }

    }
}
