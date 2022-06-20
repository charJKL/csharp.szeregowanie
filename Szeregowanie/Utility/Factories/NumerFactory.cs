namespace Szeregowanie.Utility.Factories
{
    class NumerFactory
    {
        private static int COUNTER = 0;

        public static int GetNumber()
        {
            NumerFactory.COUNTER++;
            return COUNTER;
        }

        public static void Reset()
        {
            NumerFactory.COUNTER = 0;
        }
    }
}