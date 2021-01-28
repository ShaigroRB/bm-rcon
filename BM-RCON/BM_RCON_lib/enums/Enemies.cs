﻿namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for enemies.
    /// </summary>
    enum Enemy
    {
        cannibal = 0,
        hopper = 1,
        blue_soldier = 2,
        purple = 3,
        sniper = 4,
        flesheater = 5,
        blue_lieutenant = 6,
        fuschia = 7,
        leaper = 8,
        bomb_dude = 9,
        demolition_guy = 10,
        ninja = 11,
        samurai = 12,
        /// <summary>Spawning Indigo will only spawn him. No purple will spawn with him.</summary>
        indigo = 13,
        blue_captain = 14,
        grandmaster = 15,
        explodebot_5000 = 16,
        anthropophagite = 17,
        /// <summary>Spawning Moxxy will also spawn Roxxy</summary>
        moxxy = 18,
        /// <summary>Spawning Roxxy will also spawn Moxxy</summary>
        roxxy = 19,
        disciple = 20,
        manling = 21,
        /// <summary>The operator enemy is written "operator_" as "operator" is already a reserved keyword.</summary>
        operator_ = 22,
        cowboy = 23,
        archer = 24,
        zombie = 25,
        zhost = 26,
        zpitter = 27,
        zomikaze = 28,
        doctor = 29
    }

    /// <summary>
    /// Enum for enemies rank 
    /// </summary>
    enum Rank
    {
        normal = 0,
        strong = 1,
        elite = 2,
        powerful = 3,
        god_like = 4
    }
}