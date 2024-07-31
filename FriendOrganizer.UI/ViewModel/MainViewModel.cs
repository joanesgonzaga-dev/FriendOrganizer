using FriendOrganizer.Model;
using FriendOrganizer.UI.Service;
using System.Collections.ObjectModel;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Friend> Friends { get; set; }
        public IFriendDataService _friendDataService { get; set; }

        private Friend _selectedFriend;

        public MainViewModel(IFriendDataService friendDataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = friendDataService;
        }

        public async Task LoadFriendsCollectionAsync()
        {
            var friends = await _friendDataService.GetAllAsync();

            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }
        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged(nameof(SelectedFriend));
            }
        }
    }
}
