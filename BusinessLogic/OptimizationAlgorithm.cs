using System;
using System.Collections.Generic;
using System.Linq;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.BusinessLogic
{
    public class OptimizationAlgorithm
    {
        public int Kolvo(double[] mas)
        {
            int fact = 0;
            for (int i = 1; i <= mas.Length - 1; i++)
            {
                fact += i;
            }
            return fact;
        }

        public int Factorial(int[,] mas)
        {
            int fact = 0;
            int rows = mas.GetUpperBound(0);
            for (int i = 1; i <= rows; i++)
            {
                fact += i;
            }
            return fact;
        }
        public int[,] DoubleMas(List<Order> orders)
        {
            int i = 0;
            int[,] mas = new int[orders.Count, 4];

            foreach (var order in orders)
            {
                mas[i, 0] = order.ValueBeginOfWork;
                mas[i, 1] = order.ValueEndOfWork;
                mas[i, 2] = order.Feedback;
                mas[i, 3] = order.Recommend;
                i++;
            }
            return mas;
        }


        public double[] Sum(int[,] mas, int startElement, int endElement)
        {
            int k = 0;
            double[] sum = new double[endElement];
            for (int i = startElement; i < endElement; i++)
            {
                sum[k] = Math.Sqrt((Math.Pow((mas[startElement, 0] - mas[i + 1, 0]), 2)) +
                        (Math.Pow((mas[startElement, 1] - mas[i + 1, 1]), 2)) + (Math.Pow((mas[startElement, 2] - mas[i + 1, 2]), 2))
                        + (Math.Pow((mas[startElement, 3] - mas[i + 1, 3]), 2)));
                k++;
            }
            return sum;
        }
        public double[] GetDistance(int[,] mas)
        {
            int a = 0;
            int fact = Factorial(mas);
            int length1 = 0;
            int rows = mas.GetUpperBound(0);
            int length = length1 + rows;
            double[] resultDistances = new double[fact];

            for (int i = 0; i < rows; i++)
            {
                var distances = Sum(mas, i, rows);
                for (int k = 0; k + i < distances.Length; k++)
                {
                    resultDistances[a] = distances[k];
                    a++;
                }
            }
            return resultDistances;
        }

        public double[] GetMin(double[] mas, int startElement, int endElement)
        {
            int k = 0;
            double[] dist = new double[mas.Length - 1];
            for (int i = startElement; i < endElement - 1; i++)
            {
                dist[k] = Math.Abs(mas[startElement] - mas[i + 1]);
                k++;
            }
            return dist;
        }
        public double[] GetThreePoints(double[] mas)
        {
            int a = 0;
            double[] resDis = new double[Kolvo(mas)];
            for (int i = 0; i < mas.Length - 1; i++)
            {
                var dis = GetMin(mas, i, mas.Length);
                for (int j = 0; j + i < mas.Length - 1; j++)
                {
                    resDis[a] = dis[j];
                    a++;
                }
            }
            return resDis;
        }

        public double[] GetResult(List<Order> orders)
        {
            var dist = GetDistance(DoubleMas(orders));
            var allDist = GetThreePoints(dist);
            Array.Sort(allDist);
            double min = allDist.Min();
            if (dist.Length > 3)
            {
                for (int i = 0; i < dist.Length; i++)
                {
                    for (int j = i + 1; j < dist.Length; j++)
                    {
                        if (Math.Abs(dist[i] - dist[j]) == min)
                        {
                            dist[i] = (dist[i] + dist[j]) / 2;
                            Array.Clear(allDist, 1, 1);
                            Array.Clear(dist, j, 1);
                            List<double> tmp = new List<double>(dist);
                            tmp.RemoveAt(j);
                            dist = tmp.ToArray();
                            break;
                        }
                    }
                }

            }
            //GetResult(valuations);
            return dist;
        }

        public double[] Res(double[] mas)
        {
            while (mas.Length > 3)
            {
                if (mas.Length > 3)
                {
                    var allDist = GetThreePoints(mas);
                    Array.Sort(allDist);
                    double min = allDist.Min();
                    for (int i = 0; i < mas.Length; i++)
                    {
                        for (int j = i + 1; j < mas.Length; j++)
                        {
                            if (Math.Abs(mas[i] - mas[j]) == min)
                            {
                                mas[i] = (mas[i] + mas[j]) / 2;
                                //Array.Clear(allDist, 1, 1);
                                Array.Clear(mas, j, 1);
                                List<double> tmp = new List<double>(mas);
                                tmp.RemoveAt(j);
                                mas = tmp.ToArray();
                            }
                        }
                    }

                }
            }
            return mas;
        }

        public List<double> GetMiddleValue(List<Order> orders)
        {
            List<double> middleValues = new List<double>();
            double middle = 0;
            double sum = 0;
            foreach (var order in orders)
            {
                sum = Convert.ToDouble(order.ValueBeginOfWork + order.ValueEndOfWork + order.Feedback + order.Recommend);
                middle = sum / 4;
                middleValues.Add(middle);
            }
            return middleValues;
        }
        public List<Order> Val(List<Order> orders)
        {
            double[] firstDistances = GetResult(orders);
            double[] finalDistances = Res(firstDistances);
            Array.Sort(finalDistances);
            List<double> middleValues = GetMiddleValue(orders);
            string status = "";
            List<Order> val = orders;
            int count = 0;

            //Statement
            foreach (var middleValue in middleValues)
            {

                if (Math.Abs(middleValue - finalDistances[0]) < Math.Abs(middleValue - finalDistances[1]))
                {
                    if (Math.Abs(middleValue - finalDistances[0]) < Math.Abs(middleValue - finalDistances[2]))
                    {

                        status = "Bad";

                    }
                    else
                    {
                        status = "Good";
                    }
                }
                else if (Math.Abs(middleValue - finalDistances[1]) < Math.Abs(middleValue - finalDistances[0]))
                {
                    if (Math.Abs(middleValue - finalDistances[1]) < Math.Abs(middleValue - finalDistances[2]))
                    {
                        status = "Norm";
                    }
                    else
                    {
                        status = "Good";
                    }
                }
                else
                {
                    status = "Good";
                }
                val[count].OrderStatement = status;
                count++;
            }

            return val;
        }
    }
}
