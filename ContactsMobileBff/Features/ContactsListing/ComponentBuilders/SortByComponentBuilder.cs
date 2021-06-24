using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;
using System;
using System.Linq;

namespace ContactsMobileBff.Features.ContactsListing.ComponentBuilders
{
    public interface ISortByComponentBuilder
    {
        SortByComponent Build(ContactsListingRequest request);
    }

    [Bind]
    public class SortByComponentBuilder : ISortByComponentBuilder
    {
        public SortByComponent Build(ContactsListingRequest request)
        {
            // build up the list of sort options
            var sortOptions = ((ContactsListingSortByType[])Enum.GetValues(typeof(ContactsListingSortByType))).Select(t => new SortByOption
            {
                DisplayText = t.ToString(),
                SortType = t,
                IsCurrentlySelected = request.SortBy == t,
                SelectActionUrl = $"/contacts/?sortBy={t.ToString().ToLower()}",
                SelectActionEventData = new AnalyticsEventData { EventName = $"contactsListing.sortBy{t.ToString()}" }
            }).ToList();

            return new SortByComponent
            {
                DisplayText = $"Sorted by {request.SortBy}",
                SortByOptions = sortOptions,
                ActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByMenu" }
            };
        }
    }
}
