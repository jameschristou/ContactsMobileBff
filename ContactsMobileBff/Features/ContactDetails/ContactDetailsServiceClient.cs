using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using System;
using System.Collections.Generic;

namespace ContactsMobileBff.Features.ContactDetails
{
    public interface IContactDetailsServiceClient
    {
        ContactDetailsDto GetContactDetails(Guid id);
    }

    [Bind]
    public class ContactDetailsServiceClient : IContactDetailsServiceClient
    {
        public ContactDetailsDto GetContactDetails(Guid id)
        {
            return new ContactDetailsDto
            {
                Id = id,
                FirstName = "Jimmy",
                LastName = "Jango",
                EmailAddress = "jimmy.jango@jango.com",
                People = new List<ContactDetailsDto.PersonDto>
                {
                    new ContactDetailsDto.PersonDto { FirstName = "Jimmy", LastName = "Jango", PersonType = PersonType.Primary }
                }
            };
        }
    }

    public class ContactDetailsDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public List<PersonDto> People { get; set; }

        public class PersonDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public PersonType PersonType { get; set; }
        }
    }

    public enum PersonType
    {
        Primary,
        Other
    }
}
