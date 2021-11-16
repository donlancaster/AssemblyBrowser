using Microsoft.VisualStudio.TestTools.UnitTesting;

using AssemblyAnalyzer.Containers;
using System.Collections.Generic;
using AssemblyAnalyzer;
using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class UnitTests
    {
        private const string _testAssemblyPath = "/dll/FakerLib.dll";
        private AssemblyBrowser _assemblyBrowser;
        private List<Container> _assemblyInfo;

        [TestInitialize]
        public void Setup()
        {
            _assemblyBrowser = new AssemblyBrowser();
            _assemblyInfo = _assemblyBrowser.GetAssemblyInfo(AppDomain.CurrentDomain.BaseDirectory + _testAssemblyPath);
            Console.WriteLine((AppDomain.CurrentDomain.BaseDirectory + _testAssemblyPath));
        }
        [TestMethod]
        public void AssemblyIsNotEmpty()
        {
            int expected = 0;
            int actual = _assemblyInfo.Count;
            Assert.AreNotEqual(expected,actual);
        }

        [TestMethod]
        public void CorrectClassCount()
        {
            int expected = 1;
            int actual = _assemblyInfo[0].Members.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClassHasCorrectMembersCount()
        {
            int expected = 2;
            Container container = (Container)_assemblyInfo[0].Members[0];
            int actual = container.Members.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssemblyClassHasMemberGetObjectTest()
        {
            string memberGetObject = "public  Void LoadPluginGenerators ()";
            Container container = (Container)_assemblyInfo[1].Members[1];
            bool hasMemberGetObject = false;
            foreach (MemberInfo member in container.Members)
            {
                if (member.Signature.Equals(memberGetObject))
                {
                    hasMemberGetObject = true;
                    break;
                }
            }
            Assert.IsTrue(hasMemberGetObject);
        }



    }

}
