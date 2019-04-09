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
        /// <returns>ObservableList of Starships ordered by Name </returns>
        public async Task<ObservableCollection<Starship>> GetAllStarShips()
        {

            var starships = new List<Starship>();
            var requestURL =  "https://swapi.co/api/starships";
            try
            {
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
            }
            catch
            {
                //Generic catch all for a potential issue with getting content. We do not want to crash the app
                //Future implementation should result in user dialog alerting to issue as well error logging (HockeyApp for reporting) 
                return new ObservableCollection<Starship>();
            }
            return new ObservableCollection<Starship>(starships.OrderBy(x => x.Name).ToList());
        }
    }
}
