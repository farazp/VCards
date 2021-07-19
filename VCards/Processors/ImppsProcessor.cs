﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VCards.Extensions;
using VCards.Models;
using VCards.Serializer;
using VCards.Types;

namespace VCards.Processors
{
    public static class ImppsProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (vcard.Impps == null || vcard.Impps.Count() == 0)
            {
                return string.Empty;
            }

            //Only vCard 4.0 supports IMPP property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }


            if (vcard.Impps == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (var impp in vcard.Impps)
            {
                if(impp.Address == null)
                {
                    continue;
                }

                string key = "IMPP";

                if (impp.Preference > 0)
                {
                    key = key + ";PREF=" + impp.Preference;
                }

                builder.Append(DefaultSerializer.GetVCardString(key, impp.Address.ToString(), false, vcard.Version));
            }

            return builder.ToString();
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(token.Values[0]))
            {
                return;
            }

            var impp = new Impp();
            var preference = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "PREF");

            impp.Preference = preference.Value.ConvertTo<int>();
            impp.Address = new Uri(token.Values[0], UriKind.RelativeOrAbsolute);

            var impps = (List<Impp>) vcard.Impps ?? new List<Impp>();
            impps.Add(impp);
            vcard.Impps = impps;
        }
    }
}