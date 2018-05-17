using ServiceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 Create a URI to serve as the base address.  
            Uri baseAddress = new Uri("http://localhost:8000/");

            // Step 2 Create a ServiceHost instance  
            WebServiceHost webHost = new WebServiceHost(typeof(Service), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.  
                webHost.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
                foreach (ServiceEndpoint EP in webHost.Description.Endpoints)
                    EP.Behaviors.Add(new OpenBetRetail.NFCReaderService.BehaviorAttribute());

                /*/ Step 4 Enable metadata exchange.  
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);*/
                ServiceDebugBehavior sdb = webHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                sdb.HttpHelpPageEnabled = false;

                // Step 5 Start the service.  
                webHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.  
                webHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                webHost.Abort();
            }
        }
    }
}
