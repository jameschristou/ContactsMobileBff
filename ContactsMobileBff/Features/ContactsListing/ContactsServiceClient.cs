using ContactsMobileBff.Infrastructure.AttributeBasedBindings;
using ContactsMobileBFF.Features.ContactsListing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsMobileBff.Features.ContactsListing
{
    public interface IContactsServiceClient
    {
        List<ContactDto> GetContacts(ContactsListingSortByType sortBy, ContactsListingSortOrderType sortOrder);
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

        public List<ContactDto> GetContacts(ContactsListingSortByType sortBy, ContactsListingSortOrderType sortOrder)
        {
            return sortOrder == ContactsListingSortOrderType.Asc ? contacts.OrderBy(c => GetSortByValue(sortBy, c)).ToList() : contacts.OrderByDescending(c => GetSortByValue(sortBy, c)).ToList();
        }

        private string GetSortByValue(ContactsListingSortByType sortBy, ContactDto c)
        {
            switch (sortBy)
            {
                case ContactsListingSortByType.Name: return c.Name;
                case ContactsListingSortByType.DateCreated: return c.DateCreated.ToString();
                case ContactsListingSortByType.Email: return c.Email;
                case ContactsListingSortByType.AccountNumber: return c.AccountNumber;
            }

            return c.Name;
        }
    }

    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrimaryContactName { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
