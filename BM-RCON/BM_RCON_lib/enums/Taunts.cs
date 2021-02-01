namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for taunts
    /// </summary>
    enum Taunt
    {
        barf = 0,
        smoke = 1,
        drink = 2,
        warcry = 3,
        letsgo = 4
    }

    static class TauntExtension
    {
        /// <summary>
        /// Check if a number is equal to the taunt
        /// </summary>
        /// <param name="taunt">The taunt</param>
        /// <param name="nb">The number</param>
        /// <returns>true if equals, false otherwise</returns>
        public static bool IsEqual(this Taunt taunt, int nb)
        {
            return taunt == (Taunt)nb;
        }
    }
}