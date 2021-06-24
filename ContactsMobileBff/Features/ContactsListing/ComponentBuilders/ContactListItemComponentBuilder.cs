using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;

namespace ContactsMobileBff.Features.ContactsListing.ComponentBuilders
{
    public interface IContactListItemComponentBuilder
    {
        ContactListItemComponent Build(ContactDto contact);
    }

    [Bind]
    public class ContactListItemComponentBuilder : IContactListItemComponentBuilder
    {
        private readonly IContactAvatarComponentBuilder _contactAvatarComponentBuilder;

        public ContactListItemComponentBuilder(IContactAvatarComponentBuilder contactAvatarComponentBuilder)
        {
            _contactAvatarComponentBuilder = contactAvatarComponentBuilder;
        }

        public ContactListItemComponent Build(ContactDto contact)
        {
            return new ContactListItemComponent
            {
                Id = contact.Id,
                PrimaryDisplayText = contact.Name,
                SecondaryDisplayText = contact.PrimaryContactName,
                Avatar = _contactAvatarComponentBuilder.Build(contact)
            };
        }
    }
}
