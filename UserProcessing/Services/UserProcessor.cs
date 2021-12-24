using UserProcessing.Exceptions;
using UserProcessing.Handlers.UserValidation;
using UserProcessing.Interfaces;
using UserProcessing.Models;

namespace UserProcessing.Services
{
    public class UserProcessor : IUserProcessor
    {
        private readonly ISocialSecurityNumberValidator _socialSecurityNumberValidator;

        public UserProcessor(
            ISocialSecurityNumberValidator socialSecurityNumberValidator)
        {
            _socialSecurityNumberValidator = socialSecurityNumberValidator;
        }

        public bool Register(User user)
        {
            try
            {
                var handler = new SocialSecurityNumberValidatorHandler(_socialSecurityNumberValidator);

                handler.SetNext(new AgeValidationHandler())
                .SetNext(new NameValidationHandler())
                .SetNext(new CitizenshipRegionValidationHandler());

                handler.Handle(user);
            }
            catch (UserValidationException)
            {
                return false;
            }

            return true;
        }
    }
}
