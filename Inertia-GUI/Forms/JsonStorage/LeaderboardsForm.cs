using GUI.Forms.Base;
using GUI.Storage.Objects;
using System.Globalization;

namespace GUI.Forms.JsonStorage
{
    internal partial class LeaderboardsForm : FormBase
    {
        public LeaderboardsForm()
        {
            InitializeComponent();

            var userList = GameForm.UserRepository.GetAllUsers();

            if (userList is null)
            {
                return;
            }

            var bestUsersList = userList
                .OrderByDescending(user => user.PrizeCount)
                .ThenByDescending(user => user.CompletedLevelsCount)
                .ThenByDescending(user => user.GameOverCount)
                .ToList();

            FillListView(BestResultsListView, bestUsersList);

            var allUsersList = userList.OrderByDescending(x => x.SavedDateTime).ToList();

            FillListView(LatestResultsListView, allUsersList);
        }

        private void FillListView(ListView listView, List<User> userList)
        {
            foreach (var user in userList)
            {
                listView.Items.Add(new ListViewItem(new[]
                {
                    user.Name,
                    user.PrizeCount.ToString(),
                    user.CompletedLevelsCount.ToString(),
                    user.GameOverCount.ToString(),
                    user.SavedDateTime.ToString(CultureInfo.CurrentCulture)
                }));
            }
        }
    }
}
