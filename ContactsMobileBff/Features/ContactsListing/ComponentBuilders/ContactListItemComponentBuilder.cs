using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;

namespace ContactsMobileBff.Features.ContactsListing.ComponentBuilders
{
    public interface IContactListItemComponentBuilder
    {
        ContactListItemComponent Build(ContactListingItemDto contact, ContactsListingSortByType sortByType);
    }

    [Bind]
    public class ContactListItemComponentBuilder : IContactListItemComponentBuilder
    {
        private readonly IContactAvatarComponentBuilder _contactAvatarComponentBuilder;

        public ContactListItemComponentBuilder(IContactAvatarComponentBuilder contactAvatarComponentBuilder)
        {
            _contactAvatarComponentBuilder = contactAvatarComponentBuilder;
        }

        public ContactListItemComponent Build(ContactListingItemDto contact, ContactsListingSortByType sortByType)
        {
            return new ContactListItemComponent
            {
                Id = contact.Id,
                PrimaryDisplayText = contact.Name,
                SecondaryDisplayText = GetSecondaryDisplayText(contact, sortByType),
                Avatar = _contactAvatarComponentBuilder.Build(contact)
            };
        }

        private string GetSecondaryDisplayText(ContactListingItemDto contact, ContactsListingSortByType sortByType)
        {
            switch (sortByType)
            {
                case ContactsListingSortByType.Name: return contact.PrimaryContactName;
                case ContactsListingSortByType.Email: return contact.Email;
                case ContactsListingSortByType.DateCreated: return contact.DateCreated.ToString("dd MMMM yyyy");
                case ContactsListingSortByType.AccountNumber: return contact.AccountNumber;
            }

            return contact.PrimaryContactName;
        }
    }
}
