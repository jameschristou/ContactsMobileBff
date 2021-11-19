using System;
using System.Collections.Generic;

namespace ContactsMobileBff.Features.ContactDetails
{
    public class ContactDetailsResponse
    {
        public string ScreenTitleText { get; set; }
        public string SaveButtonText { get; set; }
        public PrimaryPersonComponent PrimaryPersonComponent { get; set; }
    }

    public class PrimaryPersonComponent
    {
        public string HeadingText { get; set; }
        public TextFieldComponent FirstName { get; set; }
        public TextFieldComponent LastName { get; set; }
        public EmailAddressComponent EmailAddress { get; set; }
    }

    public class TextFieldComponent
    {
        public string PlaceholderText { get; set; }
        public string CurrentValue { get; set; }
        public int? MaxLength { get; set; }
    }

    public class EmailAddressComponent
    {
        public string PlaceholderText { get; set; }
        public string CurrentValue { get; set; }
    }
}
