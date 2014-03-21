﻿using Swinesweeper.GameModeFactory.EventArg;
using Swinesweeper.GameModeFactory.Interfaces;
using Swinesweeper.GamePlay;
using Swinesweeper.GridBuilder;
using Swinesweeper.Utilities;
using System.Drawing;
using System.Windows.Forms;

namespace Swinesweeper.Presentation
{
    public partial class GameBoard : Form
    {
        public IGameMode ChosenGameMode { get; private set; }

        public GameBoard()
        {
            InitializeComponent();            
        }

        public void SubscribeToGameModeConfirmedEvent(GameMode optionsForm)
        {
            optionsForm.GameModeConfirmed += OptionsFormGameModeConfirmed;
        }

        public void OptionsFormGameModeConfirmed(object sender, ChosenGameModeEventArgs e)
        {
            ChosenGameMode = e.GameMode;
            DrawGrid();
        }

        private void DrawGrid()
        {
            Height = ChosenGameMode.FormSize.Y;
            Width = ChosenGameMode.FormSize.X;

            MaximumSize = new Size(Width, Height);
            MinimumSize = new Size(Width, Height);

            var painter = new GridPainter(new EmptyGridBuilder(), new GridControlBuilder(),
                                          new GridMiner(new RandomNumberGenerator()), new PigCounter());

            _panelGrid.Width = ChosenGameMode.GridPanelSize.X;
            _panelGrid.Height = ChosenGameMode.GridPanelSize.Y;

            painter.PaintGrid(ChosenGameMode, _panelGrid);   
        }
    }
}