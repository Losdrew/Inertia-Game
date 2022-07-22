using GUI.Storage.Objects;
using GUI.Storage.Repositories;

namespace GUI.Storage.Services;

internal static class UserService
{
    private static readonly UserRepository UserRepository = new();

    public static List<User>? GetAllUsers()
    {
        return UserRepository.GetAllUsers();
    }

    public static void SaveUser(User user)
    {
        user.SavedDateTime = DateTime.Now;
        UserRepository.SaveUser(user);
    }
}