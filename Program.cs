using Azure.Core.Diagnostics;
using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.Threading.Tasks;

namespace AzureSdkBadErrorMessage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
            // These credentials are not real
            var creds = new ClientSecretCredential(
                "274d3ec0-04a4-43aa-9db3-7e8b8deaebc3",
                "1f2b8ec7-dc20-459d-8100-4aa46af42c3a",
                "86911ef2-1788-4886-aa74-8474b8e0ffeb"
            );
            var service = new BlobServiceClient(new Uri("https://whatever.blob.core.windows.net/"), creds);
            await service.GetUserDelegationKeyAsync(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddHours(1));
        }
    }
}
