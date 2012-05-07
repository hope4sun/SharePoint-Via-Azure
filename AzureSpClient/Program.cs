using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Xml.Linq;

namespace AzureSpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** SharePoint Cloud Client ****");
            Console.WriteLine("Press <Enter> to run client.");
            Console.ReadLine();
            Console.WriteLine("Starting.");

            // Open a channel to the Routing Service via Azure
            ChannelFactory<IMyContract> channelFactory = new ChannelFactory<IMyContract>("webRelay");
            IMyContract channel = channelFactory.CreateChannel();

            // Call the service
            var response = channel.GetList("Azure Data");

            // Output the returned raw XML
            Console.WriteLine(response);

            channelFactory.Close();
            Console.ReadKey();
        }
    }

    // Basic inteface for the GetList function of the SharePoint Lists.asmx
    [ServiceContract(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public interface IMyContract
    {
        [OperationContract(Action = "http://schemas.microsoft.com/sharepoint/soap/GetList", ReplyAction = "http://schemas.microsoft.com/sharepoint/soap/GetListResponse")]
        XElement GetList(string listName);
    }
}
