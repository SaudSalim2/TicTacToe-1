﻿using System;

namespace TicTacToe
{
    public class Program
    {
        static Board game = new Board();
        public static int turncounter;
        static void Main()
        {
            int x = 1;
            turncounter = 0;
            Intro();
            while (x == 1)
            {
                if (CatsGame())
                {
                    Console.WriteLine("Cats Game!");
                    ResetGame();
                }
                pickPlayer(turncounter);
                PrintTiles();
                getInput();
                if (game.isWinner())
                {
                    Console.WriteLine("Congrats {0} You've Won!", pickPlayer(--turncounter));
                    ResetGame();
                }
                else
                    continue;
                Console.Read();
            }
        }

        public static void Intro()
        {
            Console.WriteLine("Welcome to Tic Tac Toe");
            Console.WriteLine("O Goes First");
        }

        static void PrintTiles()
        {
            Console.WriteLine("{0}    {1}    {2}", game.Tiles[0, 0], game.Tiles[0, 1], game.Tiles[0, 2]);
            Console.WriteLine("===========");
            Console.WriteLine("{0}    {1}    {2}", game.Tiles[1, 0], game.Tiles[1, 1], game.Tiles[1, 2]);
            Console.WriteLine("===========");
            Console.WriteLine("{0}    {1}    {2}", game.Tiles[2, 0], game.Tiles[2, 1], game.Tiles[2, 2]);
        }

        public static string pickPlayer(int turncounter)
        {
            // White is represented by 1, Black by 0
            if (turncounter % 2 == 0)
            {
                return "O";
            }
            else
                return "X";
        }

        static void getInput()
        {
            Console.WriteLine("Please press the number you wish to select");
            string input = Console.ReadLine();
            if (input.Equals("q") || input.Equals("Q"))
                ExitGame();
            bool checkAnswer = game.ChangeTiles(input, pickPlayer(turncounter));
            if (checkAnswer)
            {
                turncounter++;
                return;
            }
            else
            {
                Console.WriteLine("Please Enter Another Number");
                return;
            }
        }

        static void ResetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    game.Tiles[i, j] = game.newTiles[i, j];
                }
            }
            Main();
        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }

        static bool CatsGame()
        {
            if (turncounter >= 9)
            {
                return true;
            }
            else
                return false;
        }
    }
}
