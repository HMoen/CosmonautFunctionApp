// // Project:  ClassLibrary
// // Platform:  CosmonautFunctionApp
// // Date Created:  05/17/2019 12:22 PM
// // Copyright (c) Salud Medica Inc.

namespace ClassLibrary
{
    using Cosmonaut.Attributes;

    using Newtonsoft.Json;

    public class CosmonautModel
    {
        [CosmosPartitionKey]
        public string DocumentPartition { get; } = "TEST";

        [JsonProperty(PropertyName = "id")]
        public string DocumentId { get; } = "TEST";

        public CosmonautEnum CosmonautEnum { get; set; } = CosmonautEnum.Destroyed;

        public string CosmonautStringValue { get; set; }
    }
}