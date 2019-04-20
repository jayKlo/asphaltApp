using System;
using Newtonsoft.Json;

//This model is to represent a single Report pulled from the database
namespace asphaltApp
{
    public class Report
    {
        [JsonProperty("reportID")]
        public int reportID { get; set; }

        [JsonProperty("usertID")]
        public int userID { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("reportLat")]
        public double reportLat { get; set; }

        [JsonProperty("typeOfDamage")]
        public string typeOfDamage { get; set; }

        [JsonProperty("postRank")]
        public int postRank { get; set; }

        [JsonProperty("dateReported")]
        public string dateReported { get; set; }

        [JsonProperty("completed")]
        public bool completed { get; set; }

        [JsonProperty("reportLong")]
        public double reportLong { get; set; }


    }
}

