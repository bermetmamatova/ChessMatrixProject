using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a1oop
{
    internal class Menu
    {

        Matrix chess;
        private List<Matrix> collection = new List<Matrix>();

        public void run()
        {
            int s;
            do
            {
                s = UserSelection();
                switch (s)
                {
                    case 1:
                        Set();
                        break;
                    case 2:
                        Get();
                        break;

                    case 3:
                        Add();
                        break;
                    case 4:
                        Mult();
                        break;

                    case 5:
                       Print();
                       break;
                       
                  default:
                      Console.WriteLine("You have exitted! ");
                      break;
                      
                }
            } while (s != 0);

        }
        private static int UserSelection()
        {
            int s;
            do
            {
                Console.WriteLine("-----Please choose:----");
                Console.WriteLine("-----------------------");
                Console.WriteLine("0- Exit");
                Console.WriteLine("1- Insert");
                Console.WriteLine("2- Get the entry located at index (i, j)");
                Console.WriteLine("3- Add");
                Console.WriteLine("4- Multiply");
                Console.WriteLine("5- Print the Matrix");
                Console.WriteLine("-----------------------");



                try
                {
                    s = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("You chose " + s + ".");
                }
                catch (System.FormatException)
                {
                    s = -1;
                }
            } while (s < 0 || s > 5);
            return s;
        }
       
        private int GetInd()
        {
            if (collection.Count == 0) return -1;
            int i = 0;
            bool ok;
            do
            {
                Console.Write("Give a matrix index: ");
                ok = false;
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                }
                catch (Matrix.WrongInputFormatException)
                {
                    Console.WriteLine("Integer is expected!");
                }
                if (i <= 0 || i > collection.Count)
                {
                    ok = false;
                    Console.WriteLine("There is no such matrix!");
                }
            } while (!ok);
            return i - 1;
        }


        public void Set()
        {
            Console.WriteLine("Give the size of the matrix: ");
            int size = int.Parse(Console.ReadLine());
            chess = new Matrix(size);
            int total = (size % 2 == 0) ? (size * size) / 2 : ((size * size) + 1) / 2;

            for (int i = 0; i < total; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Please enter input #{i + 1} for the chess matrix: ");
                    string entry = Console.ReadLine();

                    try
                    {
                        chess.setMatrix(int.Parse(entry));
                        break;
                    }
                    catch (Matrix.NoSizeMatchException)
                    {
                        Console.WriteLine("Dimension mismatch! Please try again.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! Please enter an integer.");
                    }
                }
            }
            collection.Add(chess);
        }


        public void Get()
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("A matrix has not been created yet.");
                return;
            }
            int index = GetInd();
            int row = 0;
            int col = 0;

            while (true)
            {
                try
                {
                    Console.Write("Give the row index: ");
                    row = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Give the column index: ");
                    col = Convert.ToInt32(Console.ReadLine());

                    if (row <= 0 || col <= 0 || row > chess.GetSize() || col > chess.GetSize() )
                    {
                        Console.WriteLine("Invalid indices. Please enter valid row and column indices:");
                    }
                    else
                    {
                        break; 
                    }
                }
                catch(System.FormatException)
                {
                    Console.WriteLine("You must enter integer values in the range! Try again, please.");
                }
                catch (Matrix.IndexOutOfRangeException)
                {
                    Console.WriteLine("You must enter integer values in the range! Try again, please.");
                }
            }

            Console.WriteLine($"The entry at position ({row},{col}) is {collection[index].getEntry(row-1, col-1)}");
        }


        public void Add()
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("A matrix has not been created yet!");
                return;
            }
            Console.Write("1st matrix: ");
            int index1 = GetInd();
            Console.Write("2nd matrix: ");
            int index2 = GetInd();

            try
            {
                Console.Write(Matrix.add(collection[index1], collection[index2]).ToString());
            }
            catch (Matrix.NoSizeMatchException)
            {
                Console.WriteLine("Dimension mismatch!");
            }
            
        }

        public void Mult()
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("A matrix has not been created yet!");
                return;
            }
            Console.Write("1st matrix: ");
            int index1 = GetInd();
            Console.Write("2nd matrix: ");
            int index2 = GetInd();

            try
            {
                Console.Write(Matrix.multiply(collection[index1], collection[index2]).ToString());
            }
            catch (Matrix.NoSizeMatchException)
            {
                Console.WriteLine("Dimension mismatch!");
            }
        }
        public void Print()
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("A matrix has not been created yet!");
                return;
            }
            int index = GetInd();
            Console.WriteLine(collection[index].ToString());
        }
    }
}
