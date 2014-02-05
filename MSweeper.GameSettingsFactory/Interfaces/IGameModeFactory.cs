﻿namespace MSweeper.GameModeFactory.Interfaces
{
    public interface IGameModeFactory
    {
        IGameMode CreateInstance(string gameModeName);
    }
}
