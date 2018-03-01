using System;
using System.Collections.Generic;
using System.Text;

namespace Training.MongoDBService
{
    public interface IAggregateRoot
    {
        string Id { get; set; }
    }
}
