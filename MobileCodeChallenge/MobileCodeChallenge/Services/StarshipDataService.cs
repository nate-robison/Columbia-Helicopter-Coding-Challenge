using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.Model;
using Newtonsoft.Json;

namespace MobileCodeChallenge.Services
{
    public class StarshipDataService : IStarshipDataService
    {
        HttpClient httpClient;
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        /// <summary>
        /// Get a ObservableList of all Starships from SWAPI 
        /// </summary>
        /// <returns>ObservableList of Starships</returns>
        public async Task<ObservableCollection<Starship>> GetAllStarShips()
        {

            var starships = new List<Starship>();
            var requestURL =  "https://swapi.co/api/starships";
            var result = await Client.GetAsync(requestURL);
            if (result.IsSuccessStatusCode)
            {
                var value = await result.Content.ReadAsStringAsync();
                var starshipList = JsonConvert.DeserializeObject<StarshipList>(value);
                starships.AddRange(starshipList.Results);
                bool hasNext = false;
                if (!string.IsNullOrEmpty(starshipList.Next)) hasNext = true; 
                while (hasNext)
                {
                    result = await Client.GetAsync(starshipList.Next);
                    value = await result.Content.ReadAsStringAsync();
                    starshipList = JsonConvert.DeserializeObject<StarshipList>(value);
                    starships.AddRange(starshipList.Results);
                    if (string.IsNullOrEmpty(starshipList.Next)) hasNext = false;
                }
             
             }
            return new ObservableCollection<Starship>(starships.OrderBy(x => x.Name).ToList());
        }
    }
}
