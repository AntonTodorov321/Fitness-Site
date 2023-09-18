namespace FitnessSite.Common
{
    public static class EntityValidationsConstants
    {
        public static class TypeExercise
        {
            public const int NameMaxLength = 15;
        }

        public static class Exercise
        {
            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 500;

            public const int ImageUrlMaxLength = 2048;

            public const int NameMinLength = 5;
            public const int NameMaxLength = 70;

            public const string RepsRegularExpression = @"(^\d{1,2} - \d{1,2}$|^\d{1,2}$)";
            public const string SetsRegularExpression = @"(^\d{1,2} - \d{1,2}$|^\d{1,2}$)";

            public const string RepsErrorMessage =
                "Reps must be in format 1d or 2d or dd - dd";

            public const string SetsErrorMessage =
                "Sets must be in format 1d or 2d or dd - dd";
        }

        public static class Trainer
        {
            public const int FirstNameMaxLength = 747;

            public const int LastNameMaxLength = 747;

            public const int DescriptionMaxLength = 200;

            public const int PhoneMaxLength = 10;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Muscle
        {
            public const int NameMaxLength = 20;
        }

        public static class Message
        {
            public const int QuestionMaxLength = 200;

            public const int DescriptionMaxLength = 500;
        }

        public static class User
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 70;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 70;
        }
    }
}