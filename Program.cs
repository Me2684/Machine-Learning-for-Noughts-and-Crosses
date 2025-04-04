using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning_Experimentations
{
    internal class Program
    {
        static void Game()
        {
            string[,] grid = { { "-", "-", "-" },
                               { "-", "-", "-" },
                               { "-", "-", "-" } };
            string turn = "O";
            bool win = false;

            while (!win)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int column = 0; column < 2; column++)
                    {
                        Console.Write(grid[row, column]);
                    }
                    Console.WriteLine(grid[row, 2]);
                }
                Console.Write("Enter row (0-2): ");
                int rowInput = Int32.Parse(Console.ReadLine());
                Console.Write("Enter column (0-2): ");
                int columnInput = Int32.Parse(Console.ReadLine());
                grid[rowInput, columnInput] = turn;
                if (turn == "O")
                {
                    turn = "X";
                }
                else
                {
                    turn = "O";
                }
                if (grid[0, 0] == grid[1, 1] & grid[0, 0] == grid[2, 2] & grid[0, 0] != "-")
                {
                    win = true;
                }
                else if (grid[0, 2] == grid[1, 1] & grid[0, 2] == grid[2, 1] & grid[0, 2] != "-")
                {
                    win = true;
                }
                else if ((grid[0, 0] == grid[0, 1] & grid[0, 0] == grid[0, 2] & grid[0, 0] != "-") |
                         (grid[1, 0] == grid[1, 1] & grid[1, 0] == grid[1, 2] & grid[1, 0] != "-") |
                         (grid[2, 0] == grid[2, 1] & grid[2, 0] == grid[2, 2] & grid[2, 0] != "-"))
                {
                    win = true;
                }
                else if ((grid[0, 0] == grid[1, 0] & grid[0, 0] == grid[2, 0] & grid[0, 0] != "-") |
                         (grid[0, 1] == grid[1, 1] & grid[0, 1] == grid[2, 1] & grid[0, 1] != "-") |
                         (grid[0, 2] == grid[1, 2] & grid[0, 2] == grid[2, 2] & grid[0, 2] != "-"))
                {
                    win = true;
                }
                if (win == true)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 0; column < 2; column++)
                        {
                            Console.Write(grid[row, column]);
                        }
                        Console.WriteLine(grid[row, 2]);
                    }
                    Console.Write("Again (Y/N)? ");
                    string again = Console.ReadLine();
                    if (again == "Y")
                    {
                        win = false;
                        for (int row = 0; row < 3; row++)
                        {
                            for (int column = 0; column < 3; column++)
                            {
                                grid[row, column] = "-";
                            }
                        }
                        turn = "O";
                        win = false;
                    }
                }
            }
        }

        static (bool, string) WinCheck(string[,] grid)
        {
            bool win = false;
            string who = "O"; //Who checks
            if (grid[0, 0] == grid[1, 1] & grid[0, 0] == grid[2, 2] & grid[0, 0] != "-")
            {
                win = true;
                if (grid[0, 0] == "X")
                {
                    who = "X";
                }
            }
            else if (grid[0, 2] == grid[1, 1] & grid[0, 2] == grid[2, 1] & grid[0, 2] != "-")
            {
                win = true;
                if (grid[0, 2] == "X")
                {
                    who = "X";
                }
            }
            else if (grid[0, 0] == grid[0, 1] & grid[0, 0] == grid[0, 2] & grid[0, 0] != "-")
            {
                win = true;
                if (grid[0, 0] == "X")
                {
                    who = "X";
                }
            }
            else if (grid[1, 0] == grid[1, 1] & grid[1, 0] == grid[1, 2] & grid[1, 0] != "-")
            {
                win = true;
                if (grid[1, 0] == "X")
                {
                    who = "X";
                }
            }
            else if (grid[2, 0] == grid[2, 1] & grid[2, 0] == grid[2, 2] & grid[2, 0] != "-")
            {
                win = true;
                if (grid[2, 0] == "X")
                {
                    who = "X";
                }
            }
            else if (grid[0, 0] == grid[1, 0] & grid[0, 0] == grid[2, 0] & grid[0, 0] != "-")
            {
                win = true;
                if (grid[0, 0] == "X")
                {
                    who = "X";
                }
            }
            else if (grid[0, 1] == grid[1, 1] & grid[0, 1] == grid[2, 1] & grid[0, 1] != "-")
            {
                win = true;
                if (grid[0, 1] == "X")
                {
                    who = "X";
                }
            }
            else if (grid[0, 2] == grid[1, 2] & grid[0, 2] == grid[2, 2] & grid[0, 2] != "-")
            {
                win = true;
                if (grid[0, 2] == "X")
                {
                    who = "X";
                }
            }
            if (win == false)
            {
                who = "-";
            }
            return (win, who);
        }

        static NodeClass Generate(NodeClass root, string turn, string[,] grid)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (grid[row, column] == "-")
                    {
                        grid[row, column] = turn;
                        NodeClass node; //Default
                        if (turn == "O")
                        {
                            turn = "X";
                        }
                        else
                        {
                            turn = "O";
                        }
                        node = new NodeClass(grid, turn);
                        (bool, string) tuple = WinCheck(grid);
                        bool win = tuple.Item1;
                        string who = tuple.Item2;
                        if (who == "O")
                        {
                            node.SetValue(-1);
                        }
                        else if (who == "X")
                        {
                            node.SetValue(1);
                        }
                        else
                        {
                            node.SetValue(0);
                        }
                        if (!win)
                        {
                            node = Generate(node, turn, grid); //Only generate new if no win. If win: value = 1. If draw: value = 0. If lose: value = -1
                        }
                        grid[row, column] = "-";
                        root.AddChild(node);
                    }
                }
            }
            return root;
        }

        static void PreOrderTraversal(NodeClass root)
        {
            Console.WriteLine(root.GetValue());
            if (root.GetChildren() != null)
            {
                List<NodeClass> children = root.GetChildren();
                foreach (NodeClass child in children)
                {
                    PreOrderTraversal(child);
                }
            }
        }

        static void Main(string[] args)
        {
            string[,] gridInMain = { { "-", "-", "-" },
                                     { "-", "-", "-" },
                                     { "-", "-", "-" } };
            NodeClass rootInMain = new NodeClass(gridInMain, "X"); //Attributes do not matter
            rootInMain = Generate(rootInMain, "O", gridInMain);
            rootInMain.SetValue(0);  //Attributes do not matter
            TreeClass treeInMain = new TreeClass(rootInMain);
            PreOrderTraversal(rootInMain);

            Console.ReadKey();
        }
    }
}
