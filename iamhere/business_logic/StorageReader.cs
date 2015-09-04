//using Microsoft.WindowsAzure;
//using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.Azure.KeyVault.Core;

using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Auth;
//using Microsoft.WindowsAzure.Storage.Table;

namespace business_logic
{
    class StorageReader
    {
        public static Dictionary<string, string> Pairs = new Dictionary<string, string>();
        private static string TableEndpoint = @"https://testqperformance.table.core.windows.net/";
        private static string AccountName = @"testqperformance";
        private static string Key = "m8+3T519KotN2pBRLaNwKcy9EDoHc6RnCT6WngYyQFhYsUXzTbJRY73cwVndRqMGNpi3hLWKPta0L+bH+Qip1A==";


        public static void LogDelete(LogEntity LogEntity)
        {
            ////// Create the table client.
            CloudStorageAccount account = null;
            StorageCredentials creds = new StorageCredentials(AccountName, Key);
            account = new CloudStorageAccount(creds, useHttps: true);

            //Create the table client.
            CloudTableClient tableClient = account.CreateCloudTableClient();

            //string[] partitions = LogEntity.PartitionKey.Split('_');
            //string origin = partitions.Length > 0 ? partitions[0] : "";
            //origin = origin.Replace(" ", "");
            string LogTableDate = "logs";// + origin + DateTime.UtcNow.ToString("yyyyMMdd");

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(LogTableDate);

            try
            {
                //string partitionKey = "SPS R_11";
                //string rowKey = "2519610192579076075_da8bea2b-a795-4333-8648-28e6325d4341";
                DateTime dt1 = DateTime.Now;
                foreach (var p in Pairs)
                {
                    object ob = table.Execute(TableOperation.Delete(new TableEntity(p.Value, p.Key) { ETag = "*" })).Result;
                }
                DateTime dt2 = DateTime.Now;
                Console.WriteLine("Pairs=" + Pairs.Count);
                Console.WriteLine("TotalMilliseconds=" + dt2.Subtract(dt1).TotalMilliseconds);
                Console.WriteLine("TotalSeconds=" + dt2.Subtract(dt1).TotalSeconds);
                Pairs.Clear();
            }
            catch (StorageException e)
            {
                if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine(e.Message);
            }

        }
    }
}
