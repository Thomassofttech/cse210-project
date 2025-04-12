namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override void RecordProgress()
        {
            _isComplete = true;
        }

        public override string GetProgressString()
        {
            return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description}";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
        }
    }
}