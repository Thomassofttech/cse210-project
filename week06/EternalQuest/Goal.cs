using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public abstract void RecordProgress();
        public abstract string GetProgressString();
        public abstract string GetStringRepresentation();

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;
        public bool IsComplete => _isComplete;
    }
}