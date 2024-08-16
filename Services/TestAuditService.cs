using System.Runtime.Serialization;
using System.ServiceModel;

namespace soaptest.Services
{
    [ServiceContract]
    public interface ITestAuditService
    {
        [OperationContract]
        public string LogError();
    }

    public class TestAuditService : ITestAuditService
    {
        string ITestAuditService.LogError()
        {
            Console.WriteLine("Entered Log Error");
            return "Error";
        }
    }
}