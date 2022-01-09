using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using File_I_O;

namespace BaseballTweaker_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Baseball Tweaker in here!");
            
            var batting_stats = Input.RetrieveAllBattingRecords();
            var pitching_stats = Input.RetrieveAllPitchingRecords();

            OutputToConsole.CalculateExtraBasesPerAtBat(batting_stats);
            OutputToConsole.CalculatePointsPerPlateAppearance(batting_stats);
            OutputToConsole.CalculatetotalPoints(batting_stats);
            OutputToConsole.CalculatePitchingPointsPerGame(pitching_stats);
            OutputToConsole.CalculatePitchingTotalPoints(pitching_stats);




            Console.ReadLine();
        }



        
    }
}
