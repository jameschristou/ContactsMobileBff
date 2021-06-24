using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using System;
using System.Collections.Generic;

namespace ContactsMobileBff.Features.ContactsListing
{
    public interface IContactsServiceClient
    {
        List<ContactDto> GetContacts(string sortBy, string sortOrder);
    }

    [Bind]
    public class ContactsServiceClient : IContactsServiceClient
    {
        private List<ContactDto> contacts = new List<ContactDto>
        {
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Christou Chrisco Hampers",
                PrimaryContactName = "Jimmy Chris"
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Garipoli Garibaldis",
                PrimaryContactName = "Adrian Gari"
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Inta Intelligence Agency",
                PrimaryContactName = "Phai Inta"
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Kaur Kayaks",
                PrimaryContactName = "Sup Kur"
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Meyer Meditation",
                PrimaryContactName = "Mike Meyers"
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Pham Pharmacy",
                PrimaryContactName = "Thu Phantastic"
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Pram Practitioners",
                PrimaryContactName = "Josie Pram"
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Price-Bell Peanut Butter",
                PrimaryContactName = "Georgie Tell"
            }
        };

        public List<ContactDto> GetContacts(string sortBy, string sortOrder)
        {
            return contacts;
        }
    }

    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrimaryContactName { get; set; }
    }
}
