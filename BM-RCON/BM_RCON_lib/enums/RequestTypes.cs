namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Enum for request types (cf <see href="https://github.com/Spasman/rcon_example#sending-requests-and-processing-request_data">Spasman's docs</see>)
    /// </summary>
    enum RequestType : short
    {
        login = 0,
        ping = 1,
        /// <summary>
        /// Cf <see href="https://github.com/ShaigroRB/bm-boilerplate#additional-server-commands-you-can-send-these-packets-via-rcon-besides-the-request-data-ones">server commands</see> from Coyote's boilerplate
        /// </summary>
        command = 2,
        request_player = 3,
        request_bounce = 4,
        request_match = 5,
        confirm = 6,
        request_scoreboard = 7
    }

    static class RequestTypeExtension
    {
        /// <summary>
        /// Check if a number is equal to the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="nb">The number</param>
        /// <returns>true if equals, false otherwise</returns>
        public static bool IsEqual(this RequestType request, int nb)
        {
            return request == (RequestType)nb;
        }
    }
}