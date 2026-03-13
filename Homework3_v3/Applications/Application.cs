namespace Homework3_v3.Applications
{
    public class Application
    {
        private ApplicationView _applicationView;

        public Application()
        {
            _applicationView = new ApplicationView();
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                _applicationView.ShowMenu();

                MenuCommand? command = _applicationView.GetMenuCommand();

                switch (command.Value)
                {
                    case MenuCommand.CreateUser:
                        CreateUser();
                        break;

                    case MenuCommand.ShowStatistics:
                        string count = UserFactory.GetUsersCounts();
                        _applicationView.ShowUsersCount(count);
                        break;

                    case MenuCommand.Exit:
                        isRunning = false;
                        break;
                }
            }
        }

        private void CreateUser()
        {
            UserRole? userRole = _applicationView.GetUserRole();

            UserFactory.CreateUser(userRole.Value);
        }
    }
}
