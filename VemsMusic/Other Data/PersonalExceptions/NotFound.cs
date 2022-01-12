using System;

namespace VemsMusic.Other_Data.PersonalExceptions
{
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
