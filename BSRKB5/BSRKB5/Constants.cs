namespace BSRKB5;
public static class Constants
{
    public static class GameDefaults
    {
        public const int MAP_WIDTH = 9;
        public const int MAP_HEIGHT = 9;
        public const int BOMBS_COUNT = 20;
    }

    public static class GameFieldStates
    {
        public const string NOT_DISCOVERED = "#";
        public const string FLAGGED = "!";
        public const string QUESTIONED = "?";
    }

    public static class MenuCommands
    {
        public const string START_GAME_TEXT = "Play";
        public const string LEADERBOARD_TEXT = "See leaderboard";
        public const string EXIT_TEXT = "Exit";
    }
}
