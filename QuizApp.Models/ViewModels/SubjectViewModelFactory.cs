namespace QuizApp.Models.ViewModels
{
    public class SubjectViewModelFactory
    {
        public static SubjectViewModel Details(Subject subject)
        {
            return new SubjectViewModel
            {
                Subject = subject,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,

            };
        }
        public static SubjectViewModel Create(Subject subject)
        {
            return new SubjectViewModel
            {
                Subject = subject,
            };
        }
        public static SubjectViewModel  Edit(Subject subject)
        {
            return new SubjectViewModel 
            {
                Subject = subject,
                Action = "Edit",
                Theme = "warning",

            };
        }
    }
}
