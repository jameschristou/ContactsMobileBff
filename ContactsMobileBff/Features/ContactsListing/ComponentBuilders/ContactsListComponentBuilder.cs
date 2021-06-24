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
        private readonly IContactListItemComponentBuilder _contactListItemComponentBuilder;

        public ContactsListComponentBuilder(IContactsServiceClient contactsService, IContactListItemComponentBuilder contactListItemComponentBuilder)
        {
            _contactsService = contactsService;
            _contactListItemComponentBuilder = contactListItemComponentBuilder;
        }

        public List<ContactListItemComponent> Build(ContactsListingRequest request)
        {
            var contacts = _contactsService.GetContacts("", "");

            return contacts.Select(_contactListItemComponentBuilder.Build).ToList();
        }
    }
}
