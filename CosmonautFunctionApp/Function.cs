namespace CosmonautFunctionApp
{
    using System;

    using ClassLibrary;

    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;

    public static class Function
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var util = new CosmonautUtil();
            var store = util.CreateStore();

            var model = new CosmonautModel();
            store.AddAsync(model).GetAwaiter().GetResult();
        }
    }
}
