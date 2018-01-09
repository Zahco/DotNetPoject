using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class EntityWithId
    {
        public Guid Id { get; set; }

        public EntityWithId()
        {
            Id = Guid.NewGuid();
        }
    }
}