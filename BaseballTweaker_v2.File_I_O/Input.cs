using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BaseballTweaker_V2.Model;
using System.IO;

namespace BaseballTweaker_V2.File_I_O
{
    public static class Input
    {
        //retrieves batting stats from a csv file and returns a Dictionary collection with string with the player name and a BattingRecord object that stores the statistics 
        public static Dictionary<string, BattingRecord> RetrieveAllBattingRecords(string path = @"G:\Users\James\Documents\Baseball Tweaker Data Files\hitting stats part 4.csv")
        {
            Dictionary<string, BattingRecord> battingPlayerStat = new Dictionary<string, BattingRecord>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = reader.ReadLine();

                    while ((line = reader.ReadLine()) != null)
                    {


                        string[] splitLine = line.Split(',');
                        // player = new Player();
                        BattingRecord record = new BattingRecord();
                        int i = 0;
                        record.last_name = " " + splitLine[i++];
                        record.first_name = splitLine[i++].Trim();
                        string fullName = record.first_name + record.last_name;
                        record.player_id = record.player_id = int.Parse(splitLine[i++]);
                        record.year = int.Parse(splitLine[i++]);
                        record.player_age = int.Parse(splitLine[i++]);
                        record.b_ab = int.Parse(splitLine[i++]);
                        record.b_total_pa = int.Parse(splitLine[i++]);
                        record.b_total_hits = int.Parse(splitLine[i++]);
                        record.b_single = int.Parse(splitLine[i++]);
                        record.b_double = int.Parse(splitLine[i++]);
                        record.b_triple = int.Parse(splitLine[i++]);
                        record.b_home_run = int.Parse(splitLine[i++]);
                        record.b_strikeout = int.Parse(splitLine[i++]);
                        record.b_walk = int.Parse(splitLine[i++]);
                        record.b_k_percent = double.Parse(splitLine[i++]);
                        record.b_bb_percent = double.Parse(splitLine[i++]);
                        record.batting_avg = double.Parse(splitLine[i++]);
                        record.slg_percent = double.Parse(splitLine[i++]);
                        record.on_base_percent = double.Parse(splitLine[i++]);
                        record.on_base_plus_slg = double.Parse(splitLine[i++]);
                        record.b_rbi = int.Parse(splitLine[i++]);
                        record.b_lob = int.Parse(splitLine[i++]);
                        record.b_total_bases = int.Parse(splitLine[i++]);
                        record.r_total_stolen_base = int.Parse(splitLine[i++]);
                        record.r_run = int.Parse(splitLine[i++]);
                        record.woba = double.Parse(splitLine[i++]);
                        string blank = splitLine[i];
                        battingPlayerStat.Add(fullName, record);



                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return battingPlayerStat;
        }

        //retrieves pitching stats from a csv file and returns a Dictionary collection with string with the player name and a PitchingRecord object that stores the statistics 
        public static Dictionary<string, PitchingRecord> RetrieveAllPitchingRecords(string path = @"G:\Users\James\Documents\Baseball Tweaker Data Files\pitching stats.csv")
        {
            Dictionary<string, PitchingRecord> pitchingPlayerStat = new Dictionary<string, PitchingRecord>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = reader.ReadLine();

                    while ((line = reader.ReadLine()) != null)
                    {


                        string[] splitLine = line.Split(',');
                        // Player player = new Player();
                        PitchingRecord record = new PitchingRecord();
                        int i = 0;
                        record.last_name = " " + splitLine[i++];
                        record.first_name = splitLine[i++].Trim();
                        string fullName = record.first_name + record.last_name;
                        record.player_id = record.player_id = int.Parse(splitLine[i++]);
                        record.year = int.Parse(splitLine[i++]);
                        record.player_age = int.Parse(splitLine[i++]);
                        record.p_game = int.Parse(splitLine[i++]);
                        record.p_formatted_ip = double.Parse(splitLine[i++]);
                        record.p_strikeout = int.Parse(splitLine[i++]);
                        record.p_run = int.Parse(splitLine[i++]);
                        record.p_blown_save = int.Parse(splitLine[i++]);
                        record.p_win = int.Parse(splitLine[i++]);
                        record.p_loss = int.Parse(splitLine[i++]);
                        record.p_shutout = int.Parse(splitLine[i++]);
                        record.p_quality_start = int.Parse(splitLine[i++]);
                        record.p_complete_game = int.Parse(splitLine[i++]);

                        string blank = splitLine[i];
                        pitchingPlayerStat.Add(fullName, record);



                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return pitchingPlayerStat;
        }

    }
}
