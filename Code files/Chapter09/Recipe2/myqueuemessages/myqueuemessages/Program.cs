﻿using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Configuration;

namespace myqueuemessages
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateQueueMessages();
            //Console.WriteLine("Hello World!");
        }

        static void CreateQueueMessages()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudQueueClient queueclient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueclient.GetQueueReference("myqueuemessages");

            queue.CreateIfNotExists();
            CloudQueueMessage message = null;
            for (int nQueueMessageIndex = 0; nQueueMessageIndex <= 100; nQueueMessageIndex++)
            {
                message = new CloudQueueMessage(Convert.ToString
                (nQueueMessageIndex));
                queue.AddMessage(message);
                Console.WriteLine(nQueueMessageIndex);
            }
        }
    }
}
