using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballTweaker_V2.Model
{
    public class Record
    {
        public string last_name { get; set; }
        public string first_name { get; set; }
        public int player_id { get; set; }

        public Record(string lname, string fname)
        {
            last_name = lname;
            first_name = fname;

        }

        public Record()
        {

        }

    }
}
