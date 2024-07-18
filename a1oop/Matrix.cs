using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace a1oop
{
    public class Matrix
    {
        #region Exceptions
        public class IndexOutOfRangeException : Exception {}
        public class NoSizeMatchException : Exception { }
        public class WrongInputFormatException : Exception {}
        #endregion

        #region Attributes
        private int size;
        private List<int> chess;
        #endregion



        #region Constructor
        public Matrix(int size)
        {
            this.size = size;
            this.chess = new List<int>(size);
        }
        #endregion

        #region Getters/Setters
        public int GetSize()
        {
            return size;

        }

        public void setMatrix(int e)
        {
            chess.Add(e);
        }

        public int getEntry(int i, int j)
        {
            if (i < 0 || j < 0 || i >= size || j >= size)
            {
                throw new IndexOutOfRangeException();
            }
            else if ((i + j) % 2 == 0)
            {
                if (indexOf(i, j) < chess.Count)
                {
                    return chess[indexOf(i, j)];
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }



        public int indexOf(int i, int j)
        {
            return (i * size + j) / 2;
        }
        
        public void setEntry(int i, int j, int value)
        {
            if (i < 0 || j < 0 || i >= size || j >= size)
            {
                throw new IndexOutOfRangeException();
            }

            int index = indexOf(i, j);

            while (chess.Count <= index)
            {
                chess.Add(0);
            }

            chess[index] = value;
        }
        #endregion

        #region

        public static Matrix add(Matrix a, Matrix b)
        {
            Matrix sum = new Matrix(a.size);
            sum.chess = new List<int>(new int[a.chess.Count]);
            if (a.size != b.size)
                throw new NoSizeMatchException();
            else
                for (int i = 0; i < a.chess.Count; ++i)
                    sum.chess[i] = a.chess[i] + b.chess[i];

            return sum;
        }

        
        public static Matrix multiply(Matrix a, Matrix b)
        {
            Matrix prod = new Matrix(a.size);

            if (a.size != b.size)
            {
                throw new NoSizeMatchException();
            }

            for (int i = 0; i < a.size; i++)
            {
                for (int j = 0; j < a.size; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        int sum = 0;
                        for (int k = 0; k < a.size; k++)
                        {
                            if ((i + k) % 2 == 0 && (k + j) % 2 == 0)
                            {
                                sum += a.getEntry(i, k) * b.getEntry(k, j);
                            }
                        }
                        prod.setEntry(i, j, sum);
                    }
                }
            }
            return prod;
        }




        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"The size: {size}x{size}");

            int entryIndex = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        if (entryIndex < chess.Count)
                        {
                            str.Append($"{chess[entryIndex]} ");
                            entryIndex++;
                        }
                        else
                        {
                            str.Append("0 ");
                        }
                    }
                    else
                    {
                        str.Append("0 ");
                    }
                }
                str.AppendLine();
            }

            return str.ToString();
        }
        #endregion

    }
}
