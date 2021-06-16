using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ContactsMobileBFF.Features.ContactsListing
{
    [ApiController]
    [Route("contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ContactsListingResponse Get()
        {
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
                            SortType = SortByType.Name,
                            IsCurrentlySelected = true,
                            SelectActionUrl = "/contacts/?sortBy=name",
                            SelectActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByName" }
                        },
                        new SortByOption
                        {
                            DisplayText = "Email",
                            SortType = SortByType.Email,
                            IsCurrentlySelected = false,
                            SelectActionUrl = "/contacts/?sortBy=email",
                            SelectActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByEmail" }
                        },
                        new SortByOption
                        {
                            DisplayText = "Account number",
                            SortType = SortByType.AccountNumber,
                            IsCurrentlySelected = false,
                            SelectActionUrl = "/contacts/?sortBy=accountNumber",
                            SelectActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByAccountNumber" }
                        },
                        new SortByOption
                        {
                            DisplayText = "DateCreated",
                            SortType = SortByType.DateCreated,
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
                Contacts = new List<ContactListingComponent>
                {
                    new ContactListingComponent
                    {
                        Id = Guid.NewGuid(),
                        Name = "Christou Chrisco Hampers",
                        PrimaryContactName = "Jimmy Chris",
                        Avatar = new ContactAvatar { Text = "CCH", Colour = "" } 
                    },
                    new ContactListingComponent
                    {
                        Id = Guid.NewGuid(),
                        Name = "Garipoli Garibaldis",
                        PrimaryContactName = "Adrian Gari",
                        Avatar = new ContactAvatar { Text = "GG", Colour = "" }
                    },
                    new ContactListingComponent
                    {
                        Id = Guid.NewGuid(),
                        Name = "Inta Intelligence Agency",
                        PrimaryContactName = "Phai Inta",
                        Avatar = new ContactAvatar { Text = "IIA", Colour = "" }
                    },
                    new ContactListingComponent
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kaur Kayaks",
                        PrimaryContactName = "Sup Kur",
                        Avatar = new ContactAvatar { Text = "KK", Colour = "" }
                    },
                    new ContactListingComponent
                    {
                        Id = Guid.NewGuid(),
                        Name = "Meyer Meditation",
                        PrimaryContactName = "Mike Meyers",
                        Avatar = new ContactAvatar { Text = "MM", Colour = "" }
                    },
                    new ContactListingComponent
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pham Pharmacy",
                        PrimaryContactName = "Thu Phantastic",
                        Avatar = new ContactAvatar { Text = "PP", Colour = "" }
                    },
                    new ContactListingComponent
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pram Practitioners",
                        PrimaryContactName = "Josie Pram",
                        Avatar = new ContactAvatar { Text = "PP", Colour = "" }
                    },
                    new ContactListingComponent
                    {
                        Id = Guid.NewGuid(),
                        Name = "Price-Bell Peanut Butter",
                        PrimaryContactName = "Georgie Tell",
                        Avatar = new ContactAvatar { Text = "PBPB", Colour = "" }
                    }
                }
            };
        }
    }
}
