using HB_MarsRover.Data.Enums;
using HB_MarsRover.Data.Models;
using HB_MarsRover.Helpers;
using HB_MarsRover.Interfaces;
using HB_MarsRover.Services;
using System;

namespace HB_MarsRover
{
    class Program
    {
        // Surface and Rover services
        public static ISurfaceService ss = new SurfaceService();
        public static IRoverService rs = new RoverService();

        // Console.Writeline colors
        public static ConsoleColor QuestionColor = ConsoleColor.Yellow;
        public static ConsoleColor ErrorColor = ConsoleColor.Red;
        public static ConsoleColor SuccessColor = ConsoleColor.Green;
        static void Main(string[] args)
        {
            // Main Application While Loop
            while (true)
            {
                // Determine surface area 
                ConsoleHelper.WriteLine("Enter surface area width and height (Ex = 5 5):", QuestionColor);
                var size = Console.ReadLine();

                // Call SurfaceService -> CreateSurfaceMethod
                // Create surface if there is a valid input
                var res = ss.CreateSurface(size);

                // There is an input error from Determine Surface Area
                if (!res.IsSuccess)
                {
                    ConsoleHelper.WriteLine(res.Message,ErrorColor);
                    continue ;
                }

                SurfaceModel oSurface = res.Data;

                // Add Rover While Loop
                while (true)
                {
                    RoverModel rover = new RoverModel();

                    // Rover Position While Loop
                    while (true)
                    {
                        // Determine rover position
                        ConsoleHelper.WriteLine("Enter rover position seperate space between 2 digits and direction (Ex : 3 3 E) :", QuestionColor);
                        string roverPosition = Console.ReadLine();

                        // Call RoverService -> SetRoverPosition
                        // Set Rover Position if there is a valid input
                        var oRes = rs.SetRoverPosition(rover, roverPosition.ToUpper(), oSurface);

                        if (oRes.IsSuccess)
                        {
                            rover = oRes.Data;
                            break;
                        }

                        // There is an input error from rover position
                        ConsoleHelper.WriteLine(oRes.Message,ErrorColor);
                    }

                    // Rover Movement While Loop
                    while (true)
                    {
                        // Determine rover movement
                        ConsoleHelper.WriteLine("Enter Rover Movement L:Left R:Right M:Move (Ex : LMRMMMRM):", QuestionColor);
                        string roverMovement = Console.ReadLine();

                        // Call RoverService -> SetRoverMovement
                        // Set Rover Movement if there is a valid input
                        var oRes = rs.SetRoverMovement(rover, roverMovement.Trim(), oSurface);

                        if (oRes.IsSuccess)
                        {
                            rover.Movement = roverMovement;
                            oSurface.Rovers.Add(rover);
                            break;
                        }

                        // There is an input error from rover movement
                        ConsoleHelper.WriteLine(oRes.Message,ErrorColor);
                    }

                    ConsoleHelper.WriteLine($"Do you want to add {oSurface.Rovers.Count+1}. rover ? (Y/N)",QuestionColor);
                    string newRover = Console.ReadLine();

                    if (!newRover.ToLower().Equals("y"))
                    {
                        break;
                    }
                }

                //Calculate each rover movements
                for (int a = 0; a < oSurface.Rovers.Count; a++)
                {
                    var item = oSurface.Rovers[a];
                    int lastDirection = (int)item.Direction; // N W S E
                    string roverMovement = item.Movement; // L R M

                    for (int i = 0; i < roverMovement.Length; i++)
                    {
                        var rotateChar = roverMovement[i].ToString();
                        int rotate = (int)EnumHelper.GetValueFromDescription<MovementEnum>(rotateChar);
                        // If next movement is L or R
                        // Change the rover direction
                        if (rotate == (int)MovementEnum.Left || rotate == (int)MovementEnum.Right)
                        {
                            lastDirection = DirectionHelper.TurnByMovement(lastDirection, rotate);
                            continue;
                        }
                        else if (rotate == (int)MovementEnum.Move)
                        {
                            // Call RoverService -> MoveRover
                            // Move Rover with the given rovers last direction
                            var resp = rs.MoveRover(item, lastDirection);
                            if (resp.IsSuccess)
                            {
                                item = resp.Data;
                            }
                        }
                    }

                    // Call RoverService -> GetRoverPositionMessage
                    // Get the rovers last position with message, if its in surface area or not
                    var posRes = rs.GetRoverPositionMessage(item, oSurface);
                    ConsoleHelper.WriteLine($"{a+1}. {posRes.Message}",SuccessColor);
                }
            }
        }
    }
}
