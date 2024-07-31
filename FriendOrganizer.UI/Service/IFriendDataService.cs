using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Service
{
    public interface IFriendDataService
    {
        Task<List<Friend>> GetAllAsync();
    }
}