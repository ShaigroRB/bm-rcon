namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for missions
    /// </summary>
    enum Mission
    {
        /// <summary>Kill everything</summary>
        kill_everything = 0,
        /// <summary>Kill a certain amount of a specific enemy with any weapon</summary>
        kill_enemy = 1,
        /// <summary>Kill a certain amount of enemies with a specific weapon</summary>
        kill_with_weapon = 2,
        /// <summary>Find and deliver a specific weapon</summary>
        deliver_weapon = 3,
        /// <summary>Do a certain amount of damages</summary>
        damage = 4,
        /// <summary>Find the intel</summary>
        find_intel = 5,
        /// <summary>Savior mission</summary>
        savior = 6,
        /// <summary>Kill a specific boss</summary>
        kill_boss = 7,
        /// <summary>Kill a certain amount of a specific enemy with a specific weapon</summary>
        kill_enemy_with_weapon = 8,
        /// <summary>Defuse a bomb</summary>
        defuse_bomb = 9
    }

    static class MissionExtension
    {
        /// <summary>
        /// Extension method to get the string associated to a Mission
        /// </summary>
        /// <param name="mission">The mission</param>
        /// <returns>The mission as a readable string</returns>
        public static string GetString(this Mission mission)
        {
            string[] missions = {
                "Kill everything",
                "Kill a certain amount of a specific enemy with any weapon",
                "Kill a certain amount of enemies with a specific weapon",
                "Find and deliver a specific weapon",
                "Do a certain amount of damages",
                "Find the intel",
                "Savior mission",
                "Kill a specific boss",
                "Kill a certain amount of a specific enemy with a specific weapon",
                "Defuse a bomb"
            };
            return missions[(int)mission];
        }
    }
}