
using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;

namespace NextGen.Models
{
    

    

    public class DeviceRecord {

        public ObjectId Id { get; set; }
        public string device { get; set; }
        public Dictionary<string, string>   models { get; set;}

    }
}
