﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextGen.Models
{
    public interface IRepository
    {
       BsonDocument GetInjectorRecords();
    }
}
