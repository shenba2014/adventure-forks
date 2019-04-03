using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using log4net;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Owin;

namespace AdventureWorks.Web
{
    public partial class Startup
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Startup));

        public async Task LogStartTimeAsync()
        {
            string sourceFile = null;
            var storageConnectionString = ConfigurationManager.ConnectionStrings["CloudStorage"].ConnectionString;

            if (CloudStorageAccount.TryParse(storageConnectionString, out var storageAccount))
            {
                try
                {
                    var cloudBlobClient = storageAccount.CreateCloudBlobClient();

                    var cloudBlobContainer = cloudBlobClient.GetContainerReference("adventureworksblobs");
                    await cloudBlobContainer.CreateIfNotExistsAsync();

                    var permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    };
                    await cloudBlobContainer.SetPermissionsAsync(permissions);

                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    var localPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    var localFileName = $"HelloWorld_{timestamp}.txt";
                    sourceFile = Path.Combine(localPath, localFileName);

                    File.WriteAllText(sourceFile, $"{timestamp},{Environment.MachineName}");

                    var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(localFileName);
                    await cloudBlockBlob.UploadFromFileAsync(sourceFile, FileMode.OpenOrCreate);
                }
                catch (Exception ex)
                {
                    Log.Error("Error returned from the service: {0}", ex);
                }
                finally
                {
                    if (File.Exists(sourceFile))
                        File.Delete(sourceFile);
                }
            }
            else
            {
                Log.Error("load storageConnectionString from CloudStorage failed");
            }
        }
    }

}