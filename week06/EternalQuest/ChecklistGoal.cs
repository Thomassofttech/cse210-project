namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override void RecordProgress()
        {
            _currentCount++;
            if (_currentCount >= _targetCount)
            {
                _isComplete = true;
                _points += _bonusPoints; // Add bonus points when completed
            }
        }

        public override string GetProgressString()
        {
            return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description} (Completed {_currentCount}/{_targetCount})";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_name},{_description},{_points},{_bonusPoints},{_targetCount},{_currentCount}";
        }
    }
}