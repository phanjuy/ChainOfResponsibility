using System.Globalization;

namespace UserProcessing.Interfaces
{
    public interface ISocialSecurityNumberValidator
    {
        bool Validate(string socialSecurityNumber, RegionInfo region);
    }
}