
using System;
using System.Runtime.Serialization;
using Couchbase.Linq.ChangeTracking;
using Newtonsoft.Json;

namespace Couchbase.Linq.Tests.Documents.ChangeTracking
{
    public class Schedule : DocumentBase
    {
        private uint _day;
        private string _utc;
        private string _flight;

        [JsonProperty("day")]
        public uint Day
        {
            get { return _day; }
            set { SetProperty(ref _day, value); }
        }

        [JsonProperty("utc")]
        public string Utc
        {
            get { return _utc; }
            set { SetProperty(ref _utc, value); }
        }

        [JsonProperty("flight")]
        public string Flight
        {
            get { return _flight; }
            set { SetProperty(ref _flight, value); }
        }
    }

    /*"day": 0,
      "utc": "22:03:00",
      "flight": "AA138"
     * */
}
