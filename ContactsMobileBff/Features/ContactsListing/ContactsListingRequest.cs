using ContactsMobileBFF.Features.ContactsListing;

namespace ContactsMobileBff.Features.ContactsListing
{
    public class ContactsListingRequest
    {
        public ContactsListingSortByType SortBy { get; set; }
        public ContactsListingSortOrderType SortOrder { get; set; }
        public int NumResults { get; set; }
        public int Offset { get; set; }
    }
}
