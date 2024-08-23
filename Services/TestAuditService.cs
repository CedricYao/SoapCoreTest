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

    [ServiceContract]
    public interface INeedAService
    {
        [OperationContract]
        public string Execute();
    }

    public class NeedAService : INeedAService
    {
        public string Execute()
        {
            return "Executed";
        }
    }
}