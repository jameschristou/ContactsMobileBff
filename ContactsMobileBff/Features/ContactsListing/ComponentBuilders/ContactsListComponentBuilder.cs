using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;
using System.Collections.Generic;
using System.Linq;

namespace ContactsMobileBff.Features.ContactsListing.ComponentBuilders
{
    public interface IContactsListComponentBuilder
    {
        List<ContactListItemComponent> Build(ContactsListingRequest request);
    }

    [Bind]
    public class ContactsListComponentBuilder : IContactsListComponentBuilder
    {
        private readonly IContactsServiceClient _contactsService;

        public ContactsListComponentBuilder(IContactsServiceClient contactsService)
        {
            _contactsService = contactsService;
        }

        public List<ContactListItemComponent> Build(ContactsListingRequest request)
        {
            var contacts = _contactsService.GetContacts("", "");

            return contacts.Select(c => new ContactListItemComponent
            {
                Id = c.Id,
                PrimaryDisplayText = c.Name,
                SecondaryDisplayText = c.PrimaryContactName,
                Avatar = new ContactAvatarComponent { Text = "CCH", Colour = "" }
            }).ToList();
        }
    }
}
