using VCards.Models;
using VCards.Serializer;

namespace VCards.Processors
{
    public static class MailerProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(vcard.Mailer))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("MAILER", vcard.Mailer, true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Mailer = token.Values[0];
        }
    }
}