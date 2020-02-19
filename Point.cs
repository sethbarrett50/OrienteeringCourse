//This class was created by Seth Barrett and represents the Points in my orienteering project.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orienteering_Course_Solver
{
    class Point
    {
        public double _xCoor
        {
            get;set;
        }
        public double _yCoor
        {
            get;set;
        }
        //Initializes two properties to represent X&Y coordinates of the object.
        public string Show()
        {
            return $"[{_xCoor}, {_yCoor}]";
        }
        //This method returns the X&Y coordiantes of the object in string form.
        public Point Move(double feetP, int dirP)
        {
            double _ftXMove = (feetP * Math.Cos((dirP * (Math.PI)) / 180));
            double _ftYMove = (feetP * Math.Sin((dirP * (Math.PI)) / 180));
            if (dirP == 90 || dirP == 270) _ftXMove = 0;
            if (dirP == 0 || dirP == 180) _ftYMove = 0;
            Point Output = this;
            Output._xCoor += _ftXMove; Output._yCoor += _ftYMove;
            return Output;
        }
        //This object takes feet and degrees as parameters and changes returns a Point object with coordinates changed to represent the move based upon the given parameters.
    }
}
