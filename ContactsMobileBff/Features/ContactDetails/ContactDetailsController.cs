using ContactsMobileBff.Features.ContactsListing;
using ContactsMobileBff.Features.ContactsListing.ComponentBuilders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactsMobileBFF.Features.ContactsListing
{
    [ApiController]
    [Route("contacts/{contactId}")]
    public class ContactDetailsController : ControllerBase
    {
        [HttpGet]
        public ContactDetailsResponse Get([FromRoute] Guid contactId)
        {
            // TODO: create a custom model binder for ContactsListingRequest to handle things like deprecated or invalid enums
            // sent by client, ensuring NumResults is within bounds

            return new ContactDetailsResponse
            {
                Id = contactId,
                Name = "Test",
                People = new List<Person>
                {
                    new Person { FirstName = "Jimmy", LastName = "Jango", PersonType = PersonType.Primary }
                }
            };
        }
    }

    public class ContactDetailsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonType PersonType { get; set; }
    }

    public enum PersonType
    {
        Primary,
        Other
    }
}