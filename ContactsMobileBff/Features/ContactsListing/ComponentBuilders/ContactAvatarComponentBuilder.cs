using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsMobileBff.Features.ContactsListing.ComponentBuilders
{
    public interface IContactAvatarComponentBuilder
    {
        ContactAvatarComponent Build(ContactListingItemDto contact);
    }

    [Bind]
    public class ContactAvatarComponentBuilder : IContactAvatarComponentBuilder
    {
        private readonly List<AvatarColourPair> _avatarColourPairs = new List<AvatarColourPair>
        {
            new AvatarColourPair{ BackgroundColour = "EE99A3", TextColour = "4D1219" },
            new AvatarColourPair{ BackgroundColour = "FDC180", TextColour = "582E00" },
            new AvatarColourPair{ BackgroundColour = "FDD580", TextColour = "583C00" },
            new AvatarColourPair{ BackgroundColour = "80C19E", TextColour = "002E15" },
            new AvatarColourPair{ BackgroundColour = "A8EED5", TextColour = "1C4D3C" },
            new AvatarColourPair{ BackgroundColour = "89EAFA", TextColour = "154D58" },
            new AvatarColourPair{ BackgroundColour = "80BCE4", TextColour = "002A46" },
            new AvatarColourPair{ BackgroundColour = "ADADF3", TextColour = "202051" },
            new AvatarColourPair{ BackgroundColour = "DAA3E4", TextColour = "3F1946" },
            new AvatarColourPair{ BackgroundColour = "FFB2CB", TextColour = "592335" }
        };

        public ContactAvatarComponent Build(ContactListingItemDto contact)
        {
            var avatarColourPair = GetAvatarColourPair(contact.Name);

            return new ContactAvatarComponent { Text = GetInitials(contact.Name), BackgroundColour = avatarColourPair.BackgroundColour, TextColour = avatarColourPair.TextColour };
        }

        private string GetInitials(string contactName)
        {
            var ignoredCharacters = new char[] { '(', ')', '[', ']', '{', '}' };

            var initials = "";

            var includeNextNonWhitespaceChar = true;

            foreach(var c in contactName.ToCharArray())
            {
                if (char.IsWhiteSpace(c))
                {
                    includeNextNonWhitespaceChar = true;
                }
                else if (includeNextNonWhitespaceChar && !ignoredCharacters.Contains(c) && !char.IsHighSurrogate(c) && !char.IsLowSurrogate(c))
                {
                    initials += char.ToUpper(c);
                    if (!char.IsHighSurrogate(c))
                    {
                        includeNextNonWhitespaceChar = false;
                    }
                }
            }

            return initials.Substring(0, Math.Min(3, initials.Length));
        }

        private AvatarColourPair GetAvatarColourPair(string contactName)
        {
            var h = 5381;

            foreach (var c in contactName.ToLower().ToCharArray())
            {
                var num = Char.GetNumericValue(c);
                h = (h >> 5 + h) ^ c;
            }

            return _avatarColourPairs[h % _avatarColourPairs.Count];
        }

        private struct AvatarColourPair
        {
            public string BackgroundColour { get; set; }
            public string TextColour { get; set; }
        }
    }
}
