using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;
using System.Collections.Generic;

namespace ContactsMobileBff.Features.ContactsListing.ComponentBuilders
{
    public interface ISortOrderComponentBuilder
    {
        SortOrderComponent Build(ContactsListingRequest request);
    }

    [BindAsSingleton]
    public class SortOrderComponentBuilder : ISortOrderComponentBuilder
    {
        private readonly Dictionary<ContactsListingSortByType, Dictionary<ContactsListingSortOrderType, string>> _sortOrderDisplayConfig = new Dictionary<ContactsListingSortByType, Dictionary<ContactsListingSortOrderType, string>>
        {
            {
                ContactsListingSortByType.Name, new Dictionary<ContactsListingSortOrderType, string>
                {
                    { ContactsListingSortOrderType.Asc, "A-Z"},
                    { ContactsListingSortOrderType.Desc, "Z-A"}
                }
            },
            {
                ContactsListingSortByType.Email, new Dictionary<ContactsListingSortOrderType, string>
                {
                    { ContactsListingSortOrderType.Asc, "A-Z"},
                    { ContactsListingSortOrderType.Desc, "Z-A"}
                }
            },
            {
                ContactsListingSortByType.DateCreated, new Dictionary<ContactsListingSortOrderType, string>
                {
                    { ContactsListingSortOrderType.Desc, "New-Old"},
                    { ContactsListingSortOrderType.Asc, "Old-New"}
                }
            },
            {
                ContactsListingSortByType.AccountNumber, new Dictionary<ContactsListingSortOrderType, string>
                {
                    { ContactsListingSortOrderType.Asc, "0-9"},
                    { ContactsListingSortOrderType.Desc, "9-0"}
                }
            }
        };

        public SortOrderComponent Build(ContactsListingRequest request)
        {
            var invertedSortOrder = request.SortOrder == ContactsListingSortOrderType.Asc ? ContactsListingSortOrderType.Desc : ContactsListingSortOrderType.Asc;

            return new SortOrderComponent
            {
                DisplayText = GetDisplayText(request),
                SelectActionUrl = $"/contacts/?sortBy={request.SortBy.ToString().ToLower()}&sortOrder={invertedSortOrder.ToString().ToLower()}",
                SelectActionEventData = new AnalyticsEventData { EventName = $"contactsListing.sortOrder{invertedSortOrder}" }
            };
        }

        private string GetDisplayText(ContactsListingRequest request)
        {
            if(_sortOrderDisplayConfig.TryGetValue(request.SortBy, out var sortOrderDisplayOptions))
            {
                if (sortOrderDisplayOptions.TryGetValue(request.SortOrder, out var displayText))
                {
                    return displayText;
                }
            }

            // default case front end displays nothing
            return null;
        }
    }
}
