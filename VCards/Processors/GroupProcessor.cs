﻿using System.Linq;
using VCards.Extensions;
using VCards.Serializer;
using VCards.Types;

namespace VCards.Processors
{
    public static class GroupProcessor
    {
        public static string Serialize(string key, VCardVersion version, string type, bool mustEscape = false, params string[] members)
        {
            if(members == null || members.Count() == 0)
            {
                return string.Empty;
            }

            string value = string.Join(";", members.Select(x => mustEscape ? x.Escape() : x));
            return DefaultSerializer.GetVCardString(key, value, false, version, type);
        }
    }
}