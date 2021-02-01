namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for power ups (BFG is not implemented yet)
    /// </summary>
    enum PowerUp
    {
        triple_damage = 1,
        super_speed = 2,
        regeneration = 3,
        invisibility = 4,
        // not implemented yet
        //bfg = 5
    }

    static class PowerUpExtension
    {
        /// <summary>
        /// Extension method to get the string associated to a PowerUp
        /// </summary>
        /// <param name="power">The power up</param>
        /// <returns>The power up as a readable string</returns>
        public static string GetString(this PowerUp power)
        {
            string[] powers = {
                "",
                "Triple Damage", "Super Speed",
                "Regeneration", "Invisibility"
            };
            return powers[(int)power];
        }

        /// <summary>
        /// Check if a number is equal to the power
        /// </summary>
        /// <param name="power">The power</param>
        /// <param name="nb">The number</param>
        /// <returns>true if equals, false otherwise</returns>
        public static bool IsEqual(this PowerUp power, int nb)
        {
            return power == (PowerUp)nb;
        }
    }
}