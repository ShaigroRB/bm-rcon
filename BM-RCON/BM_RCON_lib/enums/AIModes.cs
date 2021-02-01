namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for AI modes
    /// </summary>
    enum AIMode
    {
        /// <summary>Default behavior</summary>
        normal = 0,
        /// <summary>Deactivate all AI</summary>
        deactivate_ai = 1,
        /// <summary>Deactivate all combat AI</summary>
        deactivate_combat = 2,
        /// <summary>Pathfinds to location when you middle-click</summary>
        pathfind_location = 3,
        /// <summary>Ignores human players in combat</summary>
        ignore_human = 4,
        /// <summary>Ignores other bots in combat</summary>
        ignore_bot = 5,
        /// <summary>Defend own spawn point from enemies</summary>
        defend_spawn_point = 6
    }
}