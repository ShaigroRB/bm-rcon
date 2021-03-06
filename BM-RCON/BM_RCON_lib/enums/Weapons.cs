﻿namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for weapons (not all implemented yet)
    /// </summary>
    enum Weapon
    {
        fists = 0,
        // nothing = 1,
        pistol = 2,
        silenced_pistol = 3,
        underwater_pistol = 4,
        revolver = 5,
        burst_pistol = 6,
        compact_pistol = 7,
        handcannon = 8,
        uzi = 9,
        compact_uzi = 10,
        fire_uzi = 11,
        light_smg = 12,
        smg = 13,
        power_smg = 14,
        long_smg = 15,
        sawn_off = 16,
        pump = 17,
        db = 18,
        trench = 19,
        auto_shotgun = 20,
        light_ar = 21,
        assault_rifle = 22,
        keymaster = 23,
        heal_rifle = 24,
        underwater_rifle = 25,
        musket = 26,
        power_rifle = 27,
        scoped_rifle = 28,
        long_rifle = 29,
        lever = 30,
        plinger = 31,
        sniper_rifle = 32,
        bolt_action = 33,
        tranq_rifle = 34,
        lightning_gun = 35,
        machine_gun = 36,
        chain_gun = 37,
        grenade_launcher = 38,
        heavy_gl = 39,
        // nothing = 40,
        rocket_launcher = 41,
        light_rocket = 42,
        mortar = 43,
        plasma_rifle = 44,
        acid_gun = 45,
        goo_gun = 46,
        muleslapper = 47,
        fusion_cannon = 48,
        bow = 49,
        crossbow = 50,
        grapplehook = 51,
        knife = 52,
        sword = 53,
        wrench = 54,
        // nothing = 55,
        magic = 56,
        railgun = 57,
        // nothing = 58,
        // nothing = 59,
        // nothing = 60,
        drone = 61,
        frag = 62,
        potato_masher = 63,
        emp = 64,
        molotov = 65,
        nitrogen_mine = 66,
        healnade = 67,
        gasnade = 68,
        flashbang = 69,
        skate = 70,
        tomahawk = 71,
        suicide_vest = 72,
        muleslapper_sentry = 73,
        pineapple = 74,
        scuba = 75,
        dynamite = 76,
        kunai = 77,
        jetpack = 78,
        boomerang = 79
    }

    static class WeaponExtension
    {
        /// <summary>
        /// Extension method to get the string associated to a Weapon
        /// </summary>
        /// <param name="weapon">The weapon</param>
        /// <returns>The weapon as a readable string</returns>
        public static string GetString(this Weapon weapon)
        {
            string[] weapons = {
                "Fists", "", "Pistol",
                "Silenced Pistol", "Underwater Pistol", "Revolver",
                "Burst Pistol", "Compact Pistol", "Handcannon",
                "Uzi", "Compact Uzi", "Fire Uzi",
                "Light SMG", "SMG", "Power SMG",
                "Power SMG", "Long SMG", "Sawn-Off",
                "Pump Action", "Double Barrel", "Trench Gun",
                "Auto Shotgun", "Light AR", "Assault Rifle", "Keymaster",
                "Heal Rifle", "Underwater Rifle", "Musket",
                "Power Rifle", "Long Rifle", "Scoped Rifle",
                "Lever Action", "Plinger", "Sniper Rifle",
                "Bolt Action", "Tranq Rifle", "Lightning Gun",
                "Machine Gun", "Chain Gun", "Grenade Launcher",
                "Heavy GL", "", "Rocket Launcher",
                "Light Rockets", "Mortar", "Plasma Rifle",
                "Acid Gun", "Goo Gun", "Muleslapper",
                "Fusion Cannon", "Bow", "Crossbow",
                "Grapplehook", "Knife", "Sword",
                "Wrench", "", "Magic",
                "Railgun", "", "",
                "", "Drone", "Frag",
                "Potato Masher", "EMP", "Molotov",
                "Nitrogen Mine", "Heal Grenade", "Gas Grenade",
                "Flashbang", "Muleslapper Sentry", "Tomahawk",
                "Suicide Vest", "Skateboard", "Pineapple",
                "Scuba Gear", "Dynamite", "Kunai",
                "Jetpack", "Boomerang"
            };
            return weapons[(int)weapon];
        }

        /// <summary>
        /// Check if a number is equal to the weapon
        /// </summary>
        /// <param name="weapon">The weapon</param>
        /// <param name="nb">The number</param>
        /// <returns>true if equals, false otherwise</returns>
        public static bool IsEqual(this Weapon weapon, int nb)
        {
            return weapon == (Weapon)nb;
        }
    }
}