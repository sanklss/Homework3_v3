using Homework3_v3.Users;

namespace Homework3_v3
{
    public enum UserRole
    {
        Client,
        Admin,
        Manager
    }

    public class UserFactory
    {
        private static Dictionary<UserRole, int> _usersCount;
        private static Dictionary<UserRole, Func<User>> _creator;

        static UserFactory()
        {
            _usersCount = new Dictionary<UserRole, int>();
            _creator = new Dictionary<UserRole, Func<User>>();

            _creator[UserRole.Client] = CreateClient;
            _creator[UserRole.Admin] = CreateAdmin;
            _creator[UserRole.Manager] = CreateManager;

            _usersCount[UserRole.Client] = 0;
            _usersCount[UserRole.Admin] = 0;
            _usersCount[UserRole.Manager] = 0;
        }
        public static User CreateUser(UserRole role)
        {
            _usersCount[role]++;

            return _creator[role]();
        }

        public static string GetUsersCounts()
        {
            return $"Клиенты - {_usersCount[UserRole.Client]}, Администраторы - {_usersCount[UserRole.Admin]}," +
                $" Менеджеры - {_usersCount[UserRole.Manager]}";
        }

        private static User CreateClient()
        {
            return new Client();
        }

        private static User CreateAdmin()
        {
            return new Admin();
        }

        private static User CreateManager()
        {
            return new Manager();
        }
    }
}
