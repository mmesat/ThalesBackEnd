using Microsoft.Extensions.Logging;
using Moq;
using ThalesBack.Controllers;
using ThalesBack.Entity;
using ThalesBack.Services;
using ThalesBack.Data;

namespace TestProject
{
    public class Tests
    {
        private Mock<ILogger<EmployeeController>> logMock;
        private Mock<IEmployeeService> serviceMock;
        private Mock<EmployeesData> data;
        [SetUp]
        public void Setup()
        {
            logMock = new Mock<ILogger<EmployeeController>>();
            serviceMock = new Mock<IEmployeeService>();
            data = new Mock<EmployeesData>();
        }

        [Test]
        public async Task Test1()
        {
            serviceMock.Setup(x => x.GetEmployee(It.IsAny<int>())).ReturnsAsync(
                new List<Employee>
                {
                    new Employee
                    {
                     id = 2,
                    employee_name = "Garrett Winters",
                    employee_salary = (170750 * 12),
                    employee_age = 63,
                    profile_image = ""
                    }

                }
                );
            var employee = await serviceMock.Object.GetEmployee(2);

            Assert.IsNotNull(employee);
            Assert.AreEqual(2, employee[0].id);
            Assert.AreEqual(170750 * 12, employee[0].employee_salary);
            Assert.Pass();
        }
    }
}