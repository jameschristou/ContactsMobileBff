using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;
using System.Linq;

namespace ContactsMobileBff.Features.ContactsListing.ComponentBuilders
{
    public interface IContactsListComponentBuilder
    {
        ContactsListComponent Build(ContactsListingRequest request);
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

        public ContactsListComponent Build(ContactsListingRequest request)
        {
            var contacts = _contactsService.GetContacts(request.SortBy, request.SortOrder);

            return new ContactsListComponent
            {
                ContactsListItems = contacts.Select(c => _contactListItemComponentBuilder.Build(c, request.SortBy)).ToList()
            };
        }
    }
}
