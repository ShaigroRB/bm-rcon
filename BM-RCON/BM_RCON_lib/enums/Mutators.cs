namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for mutators
    /// </summary>
    enum Mutator
    {
        score_limit = 1,
        autobalance = 4,
        overtime = 5,
        medikits = 6,
        ammoboxes = 7,
        hazards = 8,
        powerups = 9,
        grace_period = 10,
        zombies = 13,
        barf_mania = 15,
        fall_damage = 16,
        auto_reloading = 17,
        amphibious_weapons = 18,
        friendly_fire = 19,
        max_health = 20,
        dual_wielding = 21,
        infinite_ammo = 22,
        infinite_nades = 23,
        double_jumping = 24,
        infinite_o2 = 25,
        weapon_behavior = 26,
        random_weapons = 27,
        tactical = 28,
        perma_invisibility = 29,
        perma_triple_damage = 30,
        perma_super_speed = 31,
        perma_regeneration = 32,
        perma_poison = 33,
        vampirism = 34,
        explosive_death = 35,
        headshots = 36,
        team_size = 37,
        random_deaths = 39,
        alcoholics_anonymous = 40,
        floor_is_lava = 41,
        infinite_money = 42,
        perma_jetpack = 44,
        perma_skateboard = 45,
        perma_scuba = 46,
        control_point = 47,
        spawn_points = 48,
        round_limit = 49,
        team_switch = 51,
        primary_duel_weapon = 52,
        secondary_duel_weapon = 53,
        duel_nade = 54,
        duel_dual_wield = 55,
        helicopter = 56,
        random_zombies = 57,
        vices = 59,
        survival_messages = 60,
        cycling = 68,
        equipment = 70,
        deathstreak = 71,
        force_primary = 74,
        force_secondary = 75,
        force_nade = 76,
        force_dual_wield = 77,
        change_weapons = 78,
        drop_weapons = 79,
        picks = 81,
        captains = 82,
        previous_picks = 83
    }

    static class MutatorExtension
    {
        /// <summary>
        /// Extension method to get the string associated to a Mutator
        /// </summary>
        /// <param name="mutator">The mutator</param>
        /// <returns>The team as a readable string</returns>
        public static string GetString(this Mutator mutator)
        {
            string[] mutators = {
                "", "Score Limit", "", "",
                "Autobalance", "Overtime", "Medikits",
                "Ammoboxes", "Hazards", "Powerups",
                "Grace Period", "", "", "Zombies", "",
                "Barf-Mania", "Fall Damage", "Auto-Reloading",
                "Amphibious Weapons", "Friendly Fire", "Max Health",
                "Dual-Wielding", "Infinite Ammo", "Infinite 'Nades",
                "Double Jumping", "Infinite O2", "Weapon Behavior",
                "Random Weapons", "Tactical", "Perma-Invisibility",
                "Perma-Triple Damage", "Perma-Super Speed", "Perma-Regen",
                "Perma-Poison", "Vampirism", "Explosive Death", "Headshots",
                "Team Size", "", "Random Deaths", "Alcoholics Anonymous",
                "Floor = Lava", "Infinite Money", "", "Perma-Jetpack",
                "Perma-Skateboard", "Perma-Scuba", "Control Point",
                "Spawn Points", "Round Limit", "", "Team Switch",
                "Primary Duel Weapon", "Secondary Duel Weapon", "Duel 'Nade",
                "Duel Dual-wield", "Helicopter", "Random Zombies", "",
                "Vices", "Survival Messages", "", "", "", "", "", "", "",
                "Cycling", "", "Equipment", "Deathstreak", "", "",
                "Force Primary", "Force Secondary", "Force 'Nade",
                "Force Dual-wield", "Change Weapons", "Drop Weapons", "",
                "Picks", "Captains", "Previous Picks"
            };
            return mutators[(int)mutator];
        }
    }
}