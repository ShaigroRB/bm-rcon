namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for request types
    /// </summary>
    enum RequestType : short
    {
        login = 0,
        ping = 1,
        command = 2,
        request_player = 3,
        request_bounce = 4,
        request_match = 5,
        confirm = 6,
        request_scoreboard = 7
    }
}