// // Project:  ClassLibrary
// // Platform:  CosmonautFunctionApp
// // Date Created:  05/17/2019 12:12 PM
// // Copyright (c) Salud Medica Inc.

namespace ClassLibrary
{
    using System;

    using Cosmonaut;

    using Microsoft.Azure.Documents.Client;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class CosmonautUtil
    {
        static CosmonautUtil()
        {
            SerializerSettings = new JsonSerializerSettings
                                     {
                                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                         NullValueHandling = NullValueHandling.Ignore,
                                         TypeNameHandling = TypeNameHandling.Auto,
                                         Formatting = Formatting.Indented,
                                         ////MissingMemberHandling = MissingMemberHandling.Error,
                                     };
            SerializerSettings.Converters.Add(new StringEnumConverter(true));
            ////SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
        }

        public static JsonSerializerSettings SerializerSettings { get; }

        public CosmosStore<CosmonautModel> CreateStore()
        {
            var endpoint = new Uri(@"https://localhost:8081/");
            var key = "[AUTH KEY]";
            var policy = new ConnectionPolicy
                             {
                                 ConnectionMode = ConnectionMode.Direct,
                                 ConnectionProtocol = Protocol.Tcp
                             };
            var documentClient = new DocumentClient(endpoint, key, SerializerSettings, policy);

            var cosmonautClient = new CosmonautClient(documentClient);
            return new CosmosStore<CosmonautModel>(cosmonautClient, "Cosmonaut");
        }
    }
}