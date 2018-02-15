using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class AddAllByEvalModel
    {
        public Guid EvalId { get; set; }
        public List<OneResult> Results { get; set; }
    }

    public class OneResult
    {
        public ModelWithNameAndId Pupil { get; set; }
        public double Note { get; set; }
    }
}