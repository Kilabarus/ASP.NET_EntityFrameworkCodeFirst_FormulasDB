namespace EntityFrameworkCodeFirstFormulaOneDB.Models
{
    public static class Constants
    {
        public const int CURRENT_YEAR = 2020;

        public const int MAX_NUM_OF_DRIVERS_IN_CHAMPIONSHIP = 24;
        public const int MAX_NUM_OF_GRAND_PRIXES_IN_CHAMPIONSHIP = 22;

        public const int MAX_NUM_OF_POINTS_PER_PLACE = 25;
        public const int MAX_NUM_OF_POINTS_PER_FASTEST_LAP = 1;

        public const int MAX_NUM_OF_POINTS_PER_CHAMPIONSHIP = 
            (MAX_NUM_OF_POINTS_PER_PLACE + MAX_NUM_OF_POINTS_PER_FASTEST_LAP) * MAX_NUM_OF_GRAND_PRIXES_IN_CHAMPIONSHIP;
    }
}