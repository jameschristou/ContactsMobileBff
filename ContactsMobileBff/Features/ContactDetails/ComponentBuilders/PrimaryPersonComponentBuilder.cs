using ContactsMobileBff.Infrastructure.AttributeBasedBindings;

namespace ContactsMobileBff.Features.ContactDetails.ComponentBuilders
{
    public interface IPrimaryPersonComponentBuilder
    {
        PrimaryPersonComponent Build(ContactDetailsDto contactDetails);
    }

    [Bind]
    public class PrimaryPersonComponentBuilder : IPrimaryPersonComponentBuilder
    {
        public PrimaryPersonComponent Build(ContactDetailsDto contactDetails)
        {
            return new PrimaryPersonComponent
            {
                HeadingText = "Primary Person",
                FirstName = new TextFieldComponent
                {
                    PlaceholderText = "First Name",
                    CurrentValue = "Jimmy",
                    MaxLength = 50
                },
                LastName = new TextFieldComponent
                {
                    PlaceholderText = "Last Name",
                    CurrentValue = "Jango",
                    MaxLength = 50
                },
                EmailAddress = new EmailAddressComponent
                {
                    PlaceholderText = "Email Address",
                    CurrentValue = "jimmy.jango@jango.com"
                }
            };
        }
    }
}
