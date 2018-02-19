using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class ModelWithNameAndId
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}