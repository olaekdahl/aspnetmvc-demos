using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrates.DataAccess;
using System.Linq;

namespace Socrates.Tests.DataAccess
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            ISocratesContext ctx = SocratesContextFactory.GetContext(conn);

            var courses = ctx.GetAllCourses().ToList();

            Assert.IsNotNull(courses);
        }
    }
}
