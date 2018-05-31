using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using AzureAssignment;
using AzureAssignment.Models;
using System.Linq;
using EmployeeExportWebJob.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace EmployeeExportWebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        
        static void Main()
        {
            EmployeeDBContext _context = new EmployeeDBContext();
            var employee = _context.Employees.OrderBy(x => x.Id).First();
            MemoryStream stream = SerializeToStream(employee);

            UploadToEmployeeBlob(stream);

        }

        private static void UploadToEmployeeBlob(MemoryStream stream)
        {
            string blobconn = System.Configuration.ConfigurationManager.AppSettings.Get("azassignmentstorage");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobconn);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("azureassignmentcontainer");
            cloudBlobContainer.CreateIfNotExists();
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("azassignmentblob");
            cloudBlockBlob.UploadFromStream(stream);
            
        }

        public static MemoryStream SerializeToStream(object o)
        {
             MemoryStream stream = new MemoryStream();
           
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return stream;

        }
    }
}
