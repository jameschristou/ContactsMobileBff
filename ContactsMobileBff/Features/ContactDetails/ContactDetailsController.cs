using ContactsMobileBff.Features.ContactDetails;
using ContactsMobileBff.Features.ContactDetails.ComponentBuilders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactsMobileBFF.Features.ContactsListing
{
    [ApiController]
    [Route("contacts/{contactId}")]
    public class ContactDetailsController : ControllerBase
    {
        private readonly IContactDetailsServiceClient _contactDetailsServiceClient;
        private readonly IPrimaryPersonComponentBuilder _primaryPersonComponentBuilder;

        public ContactDetailsController(IContactDetailsServiceClient contactDetailsServiceClient, IPrimaryPersonComponentBuilder primaryPersonComponentBuilder)
        {
            _contactDetailsServiceClient = contactDetailsServiceClient;
            _primaryPersonComponentBuilder = primaryPersonComponentBuilder;
        }

        [HttpGet]
        public ContactDetailsResponse Get([FromRoute] Guid contactId)
        {
            // TODO: create a custom model binder for ContactsListingRequest to handle things like deprecated or invalid enums
            // sent by client, ensuring NumResults is within bounds
            var contactDetails = _contactDetailsServiceClient.GetContactDetails(contactId);

            return new ContactDetailsResponse
            {
                ScreenTitleText = "Contact Edit",
                SaveButtonText = "Save",
                PrimaryPersonComponent = _primaryPersonComponentBuilder.Build(contactDetails)
            };
        }
    }
}