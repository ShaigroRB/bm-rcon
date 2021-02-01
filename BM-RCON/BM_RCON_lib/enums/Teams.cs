namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for teams
    /// </summary>
    enum Team
    {
        deathmatch = 0,
        usc = 1,
        the_man = 2,
        spectators = 3
    }

    static class TeamExtension
    {
        /// <summary>
        /// Extension method to get the string associated to a Team
        /// </summary>
        /// <param name="team">The team</param>
        /// <returns>The team as a readable string</returns>
        public static string GetString(this Team team)
        {
            string[] teams = { "Global", "USC", "The Man", "SPECTATORS" };
            return teams[(int)team];
        }
    }
}