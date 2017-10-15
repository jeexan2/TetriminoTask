using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTetrimino
{
    class Program
    {
        abstract class Tetrimino
        {
            protected List<string> tetrisMatrix = new List<string>();
            public abstract void InitializationOfTetrimino();
            public void Print()
            {

                foreach (var str in tetrisMatrix)
                    Console.WriteLine(str);
            }
            public virtual void RotateMatrix()
            {
                int mxLength = 0;
                foreach(var str in tetrisMatrix)
                {
                    mxLength = Math.Max(mxLength, str.Length);
                }
                List<string> tempMatrix = new List<string>();
                
                foreach(var str in tetrisMatrix)
                {
                    string temp = str;
                    //tetrisMatrix = str;
                    if(str.Length < mxLength)
                    {
                        for (int i = str.Length; i < mxLength; i++)
                            temp += "x";
                    }
                    tempMatrix.Add(temp);
                }

                List<string> tempMatrixInvert = new List<string>();
                int row = tetrisMatrix.Count;
                int col = mxLength;
                for(int i = 0; i < col; i++)
                {
                    string str = "";
                    for (int j = 0; j < row; j++)
                        str += tempMatrix[i][j];
                    tempMatrixInvert.Add(str);
                }
                List<string> finalInvertMatrix = new List<string>();
                for(int i = 0; i < col; i++)
                {
                    string str = "";
                    for (int j = 0; j < row; j++)
                        if (tempMatrixInvert[i][j] != 'x')
                            str += tempMatrixInvert[i][j];
                    finalInvertMatrix.Add(str);
                }
                tetrisMatrix = finalInvertMatrix;
            }
        }
        class TLetterTetrimino : Tetrimino
        {
            public override void InitializationOfTetrimino()
            {
                //initializing T List<string>
                tetrisMatrix.Add("...");
                tetrisMatrix.Add(" . ");
            }
        }
        class OLetterTetrimino : Tetrimino
        {
            public override void InitializationOfTetrimino()
            {
                //initializing O List<string>
                tetrisMatrix.Add("..");
                tetrisMatrix.Add("..");
            }
        }

        static void Main(string[] args)
        {
            Tetrimino O = new OLetterTetrimino();
            Tetrimino T = new TLetterTetrimino();
        }
    }
}
