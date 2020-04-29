using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SystemOfLinearEqualations
    {
        //Fields
        private List<LinearEquation> system;
        private int n;

        /// <summary>
        /// Constructor with certain number of variables
        /// </summary>
        /// <param name="n">Number of variables in each equalation</param>
        public SystemOfLinearEqualations(int n)
        {
            this.n = n;
            system = new List<LinearEquation>(n);
        }

        public LinearEquation this[int i]
        {
            get {return system[i]; }
            set {system[i] = value; }
        }

        public void Add(LinearEquation a)
        {
            if (a.Degree == n + 1)
                system.Add(a);
            else
                throw new IndexOutOfRangeException();
        }

        public void Delete(int index)
        {
            system.RemoveAt(index);
        }
        public int Count => system.Count;
        
        public void SteppingView()
        {
            int c, z;
            double p1, p2;
            for(int i=0;i<Count;i++)
            {
                z = i;
                if(this[i][z]==0)
                {
                    while (this[i][z] == 0 && z < n)
                        z++;
                    c = 1;
                    while ((i + c) < Count && this[i + c][z] == 0)
                        c++;
                    if (i + c == Count)
                        return;
                    Swap( this[i],this[i + c]);
                    for(int j =i+1;j<Count;j++)
                    {
                        p1 = this[i][z];
                        p2 = this[j][z];
                        this[j] = this[j] * p1 - this[i] * p2;
                    }
                }
            }
        }

        public double[] Solve()
        {
            while (this[Count - 1].Null)
                this.Delete(Count - 1);
            if (this[Count - 1])
            {
                if (Count == n)
                {
                    double[] solution = new double[n];
                    for (int i = Count - 1; i > 0; i++)
                    {
                        solution[i] = this[i][n];
                        for (int j = i + 1; j < n; j++)
                        {
                            solution[i] -= this[i][j] * solution[j];
                        }
                        solution[i] /= this[i][i];
                    }
                    return solution;
                }
                else
                    throw new AggregateException();
            }
            else throw new ArgumentException();

                    

        }

        private void Swap(LinearEquation a,LinearEquation b)
        {
            LinearEquation temp = new LinearEquation(a);
            a = b;
            b = temp;

        }
    }
}
