using System;
using System.Collections.Generic;
using System.Linq;
using BaseballTweaker_V2.Model;
using System.IO;
namespace BaseballTweaker_V2.File_I_O
{
    public class Arguments
    {

        public Arguments(string name, double num)
        {

            this.name = name;
            this.num = num;
            this.games = null;
        }

        public Arguments(string name, double num, int games)
        {

            this.name = name;
            this.num = num;
            this.games = games;
        }
        public int? games { get; set; }
        public double? num { get; set; }
        public string name { get; set; }
    }
    public static class OutputToConsole
    {

        public static void CalculateExtraBasesPerAtBat(Dictionary<string, BattingRecord> batting_stats, string path)
        {

            Dictionary<string, double> paramets = new Dictionary<string, double>();
            var result = batting_stats
               .Where(i => i.Value.b_ab > 375)
               .Select(item => new Arguments(item.Key, ((double)(item.Value.b_double + item.Value.b_triple + item.Value.b_home_run) / (double)item.Value.b_ab)))
               .OrderByDescending(item => item.num).ToList();
            Console.WriteLine(result.Count());
            Console.WriteLine("Extra base/ab %");
            OutputToFile((List<Arguments>)result, "Extra base/ab %", path + "\\hittingXBasesPerAtBat.csv");


        }

        public static void CalculatePointsPerPlateAppearance(Dictionary<string, BattingRecord> batting_stats, string path)
        {
            var result = batting_stats
              .Where(i => i.Value.b_ab > 375)
              .Select(item => new Arguments(item.Key, ((double)(item.Value.b_single + item.Value.b_rbi + item.Value.r_run + item.Value.b_walk + item.Value.r_total_stolen_base + item.Value.b_double * 2 + item.Value.b_triple * 3 + item.Value.b_home_run * 4 - item.Value.b_strikeout) / (double)item.Value.b_total_pa)))
              .OrderByDescending(item => item.num).ToList();
            Console.WriteLine(result.Count());
            Console.WriteLine("Batting points/pa %");
            OutputToFile((List<Arguments>)result, "Batting points/pa %", path + "\\hittingPointsPerPA.csv");
        }

        public static void CalculatetotalPoints(Dictionary<string, BattingRecord> batting_stats, string path)
        {
            var result = batting_stats
              .Where(i => i.Value.b_ab > 375)
             .Select(item => new Arguments(item.Key, (item.Value.b_single + item.Value.b_rbi + item.Value.r_run + item.Value.b_walk + item.Value.r_total_stolen_base + item.Value.b_double * 2 + item.Value.b_triple * 3 + item.Value.b_home_run * 4 - item.Value.b_strikeout)))
             .OrderByDescending(item => item.num).ToList();
            Console.WriteLine(result.Count());
            Console.WriteLine("Total batting points");
            OutputToFile((List<Arguments>)result, "Total batting points", path + "\\hittingTotalPoints.csv");

        }
        public static void CalculateRBIEfficiency(Dictionary<string, BattingRecord> batting_stats, string path)
        {
            var result = batting_stats
              .Where(i => i.Value.b_ab > 375)
             .Select(item => new Arguments(item.Key, (((double)item.Value.b_rbi / (item.Value.b_rbi + item.Value.b_lob)))))
             .OrderByDescending(item => item.num).ToList();
            Console.WriteLine(result.Count());
            Console.WriteLine("RBI Efficiency");
            OutputToFile((List<Arguments>)result, "RBI Efficiency", path + "\\RBIEfficiency.csv");

        }

        public static void CalculateRBIEfficiencyMinusHR(Dictionary<string, BattingRecord> batting_stats, string path)
        {
            var result = batting_stats
              .Where(i => i.Value.b_ab > 375)
             .Select(item => new Arguments(item.Key, (((double)(item.Value.b_rbi - item.Value.b_home_run) / (item.Value.b_rbi + item.Value.b_lob)))))
             .OrderByDescending(item => item.num).ToList();
            Console.WriteLine(result.Count());
            Console.WriteLine("RBI Efficiency Minus HR RBI");
            OutputToFile((List<Arguments>)result, "RBI Efficiency Minus HR RBI", path + "\\RBIEfficiencyMinusHR.csv");

        }

        public static void CalculateRBIEfficiencyMinusHR2(Dictionary<string, BattingRecord> batting_stats, string path)
        {
            var result = batting_stats
              .Where(i => i.Value.b_ab > 375)
             .Select(item => new Arguments(item.Key, (((double)(item.Value.b_rbi - item.Value.b_home_run) / (item.Value.b_rbi - item.Value.b_home_run + item.Value.b_lob)))))
             .OrderByDescending(item => item.num).ToList();
            Console.WriteLine(result.Count());
            Console.WriteLine("RBI Efficiency Minus HR RBI2");
            OutputToFile((List<Arguments>)result, "RBI Efficiency Minus HR RBI2", path + "\\RBIEfficiencyMinusHR2.csv");

        }
        public static void CalculatePitchingPointsPerGame(Dictionary<string, PitchingRecord> pitching_stats, string path)
        {
            var result = pitching_stats
               .Where(i => i.Value.p_formatted_ip > 89)
               .Select(item => new Arguments(item.Key, (((double)(item.Value.p_formatted_ip + (item.Value.p_win * 6) + item.Value.p_strikeout) + (item.Value.p_quality_start * 3) - (item.Value.p_loss * 3)) / (double)item.Value.p_game), item.Value.p_game))
               .OrderByDescending(item => item.num).ToList();
            Console.WriteLine(result.Count());
            Console.WriteLine("Points/game %");
            OutputToFile((List<Arguments>)result, "Pitching points/game %", path + "\\pitchingPointsPerGame.csv");
        }

        public static void CalculatePitchingTotalPoints(Dictionary<string, PitchingRecord> pitching_stats, string path)
        {
            var result = pitching_stats
              .Where(i => i.Value.p_formatted_ip > 89)
              .Select(item => new Arguments(item.Key, (item.Value.p_formatted_ip + (item.Value.p_win * 6) + item.Value.p_strikeout) + (item.Value.p_quality_start * 3) - (item.Value.p_loss * 3)))
              .OrderByDescending(item => item.num).ToList();
            Console.WriteLine(result.Count());
            Console.WriteLine("Total Pitching points");
            OutputToFile((List<Arguments>)result, "Total pitching points", path + "\\pitchingTotalPoints.csv");
        }

        public static void OutputToFile(List<Arguments> result, string message, string path)
        {
            int j = 1;
            if (FileChecks(path) == "n")
            {
                Console.WriteLine("file exists and not to be deleted");
                return;
            }

            try
            {
                using (StreamWriter sr = new StreamWriter(path, true))
                {

                    sr.WriteLine(message);
                    sr.WriteLine(result.Count);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var res in result)
            {
                Console.Write(j + ")  ");
                Console.Write(res.name + "  ");
                Console.Write(res.num + "  ");
                if (res.games != null)
                {
                    Console.WriteLine(res.games);
                }
                else
                {
                    Console.WriteLine();
                }

                try
                {
                    using (StreamWriter sr = new StreamWriter(path, true))
                    {

                        sr.Write(j + ")  ");
                        sr.Write(res.name + "  ");
                        sr.Write(res.num + "  ");
                        if (res.games != null)
                        {
                            sr.WriteLine(res.games);
                        }
                        else
                        {
                            sr.WriteLine();
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                j++;
            }
        }

        //checks if file exists and prompts to either keep or delete old file
        private static string FileChecks(string path)
        {
            string answer = "y";
            if (File.Exists(path))
            {
                Console.WriteLine("The file exists, do you want to delete it?  n/y");
                try
                {

                    answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        File.Delete(path);
                        Console.WriteLine("File Deleted");

                    }
                    return answer;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return answer;

        }

        public static string ValidatePath(string path)
        {
            if (Directory.Exists(path) || (path == "n" || path == "N"))
            {
                return path;
            }
            else
            {
                Console.WriteLine("Invalid path... exiting program");
                Console.ReadLine();
                Environment.Exit(0);
                return "-1";
            }
        }

    }
}
