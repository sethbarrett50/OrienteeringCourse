//This class was created by Seth Barrett to represent the course section of an Orienteering Course.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orienteering_Course_Solver
{
    class Course
    {
        Point CurrentPoint;
        public int _numDirections
        {
            get; set;
        }
        //Initializes a point object and a property representing the number of directions.
        public Course(Point startP)
        {
            CurrentPoint = startP;
        }
        //This method takes a Point object as a parameter and sets the Point object CurrentPoint to it.
        public Point FindEnd()
        {
            for(int i = 0; i < _numDirections; i++)
            {
                Console.WriteLine($"How many feet do you move in instruction {i + 1}?");
                int _ftMove = UserInputVeri(1, 20000);
                Console.WriteLine($"What direction do you move in instruction {i + 1}?");
                int _dirMove = UserInputVeri(0, 359);
                CurrentPoint.Move(_ftMove, _dirMove);
            }
            return CurrentPoint;
        }
        //This method takes an user input for degrees and feet for each instruction and returns a point at the final coordinates.
        static int UserInputVeri(int lowerBound, int upperBound)
        {
            bool flag = false;
            int output = 0;
            while (!flag || output < lowerBound || output > upperBound)
            {
                flag = int.TryParse(Console.ReadLine(), out output);
                if (!flag || output < lowerBound || output > upperBound) Console.WriteLine("Please enter a valid value");
            }
            return output;
        }
        //This is an integer input verifier for number of players that takes an upper and lower bound.
    }
}
