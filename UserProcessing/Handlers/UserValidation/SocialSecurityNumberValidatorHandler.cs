using UserProcessing.Exceptions;
using UserProcessing.Interfaces;
using UserProcessing.Models;
using UserProcessor.Handlers;

namespace UserProcessing.Handlers.UserValidation
{
    public class SocialSecurityNumberValidatorHandler : Handler<User>
    {
        private readonly ISocialSecurityNumberValidator _socialSecurityNumberValidator;

        public SocialSecurityNumberValidatorHandler(
            ISocialSecurityNumberValidator socialSecurityNumberValidator)
        {
            _socialSecurityNumberValidator = socialSecurityNumberValidator;
        }

        public override void Handle(User request)
        {
            if (!_socialSecurityNumberValidator.Validate(request.SocialSecurityNumber, request.CitizenshipRegion))
            {
                throw new UserValidationException("Social security number could not be validated");
            }
            base.Handle(request);
        }
    }
}
