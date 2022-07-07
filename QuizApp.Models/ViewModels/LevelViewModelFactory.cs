namespace QuizApp.Models.ViewModels
{
    public class LevelViewModelFactory
    {
        public static LevelViewModel Details(Level level)
        {
            return new LevelViewModel
            {
                Level = level,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,

            };
        }
        public static LevelViewModel Create(Level level)
        {
            return new LevelViewModel
            {
                Level = level,
            };
        }
        public static LevelViewModel Edit(Level level)
        {
            return new LevelViewModel
            {
                Level = level,
                Action = "Edit",
                Theme = "warning",

            };
        }
    }
}
