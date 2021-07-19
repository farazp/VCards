using VCards.Lookups;
using VCards.Models;
using VCards.Serializer;
using VCards.Types;

namespace VCards.Processors
{
    public static class ClassificationProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //The property "CLASS" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            string classification = ClassificationLookup.ToVCardString(vcard.Classification);
            return DefaultSerializer.GetVCardString("CLASS", classification, true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Classification = ClassificationLookup.Parse(token.Values[0]);
        }
    }
}