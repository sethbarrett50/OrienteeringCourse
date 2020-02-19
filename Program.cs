/*
 * This project's goal is to solve the Klondike Orienteering Course. 
 * Created by Seth Barrett.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orienteering_Course_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            Line groundLine = new Line();
            Course OC;
            //Initializes course object and line object.

            Console.WriteLine("How many points are on the ground line?");
            groundLine._numLinePts = UserInputVeri(1, 100, false);
            Console.WriteLine("How long is the ground line in feet?");
            groundLine._lineLength = UserInputVeri(1, 25000, false);
            Console.WriteLine("What direction in degrees does the line follow, facing from the starting value?");
            groundLine._lineDirection = UserInputVeri(0, 359, false);
            //Takes the user's inputs and verifies them before setting the groundLine's values.

            groundLine.MakeLine();
            Console.WriteLine($"The starting line is represented by these coordinates:{groundLine.ShowAll()}");
            //Creates the points and their values for the starting line.

            Console.WriteLine("Which point are you starting at?");
            OC = new Course(groundLine.GetPt(UserInputVeri(0, groundLine._numLinePts, groundLine._numLinePts <= 26)));
            Console.WriteLine("How many instructions are there?");
            OC._numDirections = UserInputVeri(0, 1000, false);
            //Takes the user's inputs and verifies them before setting the OC's values.

            Console.WriteLine(groundLine.Closest(OC.FindEnd()));
            //This runs through all the directions for OC and write the Point on groundLine that is the closest to it.
        }
        static int UserInputVeri(int lowerBound, int upperBound, bool letter)
        {
            bool flag = false;
            bool realLet = false;
            int output = 0;
            char charput;
            if (letter)
            {
                while (!flag)
                {
                    string input = Console.ReadLine();
                    realLet = char.TryParse(input, out charput);
                    if (realLet)
                    {
                        int place = (int)charput;
                        if (place >= 65 && place <= 90)return output = place - 65;
                        else if(place >= 97 && place <= 122)return output = place - 97;
                        else flag = int.TryParse(input, out output);
                    }
                    else flag = int.TryParse(input, out output);

                    if (!flag || output < lowerBound || output > upperBound) Console.WriteLine("Please enter a valid value");
                }
            }
            else
            {
                while (!flag || output < lowerBound || output > upperBound)
                {
                    flag = int.TryParse(Console.ReadLine(), out output);
                    if (!flag || output < lowerBound || output > upperBound) Console.WriteLine("Please enter a valid value");
                }
            }
            return output;
        }
        //This method does user input verification for allowed int values and certain char values based upon the parameters.
    }
}
