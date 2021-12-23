using UserProcessing.Interfaces;
using UserProcessing.Models;

namespace UserProcessing.Services
{
    public class UserProcessor : IUserProcessor
    {
        private readonly ISocialSecurityNumberValidator _socialSecurityNumberValidator;

        public UserProcessor(ISocialSecurityNumberValidator socialSecurityNumberValidator)
        {
            _socialSecurityNumberValidator = socialSecurityNumberValidator;
        }

        public bool Register(User user)
        {
            var isOk = _socialSecurityNumberValidator.Validate(user.SocialSecurityNumber, user.CitizenshipRegion);

            if (!isOk)
            {
                return false;
            }

            if (user.Age < 18)
            {
                return false;
            }

            if (user.Name.Length <= 1)
            {
                return false;
            }

            if (user.CitizenshipRegion.TwoLetterISORegionName == "NO")
            {
                return false;
            }

            return true;
        }
    }
}
