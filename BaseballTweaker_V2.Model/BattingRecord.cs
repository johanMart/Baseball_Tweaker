using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballTweaker_V2.Model
{
    public class BattingRecord : Record
    {

        //  public int player_id { get; set; }
        public int year { get; set; }
        public int player_age { get; set; }
        public int b_ab { get; set; }
        public int b_total_pa { get; set; }
        public int b_total_hits { get; set; }
        public int b_single { get; set; }
        public int b_double { get; set; }
        public int b_triple { get; set; }
        public int b_home_run { get; set; }
        public int b_strikeout { get; set; }
        public int b_walk { get; set; }
        public double b_k_percent { get; set; }
        public double b_bb_percent { get; set; }
        public double batting_avg { get; set; }
        public double slg_percent { get; set; }
        public double on_base_percent { get; set; }
        public double on_base_plus_slg { get; set; }
        public double woba { get; set; }

        public int b_rbi { get; set; }

        public int b_lob { get; set; }

        public int b_total_bases { get; set; }
        public int r_total_stolen_base { get; set; }

        public int r_run { get; set; }

    }
}
