using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LocalityBaseAPI;
using LocalityBaseAPI.Models;
using LocalityBaseAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Locality = LocalityBaseNetCore.Models.Locality;

namespace LocalityBaseTest
{
    public class LocalitiesApiTests
    {
        private readonly HttpClient _client;
        private readonly LocalitiesContext _db;

        public LocalitiesApiTests()
        {
            var dbBuilder = new DbContextOptionsBuilder<LocalitiesContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=localitiesdb;Trusted_Connection=True;MultipleActiveResultSets=true");
            _db = new LocalitiesContext(dbBuilder.Options);

            string curDir = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(curDir)
                .AddJsonFile("appsettings.json");

            var webBuilder = new WebHostBuilder()
                .UseContentRoot(curDir).UseConfiguration(builder.Build())
                .UseStartup<Startup>();

            var server = new TestServer(webBuilder);
            _client = server.CreateClient();
        }

        private async Task<int> GetMaxId()
        {
            var locs = await _db.GetLocalities();
            int maxId = -1;
            var localities = locs.ToList();
            if (!localities.Any()) return maxId;
            using var enumerator = localities.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current != null && enumerator.Current.id > maxId) maxId = enumerator.Current.id;
            }

            return maxId;
        }

        [Fact, TestPriority(1)]
        public async Task GetLocalitiesTest()
        {
            var response = await _client.GetAsync("/api/Localities/");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, TestPriority(2)]
        public async Task AddLocalityTest()
        {
            Locality inLoc = new Locality
            {
                Type = "Посёлок",
                Submission = "Кировская область",
                Name = "Мирный",
                PeopleCount = 1,
                Budget = 3,
                Headman = "Львов Сергей Фёдорович"
            };
            var serialised = JsonConvert.SerializeObject(inLoc);
            var content = new StringContent(serialised, Encoding.Default, "application/json-patch+json");

            var response = await _client.PostAsync("/api/Localities/Add", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, TestPriority(4)]
        public async Task GetLocalityByIdTest()
        {
            int maxId = await GetMaxId();

            var response = await _client.GetAsync($"api/Localities/{maxId}");
            var cotent = JsonConvert.DeserializeObject<Locality>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(cotent);
            Assert.Equal(maxId, cotent.id);
        }

        [Fact, TestPriority(3)]
        public async Task UpdateLocalityTest()
        {
            int maxId = await GetMaxId();
            Locality updLoc = new Locality
            {
                id = maxId,
                Type = "Посёлок",
                Submission = "Кировская область",
                Name = "Мирный",
                PeopleCount = (decimal)1.5,
                Budget = (decimal)3.2,
                Headman = "Львов Сергей Фёдорович"
            };
            var serialised = JsonConvert.SerializeObject(updLoc);
            var content = new StringContent(serialised, Encoding.Default, "application/json-patch+json");

            var response = await _client.PutAsync("/api/Localities/Update", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, TestPriority(5)]
        public async Task DeleteLocalityTest()
        {
            int id = await GetMaxId();

            var response = await _client.DeleteAsync($"api/Localities/Delete/{id}");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}