﻿using MineSweeper.Settings;
using System;
using System.Windows.Forms;

namespace MineSweeper.GridTools
{
    public static class GridManager
    {
        public static Control AddControlsToGrid<T>(T[,] controlsToAdd, Control control, GridSize gridSize) 
            where T: Control
        {
            if (!Enum.IsDefined(typeof(GridSize), gridSize))
                gridSize = GridSize.Beginner;

            int counter = (int) gridSize;

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    if(controlsToAdd[i, j] != null)
                        control.Controls.Add(controlsToAdd[i, j]);
                }
            }
            return control;
        }
    }
}
