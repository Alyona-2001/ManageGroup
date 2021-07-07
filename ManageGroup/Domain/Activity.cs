using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageGroup.Domain
{
    public class Activity
    {
        public int ID { get; set; }
        public string NameActivity { get; set; }
        public Status status { get; set; }
        public TypeComp TypeActivity { get; set; }
        public string DateStart { get; set; }
        public string TimeStart { get; set; }
        public string DateEnd { get; set; }
        public string TimeEnd { get; set; }
        public int Duration { get; set; }
    }
}
