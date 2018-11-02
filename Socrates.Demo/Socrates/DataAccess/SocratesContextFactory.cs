using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socrates.DataAccess
{
    public static class SocratesContextFactory
    {
        public static ISocratesContext GetContext(string connStr, bool useProxies = true)
        {
            return new SocratesContext(connStr, useProxies);
        }
    }
}