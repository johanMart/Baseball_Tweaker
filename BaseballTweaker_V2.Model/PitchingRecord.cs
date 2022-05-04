using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballTweaker_V2.Model
{
    public class PitchingRecord : Record
    {

        // public int player_id { get; set; }
        public int year { get; set; }
        public int player_age { get; set; }
        public int p_game { get; set; }
        public double p_formatted_ip { get; set; }
        public int p_strikeout { get; set; }
        public int p_run { get; set; }
        public int p_blown_save { get; set; }
        public int p_win { get; set; }
        public int p_loss { get; set; }
        public int p_shutout { get; set; }
        public int p_quality_start { get; set; }
        public int p_complete_game { get; set; }


    }
}
