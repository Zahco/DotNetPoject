﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Entities
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