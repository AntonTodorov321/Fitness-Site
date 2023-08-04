namespace FitnessSite.Common
{
    public static class EntityValidationsConstants
    {
        public static class TypeExercise
        {
            public const int NameMinLenght = 7;
            public const int NameMaxLenght = 15;
        }

        public static class Exercise
        {
            public const int DescriptionMinLenght = 15;
            public const int DescriptionMaxLenght = 500;

            public const int ImageUrlMaxLenght = 2048;

            public const int NameMinLenght = 5;
            public const int NameMaxLenght = 70;
        }

        public static class Trainer
        {
            public const int FirstNameMinLengh = 1;
            public const int FirstNameMaxLengh = 747;

            public const int LastNameMinLengh = 1;
            public const int LastNameMaxLengh = 747;

            public const int DescriptionMinLenght = 30;
            public const int DescriptionMaxLengh = 200;

            public const int TelefoneMaxLenght = 10;

            public const int EmailMaxLenght = 300;

            public const int ImageUrlMaxLenght = 2048;
        }

        public static class Muscle
        {
            public const int NameMinLengh = 3;
            public const int NameMaxLenght = 20;
        }

        public static class Message
        {
            public const int FirstNameMinLengh = 1;
            public const int FirstNameMaxLengh = 747;

            public const int LastNameMinLengh = 1;
            public const int LastNameMaxLengh = 747;
        }

    }
}
