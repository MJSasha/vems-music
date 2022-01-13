using System;

namespace VemsMusic.Other_Data.PersonalExceptions
{
    /// <summary>
    /// Fires when the element is not found in the database.
    /// </summary>
    public class NotFound : Exception
    {
        /// <summary>
        /// Fires when the element is not found in the database.
        /// </summary>
        public NotFound()
        {

        }
        /// <summary>
        /// Fires when the element is not found in the database.
        /// </summary>
        /// <param name="message">Specification for the item you are looking for.</param>
        public NotFound(string message) : base(message)
        {

        }
    }
}
