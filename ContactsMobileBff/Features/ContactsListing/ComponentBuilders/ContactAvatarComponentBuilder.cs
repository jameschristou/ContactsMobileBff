using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;
using System;
using System.Linq;

namespace ContactsMobileBff.Features.ContactsListing.ComponentBuilders
{
    public interface IContactAvatarComponentBuilder
    {
        ContactAvatarComponent Build(ContactDto contact);
    }

    [Bind]
    public class ContactAvatarComponentBuilder : IContactAvatarComponentBuilder
    {
        public ContactAvatarComponent Build(ContactDto contact)
        {
            return new ContactAvatarComponent { Text = GetInitials(contact.Name), BackgroundColour = "" };
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
    }



    public struct AvatarColourPair
    {
        public int BackgroundColour { get; set; }
        public int TextColour { get; set; }
    }
}
