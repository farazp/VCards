using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCards;
using VCards.Models;
using VCards.Types;

namespace VCardsSample
{
    public class SampleVCards
    {
        public static VCard GetSimple()
        {
            return new VCard
            {
                Version = VCardVersion.V4,
                FormattedName = "John Doe",
                FirstName = "John",
                LastName = "Doe",
            };
        }

        private static Photo GetPhoto()
        {
            return new Photo(true, "png", "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");
        }

        public static VCard GetComplex()
        {
            return new VCard
            {
                Version = VCardVersion.V4,
                FormattedName = "John Doe",
                FirstName = "John",
                LastName = "Doe",
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Newfoundland Standard Time"),
                DeliveryAddress = new DeliveryAddress
                {
                    Type = AddressType.Parcel,
                    Address = "New Orleans"
                },
                Photo = GetPhoto(),
                Logo = GetPhoto(),
                Addresses = new List<Address>
                    {
                        new Address
                        {
                            Type = AddressType.Home,
                            PoBox = "234",
                            ExtendedAddress = "Address Line 2",
                            Street = "Street",
                            Locality = "City",
                            Region = "State",
                            PostalCode = "234234",
                            Country = "United States",
                            Label = "Home Address",
                            Preference = 1,
                            TimeZone = TimeZoneInfo.Local
                        }
                    },
                Telephones = new List<Telephone>
                    {
                        new Telephone
                        {
                            Type = TelephoneType.Preferred,
                            Number = "(345) 501-2527"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Home,
                            Number = "(614) 220-8747"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Work,
                            Number = "(262) 857-3144"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Car,
                            Number = "+44 909 879 0893"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Fax,
                            Number = "+1-202-555-0177"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Cell,
                            Number = "202-555-0198"
                        }
                    },
                BirthDay = DateTime.Today.AddYears(-20),
                Emails = new List<Email>
                    {
                        new Email
                        {
                            Type = EmailType.Smtp,
                            EmailAddress = "john@example.com"
                        },
                        new Email
                        {
                            Type = EmailType.AppleLink,
                            EmailAddress = "example@applelink.com"
                        }
                    },
                LastRevision = DateTime.Parse("2021-02-14T20:40:50.1899247Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                Note = "This is a test",
                Url = new Uri("http://example.com"),
                Organization = "ABC, Inc.",
                NickName = "Jim, Jimmie",
                SortString = "Jim",
                Categories = new[] { "Friends", "School", "Bike" },
                Classification = ClassificationType.Private,
                OrganizationalUnit = "North American, Division;Marketing",
                Title = "V.P., Research, and Development",
                Mailer = "Frapid",
                Latitude = -17.87,
                Longitude = 37.24,
                Prefix = "Mr.",
                Suffix = "Esq.",
                UniqueIdentifier = "970e501e-30fb-4cd1-90c6-5ce55b79a1a6",
                Role = "Executive",
                Source = new Uri("http://directory.example.com/addressbooks/jdoe/Jean%20Dupont.vcf"),
                Kind = Kind.Individual,
                Anniversary = DateTime.Today.AddYears(-3),
                Gender = Gender.Male,
                Impps = new List<Impp>
                    {
                        new Impp
                        {
                            Preference = 1,
                            Address = new Uri("test@example.com", UriKind.RelativeOrAbsolute)
                        },
                        new Impp
                        {
                            Preference = 2,
                            Address = new Uri("xmpp:alice@example.com", UriKind.RelativeOrAbsolute)
                        }
                    },
                Languages = new List<Language>
                    {
                        new Language
                        {
                            Type = LanguageType.Home,
                            Preference = 1,
                            Name = "en"
                        },
                        new Language
                        {
                            Type = LanguageType.Work,
                            Preference = 1,
                            Name = "fr"
                        }
                    },
                Relations = new List<Relation>
                    {
                        new Relation
                        {
                            Type = RelationType.Colleague,
                            Preference = 1,
                            RelationUri = new Uri("https://facebook.com/1")
                        },
                        new Relation
                        {
                            Type = RelationType.Acquaintance,
                            Preference = 1,
                            RelationUri = new Uri("http://example.com/directory/jdoe.vcf")
                        }
                    },
                CalendarUserAddresses = new List<Uri>
                    {
                        new Uri("mailto:janedoe@example.com"),
                        new Uri("http://example.com/calendar/jdoe")
                    },
                CalendarAddresses = new List<Uri>
                    {
                        new Uri("http://cal.example.com/calA"),
                        new Uri("ftp://ftp.example.com/calA.ics", UriKind.Absolute)
                    },
                CustomExtensions = new List<CustomExtension>
                {
                    new CustomExtension
                    {
                        Key = "X-ASSISTANT",
                        Value = "William James"
                    },
                    new CustomExtension
                    {
                        Key = "X-ASSISTANT",
                        Values = new[]{"John Crichton", "aeryn sun" }
                    },
                    new CustomExtension
                    {
                        Key = "X-SKYPE",
                        Values = new[]{"092B3492", "092F3492" }
                    },
                    new CustomExtension
                    {
                        Key = "item1.TEL",
                        Values = new[]{"092B3492", "092F3492" }
                    }
                }
            };

        }

    }
}
