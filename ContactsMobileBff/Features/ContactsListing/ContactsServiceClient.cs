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
        private readonly List<ContactDto> _contacts = new List<ContactDto>
        {
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Christou Chrisco Hampers",
                PrimaryContactName = "Jimmy Chris",
                Email = "jimmy.chris@gmail.com",
                AccountNumber = "3456365656",
                DateCreated = new DateTime(2019,09,01)
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Garipoli Garibaldis",
                PrimaryContactName = "Adrian Gari",
                DateCreated = new DateTime(2019,09,10)
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Inta Intelligence Agency",
                PrimaryContactName = "Phai Inta",
                DateCreated = new DateTime(2020,09,01)
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Kaur Kayaks",
                PrimaryContactName = "Sup Kur",
                DateCreated = new DateTime(2012,01,01)
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Meyer Meditation",
                PrimaryContactName = "Mike Meyers",
                DateCreated = new DateTime(2010,08,01)
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Pham Pharmacy",
                PrimaryContactName = "Thu Phantastic",
                DateCreated = new DateTime(2015,09,01)
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Pram Practitioners",
                PrimaryContactName = "Josie Pram",
                AccountNumber = "43554654646",
                DateCreated = new DateTime(2021,01,01)
            },
            new ContactDto
            {
                Id = Guid.NewGuid(),
                Name = "Price-Bell Peanut Butter",
                PrimaryContactName = "Georgie Tell",
                Email = "georgie.pb@test.com",
                DateCreated = new DateTime(2020,04,01)
            }
        };

        public List<ContactDto> GetContacts(ContactsListingSortByType sortBy, ContactsListingSortOrderType sortOrder)
        {
            if(sortBy == ContactsListingSortByType.DateCreated)
            {
                return sortOrder == ContactsListingSortOrderType.Asc ? _contacts.OrderBy(c => c.DateCreated).ToList() : _contacts.OrderByDescending(c => c.DateCreated).ToList();
            }

            var sortedList = _contacts.OrderBy(c => string.IsNullOrEmpty(GetSortByValue(sortBy, c)));

            return sortOrder == ContactsListingSortOrderType.Asc ?
                                sortedList.ThenBy(c => GetSortByValue(sortBy, c)).ToList() :
                                sortedList.ThenByDescending(c => GetSortByValue(sortBy, c)).ToList();
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
