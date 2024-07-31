using FriendOrganizer.DataAcess.Data;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.UI.Service
{
    public class FriendDataService : IFriendDataService
    {
        ApplicationMainDbContext? _context;

        public FriendDataService(ApplicationMainDbContext context)
        {
            _context = context;
        }
        public async Task<List<Friend>> GetAllAsync()
        {
            return await _context.Friends.AsNoTracking().ToListAsync<Friend>();
            
            /*O código abaixo testa o asincronismo do método, fazendo com que a tela (MainWindow)  seja carregada sem esperar pelas dados
             * var friends = await _context.Friends.AsNoTracking().ToListAsync<Friend>();
             * await Task.Delay(5000);
             * return friends;
             */
        }
    }
}
