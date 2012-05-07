using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Routing;

namespace AzureSBR.Router
{
    public class Program
    {
        // Host the service within the console application.
        public static void Main()
        {
            // Create a ServiceHost for the RoutingService.
            using (ServiceHost serviceHost =
                new ServiceHost(typeof(RoutingService)))
            {
                // Open the ServiceHost to create listeners         
                // and start listening for messages.
                Console.WriteLine("The Routing Service configured, opening....");
                serviceHost.Open();
                Console.WriteLine("The Routing Service is now running.");
                Console.WriteLine("Press <ENTER> to terminate router.");

                // The service can now be accessed.
                Console.ReadLine();
            }
        }
    }
}
