namespace Homework3_v3.Applications
{
    public enum MenuCommand
    {
        CreateUser = 1,
        ShowStatistics = 2,
        Exit = 3
    }

    public class ApplicationView
    {
        private Dictionary<MenuCommand, string> _commands;

        public ApplicationView()
        {
            _commands = new Dictionary<MenuCommand, string>
            {
                [MenuCommand.CreateUser] = "Добавить пользователя",
                [MenuCommand.ShowStatistics] = "Показать количество пользователей",
                [MenuCommand.Exit] = "Выйти"
            };
        }

        public void ShowMenu()
        {
            foreach (KeyValuePair<MenuCommand, string> command in _commands)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{command.Value} - {(int)command.Key}");
                Console.ResetColor();
            }
        }

        public MenuCommand? GetMenuCommand()
        {
            int enteredCommand = int.Parse(Console.ReadLine());

            foreach (MenuCommand command in Enum.GetValues<MenuCommand>())
            {
                if (enteredCommand == (int)command)
                {
                    return command;
                }
            }

            return null;
        }

        public UserRole? GetUserRole()
        {
            const int roleOffset = -1;

            int enteredUserRole = int.Parse(Console.ReadLine()) + roleOffset;

            switch (enteredUserRole)
            {
                case (int)UserRole.Client:
                    return UserRole.Client;

                case (int)UserRole.Admin:
                    return UserRole.Admin;

                case (int)UserRole.Manager:
                    return UserRole.Manager;

                default:
                    return null;
            }
        }

        public void ShowUsersCount(string count)
        {
            Console.WriteLine(count);
        }
    }
}
