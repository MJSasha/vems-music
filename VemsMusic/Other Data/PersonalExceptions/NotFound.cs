using System;

namespace VemsMusic.Other_Data.PersonalExceptions
{
    /// <summary>
    /// Fires when the element is not found in the database.
    /// </summary>
    public class NotFound : Exception
    {
        public NotFound()
        {

        }
        public NotFound(string message) : base(message)
        {

        }
    }
}
