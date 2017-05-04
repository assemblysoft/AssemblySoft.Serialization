using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblySoft.Serialization
{
    /// <summary>
    /// File client exception
    /// </summary>
    class SerializationException : Exception
    {
        public SerializationException()
        {
        }

        public SerializationException(string message) : base(message)
        {
        }

        public SerializationException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}
