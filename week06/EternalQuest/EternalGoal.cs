namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _timesCompleted;

        public EternalGoal(string name, string description, int points) 
            : base(name, description, points) 
        {
            _timesCompleted = 0;
        }

        public override void RecordProgress()
        {
            _timesCompleted++;
        }

        public override string GetProgressString()
        {
            return $"[ ] {_name} - {_description} (completed {_timesCompleted} times)";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_name},{_description},{_points},{_timesCompleted}";
        }
    }
}