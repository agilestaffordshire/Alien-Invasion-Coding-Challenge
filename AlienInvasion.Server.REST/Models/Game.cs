﻿namespace AlienInvasion.Server.REST.Models
{
    public class Game
    {
        private static int _gameIdCounter = 1;

        public string Id { get; set; }

        public Game()
        {
            Id = _gameIdCounter++.ToString();
        }
    }
}