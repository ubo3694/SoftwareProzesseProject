namespace Assignment1.Model
{
    public class Training
    {
        public Training() { }

        public Training(DateTime start, DateTime end, string trainer, long duration, string description)
        {
            Start = start;
            End = end;
            Trainer = trainer;
            Duration = duration;
            Description = description;
        }

        public long Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Trainer { get; set; }
        public long Duration { get; set; } // Dauer in Minuten
        public string Description { get; set; }
    }
}
