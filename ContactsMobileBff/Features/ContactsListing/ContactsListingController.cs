using ContactsMobileBff.Features.ContactsListing;
using ContactsMobileBff.Features.ContactsListing.ComponentBuilders;
using Microsoft.AspNetCore.Mvc;

namespace ContactsMobileBFF.Features.ContactsListing
{
    [ApiController]
    [Route("contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ISortOrderComponentBuilder _sortOrderComponentBuilder;
        private readonly ISortByComponentBuilder _sortByComponentBuilder;
        private readonly IContactsListComponentBuilder _contactsListComponentBuilder;

        public ContactsController(ISortOrderComponentBuilder sortOrderComponentBuilder,
                                    ISortByComponentBuilder sortByComponentBuilder,
                                    IContactsListComponentBuilder contactsListComponentBuilder)
        {
            _sortOrderComponentBuilder = sortOrderComponentBuilder;
            _sortByComponentBuilder = sortByComponentBuilder;
            _contactsListComponentBuilder = contactsListComponentBuilder;
        }

        [HttpGet]
        public ContactsListingResponse Get([FromQuery]ContactsListingRequest request)
        {
            // TODO: create a custom model binder for ContactsListingRequest to handle things like deprecated or invalid senums
            // sent by client, ensuring NumResults is within bounds

            return new ContactsListingResponse
            {
                ScreenTitleText = "Contacts",
                SearchComponent = new SearchComponent
                {
                    PlaceholderText = "Search"
                },
                SortByComponent = _sortByComponentBuilder.Build(request),
                SortOrderComponent = _sortOrderComponentBuilder.Build(request),
                ContactsListComponent = _contactsListComponentBuilder.Build(request)
            };
        }
    }
}