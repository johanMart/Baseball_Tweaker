using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BaseballTweaker_V2.File_I_O;
using BaseballTweaker_V2.Model;

namespace BaseballTweaker_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Baseball Tweaker in here!");

            Console.WriteLine("Input the directory for the batting stats EXCLUDING the file name and EXCLUDING the final \\ of the path string. Press n or N to use the default directory");
            string batting_stats_directory = Console.ReadLine();
            string validated_batting_directory = ValidatePath(batting_stats_directory);

            Console.WriteLine("Input the path for the pitching stats EXCLUDING the file name and EXCLUDING the final \\ of the path string.  Press n or N to use default directory");
            string pitching_stats_directory = Console.ReadLine();
            string validated_pitching_directory = ValidatePath(pitching_stats_directory);

            Console.WriteLine("Input the file name where the batting stats are located.  Press n or N for default file name");
            string batting_stats_file_name = Console.ReadLine();

            Console.WriteLine("Input the file name where the pitching stats are located.  Press n or N for default file name");
            string pitching_stats_file_name = Console.ReadLine();

            var batting_stats = new Dictionary<string, BattingRecord>();
            var pitching_stats = new Dictionary<string, PitchingRecord>();

            if ((validated_batting_directory == "n" || validated_batting_directory == "N") || batting_stats_file_name == "n" || batting_stats_file_name == "N" || (validated_batting_directory + "\\" + batting_stats_file_name) == @"G:\Users\James\Documents\Baseball Tweaker Data Files\hitting stats part 3.csv")
            {
                batting_stats = Input.RetrieveAllBattingRecords();
            }
            else
            {
                ValidateFile(validated_batting_directory + "\\" +batting_stats_file_name);
                batting_stats = Input.RetrieveAllBattingRecords(validated_batting_directory + "\\" + batting_stats_file_name);
            }
            if ((validated_pitching_directory == "n" || validated_pitching_directory == "N") || pitching_stats_file_name == "n" || pitching_stats_file_name == "N" || (validated_pitching_directory + "\\" + pitching_stats_file_name) == @"G:\Users\James\Documents\Baseball Tweaker Data Files\pitching stats.csv")
            {
                pitching_stats = Input.RetrieveAllPitchingRecords();
            }
            else
            {
                ValidateFile(validated_pitching_directory + "\\" + pitching_stats_file_name);
                pitching_stats = Input.RetrieveAllPitchingRecords(pitching_stats_directory + "\\" + pitching_stats_file_name);
            }

            Console.WriteLine("Input the path for the batting results EXCLUDING the file name and EXCLUDING the final \\ of the path string.");
            string batting_results_path = Console.ReadLine();
            string validated_batting_results_path = ValidatePath(batting_results_path);

            Console.WriteLine("Input the path for the pitching results EXCLUDING the file name and EXCLUDING the final \\ of the path string.");
            string pitching_results_path = Console.ReadLine();
            string validated_pitching_results_path = ValidatePath(pitching_results_path);


            if (batting_stats != null)
            {
                OutputToConsole.CalculateExtraBasesPerAtBat(batting_stats, validated_batting_results_path);
                OutputToConsole.CalculatePointsPerPlateAppearance(batting_stats, validated_batting_results_path);
                OutputToConsole.CalculatetotalPoints(batting_stats, validated_batting_results_path);
                OutputToConsole.CalculateRBIEfficiency(batting_stats, validated_batting_results_path);
                OutputToConsole.CalculateRBIEfficiencyMinusHR(batting_stats, validated_batting_results_path);
                OutputToConsole.CalculateRBIEfficiencyMinusHR2(batting_stats, validated_batting_results_path);
            }
            else
            {
                Console.WriteLine("An Error Occurred either the path does not exist or the csv file does not match the Model");
            }
            if (pitching_stats != null)
            {
                OutputToConsole.CalculatePitchingPointsPerGame(pitching_stats, validated_pitching_results_path);
                OutputToConsole.CalculatePitchingTotalPoints(pitching_stats, validated_pitching_results_path);
            }
            else
            {
                Console.WriteLine("An Error Occurred either the path does not exist or the csv file does not match the Model");
            }


            Console.ReadLine();
        }

        private static string ValidatePath(string path)
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

        private static string ValidateFile(string path)
        {
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                Console.WriteLine("Invalid file... exiting program");
                Console.ReadLine();
                Environment.Exit(0);
                return "-1";
            }
        }
    }
}
