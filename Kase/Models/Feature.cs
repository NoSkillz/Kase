using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kase.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Area Area { get; set; }
    }
}