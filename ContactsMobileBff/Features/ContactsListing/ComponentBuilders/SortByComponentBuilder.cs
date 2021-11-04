using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBff.LocalisationResources;
using ContactsMobileBFF.Features.ContactsListing;
using Microsoft.Extensions.Localization;
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
        // TODO: Figure out a way to make this unit testable so that we always check that the resource file contains
        // each of the strings we expect
        private const string _resourceFileIndexSortBy = "ContactsListing.SortBy.";
        private const string _resourceFileIndexSortedBy = "ContactsListing.SortedBy.";

        private readonly IStringLocalizer<ContentResources> _localizer;

        public SortByComponentBuilder(IStringLocalizer<ContentResources> localizer)
        {
            _localizer = localizer;
        }

        public SortByComponent Build(ContactsListingRequest request)
        {
            // build up the list of sort options
            var sortOptions = ((ContactsListingSortByType[])Enum.GetValues(typeof(ContactsListingSortByType))).Select(t => new SortByOption
            {
                DisplayText = _localizer[$"{_resourceFileIndexSortBy}{t}"],
                SortType = t,
                IsCurrentlySelected = request.SortBy == t,
                SelectActionUrl = $"/contacts/?sortBy={t.ToString().ToLower()}",
                SelectActionEventData = new AnalyticsEventData { EventName = $"contactsListing.sortBy{t.ToString()}" }
            }).ToList();

            return new SortByComponent
            {
                DisplayText = _localizer[$"{_resourceFileIndexSortedBy}{request.SortBy}"] ,
                SortByOptions = sortOptions,
                ActionEventData = new AnalyticsEventData { EventName = "contactsListing.sortByMenu" }
            };
        }
    }
}
