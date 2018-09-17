﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearStar.Microservice.Auth.RavenConfiguration
{
    public static class DocumentId
    {
        /// <summary>
        /// Strips the prefix from a document ID and returns the rest of the ID
        /// </summary>
        public static string NoPrefix(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var split = id.Split('/', StringSplitOptions.RemoveEmptyEntries);

            // e.g. Talks/
            if (split.Length < 2)
            {
                return null;
            }
            else
            {
                return String.Join("/", split.Skip(1));
            }
        }
    }
}
