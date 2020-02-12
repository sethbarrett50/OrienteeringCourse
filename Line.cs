//This class was created by Seth Barrett, and is made to represent the starting line of an orienteering course.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orienteering_Course_Solver
{
    class Line
    {
        Point[] groundLine;
        public int _numLinePts
        {
            get;set;
        }
        public int _lineLength
        {
            get;set;
        }
        public int _lineDirection
        {
            get; set;
        }
        //These initialize my Point array and several properties.
        public void MakeLine()
        {
            double _ftBetweenPts = (double)_lineLength / (double)_numLinePts;
            groundLine = new Point[_numLinePts];
            for(int i = 0; i< groundLine.Length; i++)groundLine[i] = new Point();
            for(int i = 2; i < groundLine.Length; i++)
            {
                Point NextPoint = groundLine[i - 1].Move(_ftBetweenPts, _lineDirection);
                groundLine[i]._xCoor = NextPoint._xCoor;
                groundLine[i]._yCoor = NextPoint._yCoor;
            }
            groundLine[_numLinePts - 1].Move(_ftBetweenPts, _lineDirection);//This is done to include last point object in the array to move to the correct coordinates.
        }
        //This method creates an array of points using user input to create a line of points to represent the start line.
        public string Show(int i)
        {
            if (groundLine.Length <= 26)return $"{Convert.ToChar(i + 65)}:{groundLine[i].Show()} ";
            else return $"{i + 1}:{groundLine[i].Show()} ";
        }
        //This method shows a single point in the point array of a line object, and gives a different message depending on the length of the line.
        public string ShowAll()
        {
            string output = null;
            for(int i = 0; i < groundLine.Length; i++)output += this.Show(i);
            return output;
        }
        //This method uses the Show method to display all the points in the line object's point array.
        public Point GetPt(int _iP)
        {
            Console.WriteLine(_iP);
            return groundLine[_iP];
        }
        //This method returns a point based upon the parameter given.
        public string Closest(Point pointP)
        {
            double[] DistanceTo = new double[this._numLinePts];
            for(int i = 0; i < groundLine.Length; i++)
            {
                DistanceTo[i] = Math.Sqrt(Math.Pow((double)groundLine[i]._xCoor + pointP._xCoor, 2) + Math.Pow((double)groundLine[i]._yCoor + pointP._yCoor,2));
            }
            int _closestPt = 0;
            for(int i = 1; i < groundLine.Length; i++)
            {
                if(DistanceTo[i] < DistanceTo[i - 1])
                {
                    _closestPt = i;
                }
            }
            return $"The point on the groundline that is the closest to your end point is {groundLine[_closestPt].Show()} ";
        }
        //This method takes a point as a parameter and scans the point array in this line object and returns a string telling which point is closest in the array.
    }
}
