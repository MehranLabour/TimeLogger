using TimeLogger.AppService.Contract.User;

namespace TimeLogger.AppService.Contract
{
    public interface IJwtService
    {
        string Generate(UserView user);
    }
}