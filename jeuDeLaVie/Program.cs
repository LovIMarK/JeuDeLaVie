using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace jeuDeLaVie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const sbyte SIZE = 40;





            int[,] tabsGames = new int[SIZE, SIZE];
            int[,] tabsGames2 = new int[SIZE, SIZE];
            int compteurCell = 0;


            int posX = 0;
            CursorVisible = false;

            int generation = 0;

            int plac1 = 0;


            Random rdn = new Random();


            SetCursorPosition(4, 4);

             for (sbyte j = 0; j < SIZE; j++)
             {
                 for (sbyte i = 0; i < SIZE; i++)
                 {

                    tabsGames[j, i] = rdn.Next(0, 2);

                }
            }


            ReadLine();

            int numSameGen = 0;

            int sameGen = 0;
            do
            {
                
                
                generation++;
                
                SetCursorPosition(30, 0);
                WriteLine("Génération : " + generation);
                SetCursorPosition(0, 1);
                WriteLine("Nombre de cellules vivantes :       ");
                SetCursorPosition(0, 1);
                WriteLine("Nombre de cellules vivantes : " + compteurCell);
                compteurCell = 0;
            

                Thread.Sleep(50);
                for (int i = 0; i < tabsGames.GetLength(0); i++)
                {
                    for (int j = 0; j < tabsGames.GetLength(1); j++)
                    {
                        if(generation>1)
                        {
                            tabsGames[j, i] = tabsGames2[j, i];
                        }
                        
                        if (tabsGames[j, i] == 1)
                        {
                            SetCursorPosition(i * 2 + 6, j  + 5);
                            ForegroundColor = ConsoleColor.DarkBlue;
                            Write("■");
                            ResetColor();
                            compteurCell++;
                        }
                        else if (tabsGames[j, i] == 0)
                        {
                            SetCursorPosition(i *2 + 6, j  + 5);
                            ForegroundColor = ConsoleColor.White;
                            Write("■");
                            ResetColor();
                        }




                    }


                }
                
                for (int i = 0; i < tabsGames.GetLength(0); i++)
                {
                    for (int j = 0; j < tabsGames.GetLength(1); j++)
                    {
                        if (j != SIZE - 1 && tabsGames[j + 1, i] == 1)
                            plac1++;
                        if (j != 0 && tabsGames[j - 1, i] == 1)
                            plac1++;
                        if (i != SIZE - 1 && tabsGames[j, i + 1] == 1)
                            plac1++;
                        if (i != 0 && tabsGames[j, i - 1] == 1)
                            plac1++;
                        if (i != SIZE - 1 && j != SIZE - 1 && tabsGames[j + 1, i + 1] == 1)
                            plac1++;
                        if (j != SIZE - 1 && i != 0 && posX >= 0 && tabsGames[j + 1, i - 1] == 1)
                            plac1++;
                        if (i != 0 && j != 0 && posX >= 0 && tabsGames[j - 1, i - 1] == 1)
                            plac1++;
                        if (i != SIZE - 1 && j != 0 && posX >= 0 && tabsGames[j - 1, i + 1] == 1)
                            plac1++;

                        if (plac1 == 3)
                            tabsGames2[j, i] = 1;
                        else if (plac1 == 2 && tabsGames[j, i] == 1)
                            tabsGames2[j,i]=1;
                        else
                            tabsGames2[j, i] = 0;
                        plac1 = 0;
                    }

                }

                if(sameGen==compteurCell)
                {
                    numSameGen++;
                }else
                {
                    numSameGen = 0;
                }


                 sameGen = compteurCell;
                


            } while (true && numSameGen<6);

            ReadLine();
        }
    }
}
