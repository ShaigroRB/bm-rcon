namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for bots' difficulty
    /// The difference between AIMode and BotDifficulty enums is that there is a 'random' choice for BotDifficulty
    /// </summary>
    enum BotDifficulty
    {
        easy = 0,
        normal = 1,
        hard = 2,
        cruel = 3,
        random = 4
    }

    static class BotDifficultyExtension
    {
        /// <summary>
        /// Extension method to get the string associated to a BotDifficulty
        /// </summary>
        /// <param name="difficulty">The bot difficulty</param>
        /// <returns>The bot difficulty as a readable string</returns>
        public static string GetString(this BotDifficulty difficulty)
        {
            string[] difficulties = { "Easy", "Normal", "Hard", "Cruel", "Random" };
            return difficulties[(int)difficulty];
        }
    }
}