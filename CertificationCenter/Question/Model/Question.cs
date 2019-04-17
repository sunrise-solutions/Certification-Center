namespace Question.Model
{
    public class Question
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Answer1 { get; set; }

        public bool IsAnswer1True { get; set; }

        public string Answer2 { get; set; }

        public bool IsAnswer2True { get; set; }

        public string Answer3 { get; set; }

        public bool IsAnswer3True { get; set; }

        public string Answer4 { get; set; }

        public bool IsAnswer4True { get; set; }

        public string Answer5 { get; set; }

        public bool IsAnswer5True { get; set; }

        public int TopicId { get; set; }
    }
}
