using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;

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
            return new ContactAvatarComponent { Text = "CCH", Colour = "" };
        }
    }
}
