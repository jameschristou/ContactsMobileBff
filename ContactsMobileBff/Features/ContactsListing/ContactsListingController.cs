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
        public ContactsListingResponse Get()
        {
            var contacts = _contactsService.GetContacts("", "");

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
                    SortByOptions = new List<SortByOption>
                    {
                        new SortByOption
                        {
                            DisplayText = "Name",
                            SortType = ContactsListingSortByType.Name,
                            IsCurrentlySelected = true,
                            SelectActionUrl = "/contacts/?sortBy=name",
                            SelectActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByName" }
                        },
                        new SortByOption
                        {
                            DisplayText = "Email",
                            SortType = ContactsListingSortByType.Email,
                            IsCurrentlySelected = false,
                            SelectActionUrl = "/contacts/?sortBy=email",
                            SelectActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByEmail" }
                        },
                        new SortByOption
                        {
                            DisplayText = "Account number",
                            SortType = ContactsListingSortByType.AccountNumber,
                            IsCurrentlySelected = false,
                            SelectActionUrl = "/contacts/?sortBy=accountNumber",
                            SelectActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByAccountNumber" }
                        },
                        new SortByOption
                        {
                            DisplayText = "DateCreated",
                            SortType = ContactsListingSortByType.DateCreated,
                            IsCurrentlySelected = false,
                            SelectActionUrl = "/contacts/?sortBy=dateCreated",
                            SelectActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByDateCreated" }
                        }
                    },
                    ActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortBy" }
                },
                SortOrderComponent = new SortOrderComponent
                {
                    DisplayText = "A-Z",
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
