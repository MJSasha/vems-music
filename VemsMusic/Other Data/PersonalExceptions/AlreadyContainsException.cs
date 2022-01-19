using System;

namespace VemsMusic.Other_Data.PersonalExceptions
{
    /// <summary>
    /// Fires when an attempt is made to add an element to an object 
    /// in the database that is already bound to it.
    /// </summary>
    public class AlreadyContainsException : Exception
    {
        /// <summary>
        /// Fires when an attempt is made to add an element to an object 
        /// in the database that is already bound to it.
        /// </summary>
        public AlreadyContainsException()
        {

        }
        /// <summary>
        /// Fires when an attempt is made to add an element to an object 
        /// in the database that is already bound to it.
        /// </summary>
    }
}
