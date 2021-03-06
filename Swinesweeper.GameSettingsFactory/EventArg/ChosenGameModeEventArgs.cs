﻿using Swinesweeper.GameModeFactory.Interfaces;
using System;

namespace Swinesweeper.GameModeFactory.EventArg
{
    public sealed class ChosenGameModeEventArgs : EventArgs
    {
        public IGameMode GameMode { get; private set; }

        public ChosenGameModeEventArgs(IGameMode gameMode)
        {
            GameMode = gameMode;            
        }
    }
}
