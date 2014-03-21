﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Swinesweeper.GameModeFactory.Interfaces;
using Swinesweeper.GridTools.Interfaces;
using Swinesweeper.Model;

namespace Swinesweeper.GridTools
{
    public class GridPainter
    {
        private readonly IGridBuilder _emptyGridBuilder;

        private readonly IGridControlBuilder _gridControlBuilder;

        private readonly IGridMiner _gridMiner;

        private readonly IPigCounter _pigCounter;


        public GridPainter(IGridBuilder emptyGridBuilder, IGridControlBuilder gridControlBuilder,
                           IGridMiner gridMiner, IPigCounter pigCounter)
        {
            _emptyGridBuilder = emptyGridBuilder;
            _gridControlBuilder = gridControlBuilder;
            _gridMiner = gridMiner;
            _pigCounter = pigCounter;
        }

        public void PaintGrid(IGameMode gameMode, Control control)
        {
            if (control == null) throw new ArgumentNullException("control");

            Tile[,] grid = _emptyGridBuilder.GetSquaredGrid(gameMode.GridSize, gameMode.DifficultyLevel);
            Tile[,] minedGrid = _gridMiner.MineTheGrid(grid, gameMode.DifficultyLevel, gameMode.GridSize);

            _gridControlBuilder.AddControlsToGrid(minedGrid, control, gameMode.GridSize);

            int formWidth = control.Width;
            var counter = (int) gameMode.GridSize;
            int x = 0;
            int y = 0;

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    minedGrid[i, j].BackColor = Color.Teal;
                    minedGrid[i, j].Width = 17;
                    minedGrid[i, j].Height = 17;
                    minedGrid[i, j].Location = new Point(x, y);

                    x += 18;

                    if (x > formWidth)
                    {
                        y += 18;
                        x = 0;
                    }
                    minedGrid[i, j] = grid[i, j];
                }
            }
            _pigCounter.CountPigs(grid);
        }
    }
}