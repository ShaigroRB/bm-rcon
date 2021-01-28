namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for vices
    /// </summary>
    enum Vice
    {
        lager = 0,
        cider = 1,
        ale = 2,
        moonshine = 3,
        red_wine = 4,
        whiskey = 5,
        martini = 6,
        jagerbomb = 7,
        tequila = 8,
        joint = 9,
        stout = 10,
        margarita = 11,
        gin_tonic = 12,
        bloody_mary = 13,
        screwdriver = 14,
        sake = 15,
        mead = 16,
        white_wine = 17,
        cigar = 18,
        varian_cigar = 19,
        porter = 20,
        energy_drink = 21,
        painkillers = 22,
        mojito = 23,
        bourbon_cola = 24,
        beer = 25,
        spliff = 26,
        stimulants = 27,
        absinthe = 28,
        rum = 29,
        champagne = 30,
        vape_pen = 31,
        sherry = 32,
        espresso = 33,
        water = 34,
        rubbing_alcohol = 35,
        hot_wings = 36,
        antacids = 37,
        smokes = 38,
        vodka = 39,
        maria = 40,
        super_antacids = 41,
        indigos_reserve = 42
    }

    static class ViceExtension
    {
        /// <summary>
        /// Extension method to get the string associated to a Vice
        /// </summary>
        /// <param name="vice">The vice</param>
        /// <returns>The vice as a readable string</returns>
        public static string GetString(this Vice vice)
        {
            string[] vices = {
                "Lager", "Cider", "Ale",
                "Moonshine", "Red Wine", "Whiskey",
                "Martini", "Jägerbomb", "Tequila",
                "Joint", "Stout", "Margarita",
                "Gin & Tonic", "Bloody Mary", "Screwdriver",
                "Saké", "Mead", "White Wine",
                "Cigar", "Varian Cigar", "Porter",
                "Energy Drink", "Painkillers", "Mojito",
                "Bourbon & Cola", "Beer", "Spliff",
                "Stimulants", "Absinthe", "Rum",
                "Champagne", "Vape Pen", "Sherry",
                "Espresso", "Water", "Rubbing Alcohol",
                "Hot Wings", "Antacids", "Smokes",
                "Vodka", "Maria", "Super Antacids",
                "Indigo's Reserve"
            };
            return vices[(int)vice];
        }
    }
}