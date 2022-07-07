namespace QuizApp.Models.ViewModels
{
    public class SubjectViewModel
    {
        public Subject Subject { get; set; }
        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Level> Levels { get; set; }
        public IEnumerable<Question> Questions { get; set; }

    }
}
