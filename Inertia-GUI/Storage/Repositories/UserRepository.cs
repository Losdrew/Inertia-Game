using GUI.Storage.Objects;

namespace GUI.Storage.Repositories;

internal class UserRepository
{
    private const string UserFileLocation = @"Resources\JsonFiles\Users.json";

    private readonly SerializationWorker? _serializationWorker = new();

    public List<User>? GetAllUsers()
    {
        return _serializationWorker?.Deserialize<List<User>>(UserFileLocation);
    }

    public void SaveUser(User user)
    {
        var userList = GetAllUsers() ?? new List<User>();

        userList.Add(user);

        UpdateUserList(userList);
    }

    private void UpdateUserList(List<User> newUserList)
    {
        _serializationWorker?.Serialize(newUserList, UserFileLocation);
    }
}