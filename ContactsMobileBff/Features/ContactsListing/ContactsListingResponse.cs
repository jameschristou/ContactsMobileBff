using System;
using System.Collections.Generic;

namespace ContactsMobileBFF.Features.ContactsListing
{
    public class ContactsListingResponse
    {
        public string ScreenTitleText { get; set; }
        public SearchComponent SearchComponent { get; set; }
        public SortByComponent SortByComponent { get; set; }
        public SortOrderComponent SortOrderComponent { get; set; }

        public List<ContactListingComponent> Contacts { get; set; }
    }

    public class ContactListingComponent
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string PrimaryContactName { get; set; }
        public ContactAvatar Avatar { get; set; }
    }

    public class ContactAvatar
    {
        public string Text { get; set; }
        public string Colour { get; set; }
    }

    public class SearchComponent
    {
        public string PlaceholderText { get; set; }
    }

    public class SortByComponent
    {
        public string DisplayText { get; set; }
        public List<SortByOption> SortByOptions { get; set; }
        public AnalyticsEventData ActionEventData { get; set; }
    }

    public class SortByOption
    {
        public ContactsListingSortByType SortType { get; set; }
        public string DisplayText { get; set; }
        public bool IsCurrentlySelected { get; set; }
        public string SelectActionUrl { get; set; }
        public AnalyticsEventData SelectActionEventData { get; set; }
    }

    public class SortOrderComponent
    {
        public string DisplayText { get; set; }
        public string SelectActionUrl { get; set; }
        public AnalyticsEventData SelectActionEventData { get; set; }
    }
}
