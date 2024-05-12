﻿using Newtonsoft.Json;

namespace Thegioididong.Api.Models.Responses
{
    public class ValidationError
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("errors")]
        public Dictionary<string, string[]> Errors { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }
    }
}
