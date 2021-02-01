﻿namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for event types (cf <see href="https://github.com/Spasman/rcon_example#rcon-events-and-their-json-data">Spasman's docs</see>)
    /// </summary>
    enum EventType : short
    {
        server_startup = 0,
        server_shutdown = 1,
        lobby_connect = 2,
        lobby_disconnect = 3,
        player_connect = 4,
        player_spawn = 5,
        player_death = 6,
        player_disconnect = 7,
        player_team_change = 8,
        player_level_up = 9,
        player_get_powerup = 10,
        player_damage = 11,
        player_loaded = 12,
        tdm_round_start = 13,
        tdm_round_end = 14,
        tdm_flag_unlocked = 15,
        tdm_switch_sides = 16,
        ctf_taken = 17,
        ctf_dropped = 18,
        ctf_returned = 19,
        ctf_scored = 20,
        ctf_generator_repaired = 21,
        ctf_generator_destroyed = 22,
        ctf_turret_repaired = 23,
        ctf_turret_destroyed = 24,
        ctf_resupply_repaired = 25,
        ctf_resupply_destroyed = 26,
        match_end = 27,
        match_overtime = 28,
        match_start = 29,
        survival_new_wave = 30,
        survival_wave_begins = 31,
        survival_buy_chest = 32,
        log_message = 33,
        request_data = 34,
        command_entered = 35,
        rcon_logged_in = 36,
        match_paused = 37,
        match_unpaused = 38,
        warmup_start = 39,
        rcon_disconnect = 40,
        rcon_ping = 41,
        chat_message = 42,
        survival_get_vice = 43,
        survival_use_vice = 44,
        survival_player_revive = 45,
        player_taunt = 46,
        survival_complete_mission = 47,
        survival_take_mission = 48,
        survival_fail_mission = 49,
        zombrains_revive = 50,
        zombrains_buy_weapon = 51,
        zombrains_begin = 52,
        zombrains_helicopter_arriving = 53,
        zombrains_helicopter_boarding = 54,
        zombrains_helicopter_player_boarded = 55,
        zombrains_end = 56,
        game_over = 57,
        server_empty = 58,
        weaponsdeal_rankchange = 59,
        takeover_flagcapture = 60,
        takeover_flagscreated = 61,
        player_loadout = 62,
        survival_bomb_defused = 63,
        survival_bomb_exploded = 64,
        survival_bomb_rearmed = 65
    }

    static class EventTypeExtension
    {
        /// <summary>
        /// Check if a number is equal to the event type
        /// </summary>
        /// <param name="eventType">The event type</param>
        /// <param name="nb">The number</param>
        /// <returns>true if equals, false otherwise</returns>
        public static bool IsEqual(this EventType eventType, int nb)
        {
            return eventType == (EventType)nb;
        }
    }
}