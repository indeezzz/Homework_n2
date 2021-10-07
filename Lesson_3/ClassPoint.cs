using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    public class ClassPoint
    {
        private double x, y;
        public double X
        {
            get { return x; }
            set
            {
                Type tp = value.GetType();
                if (tp.Equals(typeof(double)))
                {
                    x = Convert.ToDouble(value);
                }
                else if (tp.Equals(typeof(float)))
                {
                    x = value;
                }
                else if (tp.Equals(typeof(int)))
                {
                    x = Convert.ToInt32(value);
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                Type tp = value.GetType();
                if (tp.Equals(typeof(double)))
                {
                    
                    y = Convert.ToDouble(value);
                }
                else if (tp.Equals(typeof(float)))
                {
                    y = value;
                }
                else if (tp.Equals(typeof(int)))
                {
                    y = Convert.ToInt32(value);
                }
            }
        }
        public ClassPoint()
        {
            x = y = 0.0;
        }
        public ClassPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public ClassPoint(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public ClassPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
