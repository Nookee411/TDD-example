using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class LinearEquation
    {
        //Fields
        private List<double> coef = new List<double>(); //coefficients at x^index

        //Constructors
        public LinearEquation()
        {
            this.coef.Add(0);
        }
        /// <summary>
        /// Indexes starts from free coef and index matches degree of X. Last index is what it equals
        /// </summary>
        /// <param name="coef"></param>
        public LinearEquation(double[] coef)
        {
            for (int i = 0; i < coef.Length; i++)
                this.coef.Add(coef[i]);
        }
        public LinearEquation(string coef)
        {
            List<string> tempStorage = coef.Split(' ').ToList();
            for (int i = 0; i < tempStorage.Count; i++)
            {
                if (tempStorage[i] == " ")
                    tempStorage.RemoveAt(i);
                tempStorage[i].Trim();
                this.coef.Add(double.Parse(tempStorage[i]));
            }
        }
        public LinearEquation(List<double> coef)
        {
            this.coef = coef;
        }
        public LinearEquation(int degree, double equal)
        {
            this.coef = Enumerable.Repeat(0.0, degree).ToList();
            this.coef.Add(equal);
        }
        //Properties
        public int Degree => this.coef.Count - 2;


        //Methods
        public void SetRandom(double maxnum, double minnum)
        {
            Random rand = new Random();
            for (int i = 0; i <= Degree; i++)
                coef[i] = rand.NextDouble() / (maxnum - minnum) + minnum;
        }
        public void SetNum(double num)
        {
            for (int i = 0; i <= Degree; i++)
                coef[i] = num;
        }
        //Override
        public override string ToString()
        {
            string res = "";
            for (int i = Degree; i >= 0; i--)
            {
                //if(coef[i]!=0)
                res += ((coef[i] >= 0) ? " +" : " ") + coef[i].ToString() + "x^" + i.ToString();
            }
            res += $" = {coef[coef.Count - 1]}";
            return res;
        }

        public override bool Equals(Object obj)
        {
            LinearEquation temp = (LinearEquation)obj;
            bool res = true;
            if (this.Degree != temp.Degree)
                res = false;
            else
            {
                for (int i = 0; i < this.Degree + 1; i++)
                    if (this[i] != temp.Degree)
                        res = false;
            }
            return res;
        }

        public override int GetHashCode()
        {
            int sum = 0;
            foreach (int ele in this.coef)
                sum += ele;
            return sum;
        }

        //Index override
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= coef.Count)
                    throw new IndexOutOfRangeException();
                if (index == Degree + 1)
                    return coef[Degree + 1];
                else
                    return coef[Degree - index];
            }
            set
            {
                if (index < 0 || index >= coef.Count)
                    throw new IndexOutOfRangeException();
                if (index == Degree + 1)
                    coef[Degree + 1] = value;
                else
                    coef[Degree - index] = value;
            }
        }
        //Operators

        public static LinearEquation operator +(LinearEquation Fpol, LinearEquation Spol)
        {
            LinearEquation result = new LinearEquation();
            if (Fpol.Degree > Spol.Degree)
            {
                result.coef = Spol.coef.Concat(Enumerable.Repeat(0.0, Fpol.Degree - Spol.Degree).ToList()).ToList();
                result.coef = Fpol.coef.Zip(result.coef, (x, y) => x + y).ToList();
            }
            else
            {
                result.coef = Fpol.coef.Concat(Enumerable.Repeat(0.0, Spol.Degree - Fpol.Degree).ToList()).ToList();
                result.coef = Spol.coef.Zip(result.coef, (x, y) => x + y).ToList();
            }
            return result;
        }

        public static LinearEquation operator -(LinearEquation Fpol, LinearEquation Spol)
        {
            LinearEquation result = new LinearEquation();
            if (Fpol.Degree > Spol.Degree)
            {
                result.coef = Spol.coef.Concat(Enumerable.Repeat(0.0, Fpol.Degree - Spol.Degree).ToList()).ToList();
                result.coef = Fpol.coef.Zip(result.coef, (x, y) => x - y).ToList();
            }
            else
            {
                result.coef = Fpol.coef.Concat(Enumerable.Repeat(0.0, Spol.Degree - Fpol.Degree).ToList()).ToList();
                result.coef = Spol.coef.Zip(result.coef, (x, y) => y - x).ToList();
            }
            return result;
        }

        public static LinearEquation operator -(LinearEquation pol)
        {
            for (int i = 0; i <= pol.Degree; i++)
                pol[i] = -pol[i];
            return pol;
        }

        public static LinearEquation operator *(LinearEquation pol, double k)
        {
            for (int i = 0; i <= pol.Degree; i++)
                pol[i] *= k;
            return pol;
        }

        public static LinearEquation operator *(double k, LinearEquation pol)
        {
            for (int i = 0; i <= pol.Degree; i++)
                pol[i] *= k;
            return pol;
        }

        public static bool operator ==(LinearEquation fpol, LinearEquation spol)
        {
            if (fpol.Degree != spol.Degree)
                return false;
            for (int i = 0; i < fpol.Degree + 1; i++)
                if (fpol[i] != spol[i])
                    return false;
            return true;
        }
        public static bool operator !=(LinearEquation fpol, LinearEquation spol)
        {
            bool isequal = true;
            for (int i = 0; i < Math.Min(fpol.Degree, spol.Degree) + 1; i++)
                if (fpol[i] != spol[i])
                    isequal = false;
            return !isequal;
        }

        public static bool operator true(LinearEquation a)
        {
            bool Allzero = true;
            for (int i = 0; i <= a.Degree; i++)
                if (a.coef[i] != 0)
                    Allzero = false;
            if (Allzero && a.coef[a.Degree + 1] != 0)
                return false;
            else
                return true;
        }
        public static bool operator false(LinearEquation a)
        {
            bool Allzero = true;
            for (int i = 0; i <= a.Degree; i++)
                if (a.coef[i] != 0)
                    Allzero = false;
            if (Allzero && a.coef[a.Degree + 1] != 0)
                return true;
            else
                return false;
        }

        public bool Null
        {
            get
            {
                foreach(double ele in coef)
                    if(ele!=0)
                        return false;
                return true;
            }

        }


        public static implicit operator List<double>(LinearEquation a)
        {
            return a.coef;
        }
    }
}
