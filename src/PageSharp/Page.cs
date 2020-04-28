using System.Collections.Generic;

namespace PageSharp
{
    public class Page<T> where T: class{
        public List<T> Items{get;set;}
    }
  }
