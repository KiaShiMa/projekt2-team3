﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperLogic
{
    public class MineSweeperGame
    {
        public MineSweeperGame(int sizeX, int sizeY, int nrOfMines, IServiceBus bus)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            NumberOfMines = nrOfMines;
            Positions = new PositionInfo[SizeY, SizeX];
            ResetBoard();
        }

        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int SizeX { get; }
        public int SizeY { get; }
        public int NumberOfMines { get; }
        public GameState State { get; private set; }
        public PositionInfo[,] Positions { get; set; }

        public PositionInfo GetCoordinate(int x, int y)
        {
            return Positions[y, x];
        }

        public void FlagCoordinate()
        {
        }

        public void ClickCoordinate()
        {
        }

        public void ResetBoard()
        {
            
            // Creates epmty positions
            for (int y = 0; y < Positions.GetLength(0); y++)
            {
                for (int x = 0; x < Positions.GetLength(1); x++)
                {
                    Positions[y, x] = new PositionInfo();
                    Positions[y, x].Y = y;
                    Positions[y, x].X = x;
                    Positions[y, x].HasMine = false;
                    Positions[y, x].IsFlagged = false;
                    Positions[y, x].IsOpen = false;
                    Positions[y, x].NrOfNeighbours = 0;
                }
            }
            
            // Add mines in random positions
            int currentMines = 0;
            ServiceBus sBus = new ServiceBus();

            while (currentMines < NumberOfMines)
            {
                int randX = sBus.Next(SizeX);
                int randY = sBus.Next(SizeY);
                if (Positions[randY, randX].HasMine == false)
                {
                    Positions[randY, randX].HasMine = true;
                    currentMines++;
                }
                
            }

            // Calculates neighbours
            for (int y = 0; y < Positions.GetLength(0); y++)
            {
                for (int x = 0; x < Positions.GetLength(1); x++)
                {
                    // Checks if position is in 0,0 corner
                    if (Positions[y, x].Y == 0 && Positions[y, x].X == 0)
                    {
                        if (Positions[0, 1].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                        if (Positions[1, 1].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                        if (Positions[1, 0].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                    }

                    // Checks if position is in 0,(SizeX - 1) corner
                    else if (Positions[y, x].Y == 0 && Positions[y, x].X == (SizeX - 1))
                    {
                        if (Positions[0, (x - 1)].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                        if (Positions[1, (x - 1)].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                        if (Positions[1, (x)].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                    }

                    // Checks if position is in (SizeY - 1),0 corner
                    else if (Positions[y, x].Y == (SizeY - 1) && Positions[y, x].X == 0)
                    {
                        if (Positions[y, 1].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                        if (Positions[(y - 1), 1].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                        if (Positions[(y - 1), 0].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                    }

                    // Checks if position is in (SizeY - 1),(SizeX - 1) corner
                    else if (Positions[y, x].Y == (SizeY - 1) && Positions[y, x].X == (SizeX - 1))
                    {
                        if (Positions[y, (x - 1)].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                        if (Positions[(y - 1), (x - 1) ].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                        if (Positions[(y - 1), x].HasMine)
                            Positions[y, x].NrOfNeighbours++;
                    }

                    // Checks if position is in row 0
                    else if (Positions[y, x].Y == 0)
                    {
                        if ()

                    }

                    // Checks if position is in row (SizeY - 1)
                    else if (Positions[y, x].Y == (SizeY - 1))
                    {
                    }

                    // Checks if position is in colum 0
                    else if (Positions[y, x].X == 0)
                    {
                    }

                    // Checks if position is in colum (SizeX - 1)
                    else if (Positions[y, x].X == (SizeX - 1))
                    {
                    }

                    // If position is not in a corner, outer row or colum
                    else
                    {
                    }
                }
            }
            Console.WriteLine(Positions[0, 0].NrOfNeighbours);
            Console.WriteLine(Positions[0, SizeX - 1].NrOfNeighbours);
            Console.WriteLine(Positions[SizeY - 1, 0].NrOfNeighbours);
            Console.WriteLine(Positions[SizeY - 1, SizeX - 1].NrOfNeighbours);

            Console.ReadKey();
        } 
        
        public void DrawBoard()
        {
        }

        #region MoveCursor Methods

        public void MoveCursorUp()
        {
        }

        public void MoveCursorDown()
        {
        }

        public void MoveCursorLeft()
        {
        }

        public void MoveCursorRight()
        {
        }

        #endregion

    }
}
