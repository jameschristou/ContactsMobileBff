using ContactsMobileBff.Features.ContactsListing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsMobileBFF.Features.ContactsListing
{
    [ApiController]
    [Route("contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactsServiceClient _contactsService;

        public ContactsController(ILogger<ContactsController> logger, IContactsServiceClient contactsService)
        {
            _logger = logger;
            _contactsService = contactsService;
        }

        [HttpGet]
        public ContactsListingResponse Get([FromQuery]ContactsListingRequest request)
        {
            // set default values for the request if required (this could be moved to a custom model binder instead)
            if (!request.SortBy.HasValue)
            {
                request.SortBy = ContactsListingSortByType.Name;
            }

            if (!request.SortOrder.HasValue)
            {
                request.SortOrder = ContactsListingSortOrderType.Asc;
            }

            var contacts = _contactsService.GetContacts("", "");

            // build up the list of sort options
            var sortOptions = ((ContactsListingSortByType[])Enum.GetValues(typeof(ContactsListingSortByType))).Select(t => new SortByOption
                {
                    DisplayText = t.ToString(),
                    SortType = t,
                    IsCurrentlySelected = request.SortBy.Value == t,
                    SelectActionUrl = $"/contacts/?sortBy={t.ToString().ToLower()}",
                    SelectActionEventData = new AnalyticsEventData { EventName = $"contactsListing.sortBy{t.ToString()}" }
                }).ToList();

            return new ContactsListingResponse
            {
                ScreenTitleText = "Contacts",
                SearchComponent = new SearchComponent
                {
                    PlaceholderText = "Search"
                },
                SortByComponent = new SortByComponent
                {
                    DisplayText = "Sort",
                    SortByOptions = sortOptions,
                    ActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortBy" }
                },
                SortOrderComponent = new SortOrderComponent
                {
                    DisplayText = "A-Z", // get this from a lookup based on the sortby type
                    SelectActionUrl = "/contacts/?sortOrder=desc",
                    SelectActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortOrder" }
                },
                Contacts = contacts.Select(c => new ContactListingComponent {
                    Id = c.Id,
                    Name = c.Name,
                    PrimaryContactName = c.PrimaryContactName,
                    Avatar = new ContactAvatar { Text = "CCH", Colour = "" }
                }).ToList()
            };
        }
    }
}
