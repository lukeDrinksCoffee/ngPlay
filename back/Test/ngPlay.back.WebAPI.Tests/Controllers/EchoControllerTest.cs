using ngPlay.back.Domain.Contracts;
using ngPlay.back.WebAPI.Controllers;
using NUnit.Framework;
using System.IO;
using System.Web;
using Rhino.Mocks;

namespace ngPlay.back.WebAPI.Tests.Controllers
{
    ///////////////////////////////////////////////////////
    // Test naming convention
    //
    //    UnitOfWork_StateUnderTest_ExpectedOutcome
    //

    [TestFixture]
    public class EchoControllerTest
    {
        [Test]
        public void HttpGet_BasicCall_ReturnsValueWithTimeAppended()
        {
            // ARRANGE
            var serviceMock = MockRepository.GenerateMock<IAppLogService>();
            var controller = new EchoController(serviceMock);
            const string value = "hello";

            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""),
                                                  new HttpResponse(new StringWriter()));

            // ACT
            var echoResponse = controller.Get(value);

            // ASSERT
            Assert.NotNull(echoResponse);

            var prop = echoResponse.GetType().GetProperty("echo");
            Assert.NotNull(prop);

            var echoValue = prop.GetValue(echoResponse) as string;
            Assert.NotNull(echoValue);
            Assert.IsTrue(echoValue.StartsWith(value));
            Assert.IsTrue(echoValue.Length > value.Length);
        }
    }
}
