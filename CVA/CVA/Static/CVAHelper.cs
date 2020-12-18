using System;
using System.Collections.Generic;

namespace CVA.Static
{
    public static class CVAHelper
    {
        public const double DegToRad = Math.PI / 180;
        public static double Clamp(double value, double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentException();
            }
            if (value > max)
            {
                return max;
            }
            else if (value < min)
            {
                return min;
            }
            else
            {
                return value;
            }
        }
        public static double LoopClamp(double value, double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentException();
            }

            if (value > max)
            {
                int loopCount = (int)((value - min) / (max - min));
                return value - ((max - min) * loopCount);
            }
            else if (value < min)
            {
                int loopCount = (int)((value - min) / (max - min));
                return value + ((max - min) * (loopCount + 1));
            }
            else
            {
                return value;
            }
        }
        public static double Abs(double value)
        {
            if (value < 0)
            {
                return value * -1;
            }
            else
            {
                return value;
            }
        }
        public static double Min(double a, double b)
        {
            if (a < b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        public static double Max(double a, double b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        public static double Sqrt(double value)
        {
            return Math.Sqrt(value);
        }
        public static double Sqr(double value)
        {
            return value * value;
        }
        public static double Lerp(double sample, double a, double b)
        {
            return a + ((b - a) * sample);
        }
        public static double InverseLerp(double sample, double a, double b)
        {
            return (sample - a) / (b - a);
        }
        public static double DegreeClamp(double inputDegree)
        {
            while (inputDegree > 360)
            {
                inputDegree -= 360;
            }
            while (inputDegree < 0)
            {
                inputDegree += 360;
            }
            return inputDegree;
        }
        public static double DegreeDifference(double degreeA, double degreeB)
        {
            degreeA = DegreeClamp(degreeA);
            degreeB = DegreeClamp(degreeB);
            double Output = Math.Abs(degreeA - degreeB);
            if (Output > 180)
            {
                Output = 360 - Output;
            }
            return Math.Abs(Output);
        }
        public static Vector VectorFromDirection(double direction, double magnitude)
        {
            return new Vector(Math.Cos(direction * DegToRad), Math.Sin(direction * DegToRad)) * magnitude;
        }
        public static Vector VectorFromDirection(double direction)
        {
            return VectorFromDirection(direction, 1);
        }
        public static double Distance(Vector vectorA, Vector vectorB)
        {
            return Math.Sqrt(((vectorA.x - vectorB.x) * (vectorA.x - vectorB.x)) + ((vectorA.y - vectorB.y) * (vectorA.y - vectorB.y)));
        }
        public static Vector ClampUnitCircle(Vector inputVector)
        {
            double Distance = VectorMagnitude(inputVector);
            return new Vector(inputVector.x / Distance, inputVector.y / Distance);
        }
        public static Vector RotateVector(Vector input, double rotation)
        {
            double ca = Math.Cos(rotation * DegToRad);
            double sa = Math.Sin(rotation * DegToRad);
            return new Vector(ca * input.x - sa * input.y, sa * input.x + ca * input.y);
        }
        public static double VectorDirection(Vector inputVector)
        {
            inputVector = ClampUnitCircle(inputVector);
            double Output = RadiansToDegrees(Math.Atan(Math.Abs(inputVector.x) / Math.Abs(inputVector.y)));
            if (inputVector.x >= 0 && inputVector.y >= 0)
            {
                return 90 - Output;
            }
            else if (inputVector.x < 0 && inputVector.y >= 0)
            {
                return 90 + Output;
            }
            else if (inputVector.x < 0 && inputVector.y < 0)
            {
                return 180 + (90 - Output);
            }
            else if (inputVector.x >= 0 && inputVector.y < 0)
            {
                return 270 + Output;
            }
            else
            {
                return Output;
            }
        }
        public static double RadiansToDegrees(double value)
        {
            return 360 / Math.PI * 2 * value;
        }
        public static double VectorMagnitude(Vector inputVector)
        {
            return Math.Sqrt((inputVector.x * inputVector.x) + (inputVector.y * inputVector.y));
        }
        //Tringulation and Polygons
        public static List<List<Vector>> Triangulate(List<Vector> polygonPoints)
        {
            List<List<Vector>> Output = new List<List<Vector>>();
            while (polygonPoints.Count > 3)
            {
                int First_Convex_Vertice = -1;
                for (int i = 0; i < polygonPoints.Count; i++)
                {
                    if (!VerticeConcave(polygonPoints, i))
                    {
                        First_Convex_Vertice = i;
                        break;
                    }
                }
                if (First_Convex_Vertice >= 0 && First_Convex_Vertice < polygonPoints.Count)
                {
                    Vector Point_A = polygonPoints[First_Convex_Vertice];
                    Vector Point_B = polygonPoints[First_Convex_Vertice];
                    Vector Point_C = polygonPoints[First_Convex_Vertice];
                    if (First_Convex_Vertice - 1 < 0)
                    {
                        Point_A = polygonPoints[polygonPoints.Count - 1];
                    }
                    else
                    {
                        Point_A = polygonPoints[First_Convex_Vertice - 1];
                    }
                    if (First_Convex_Vertice + 1 >= polygonPoints.Count)
                    {
                        Point_C = polygonPoints[0];
                    }
                    else
                    {
                        Point_C = polygonPoints[First_Convex_Vertice + 1];
                    }
                    Output.Add(new List<Vector>() { Point_A, Point_B, Point_C });
                    polygonPoints.RemoveAt(First_Convex_Vertice);
                }
                else
                {
                    Output.Add(polygonPoints);
                    return Output;
                }
            }
            Output.Add(polygonPoints);
            return Output;
        }
        public static bool PolygonConcave(List<Vector> polygonPoints)
        {
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                if (VerticeConcave(polygonPoints, i))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool VerticeConcave(List<Vector> polygonPoints, int pointIndex)
        {
            Vector Point_A = polygonPoints[pointIndex];
            Vector Point_B = polygonPoints[pointIndex];
            Vector Point_C = polygonPoints[pointIndex];
            if (pointIndex - 1 < 0)
            {
                Point_A = polygonPoints[polygonPoints.Count - 1];
            }
            else
            {
                Point_A = polygonPoints[pointIndex - 1];
            }
            if (pointIndex + 1 >= polygonPoints.Count)
            {
                Point_C = polygonPoints[0];
            }
            else
            {
                Point_C = polygonPoints[pointIndex + 1];
            }
            double Degree_AB = VectorDirection(new Vector(Point_A.x - Point_B.x, Point_A.y - Point_B.y));
            double Degree_BC = VectorDirection(new Vector(Point_C.x - Point_B.x, Point_C.y - Point_B.y));
            if (Degree_BC > Degree_AB && Degree_BC - Degree_AB > 180)
            {
                return true;
            }
            else if (Degree_BC < Degree_AB && (360 - Degree_AB) + Degree_BC > 180)
            {
                return true;
            }
            return false;
        }
        //Lines and Stuff
        public static double DistanceToLine(Vector a, Vector b, Vector p)
        {
            return Distance(ClosestPointOnLine(a, b, p), p);
        }
        public static Vector ClosestPointOnLine(Vector lineStart, Vector lineEnd, Vector targetPoint)
        {
            Vector line = (lineEnd - lineStart);
            double len = VectorMagnitude(line);
            line = ClampUnitCircle(line);

            Vector v = targetPoint - lineStart;
            double d = /*Vector3.Dot(v, line)*/0;
            d = Clamp(d, 0f, len);
            return lineStart + line * d;
        }
        //Colors
        public static ColorRGB Mix(ColorRGB back, ColorRGB front)
        {
            return new ColorRGB((back.r + front.r) / 2.0, (back.g + front.g) / 2.0, (back.b + front.b) / 2.0);
        }
        public static ColorRGB Flatten(ColorRGB back, ColorRGBA front)
        {
            if (front.a == 0)
            {
                return back;
            }
            else if (front.a == 1)
            {
                return new ColorRGB(front.r, front.g, front.b);
            }
            else
            {
                return new ColorRGB(Lerp(front.a, back.r, front.r), Lerp(front.a, back.g, front.g), Lerp(front.a, back.b, front.b));
            }
        }
    }
}