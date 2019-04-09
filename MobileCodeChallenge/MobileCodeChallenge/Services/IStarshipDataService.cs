using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.Model;

namespace MobileCodeChallenge.Services
{
    public interface IStarshipDataService
    {
        Task<ObservableCollection<Starship>> GetAllStarShips();

     }
}
