using UserProcessing.Models;

namespace UserProcessing.Interfaces
{
    public interface IUserProcessor
    {
        bool Register(User user);
    }
}
