using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Chart
    {
        public int ChartId { get; set; }

        public int UserId { get; set; }

        public string ChartName { get; set; }

        public int ChartCount { get; set; }

        public bool ChartStatus { get; set; }


    }
}
