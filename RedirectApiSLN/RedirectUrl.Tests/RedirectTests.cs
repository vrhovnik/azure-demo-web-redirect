using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RedirectApi.Models;

namespace RedirectUrl.Tests
{
    public class Tests
    {
        private HttpClient client;
        private const string localBaseURI = "https://localhost:5005/";
        
        [SetUp]
        public void Setup() => client = new HttpClient {BaseAddress = new Uri(localBaseURI, UriKind.Absolute)};

        [Test(Description = "Call to ASP.NET Core built-in functionality")]
        public async Task IsHealthyViaASPNETCore()
        {
            var response = await client.GetAsync("health");
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode,"Built in health call was successful");
        }
        
        [Test(Description = "Call to API defined health check")]
        public async Task IsHealthyViaApi()
        {
            var response = await client.GetAsync("demo/amialive");
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode,"API Health call was successful");
        } 
        
        [Test(Description = "Call to API with simple parameter call")]
        public async Task CheckCallWithSimpleParameter()
        {
            var response = await client.GetAsync("demo/withparam/john");
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode,"Http call was successful");
            var personList = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<Person>>(personList);
            Assert.IsInstanceOf<List<Person>>(list,"Person list has been returned");
            Assert.IsNotEmpty(list,"At least one result was returned");
        }
        
        [Test(Description = "Call to API with ASCII parameter call")]
        public async Task CheckCallWithAsciiParameter()
        {
            var response = await client.GetAsync("demo/withparam/%FA");
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode,"Http call was successful");
            var personList = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<Person>>(personList);
            Assert.IsInstanceOf<List<Person>>(list,"Person list has been returned");
            Assert.IsNotEmpty(list,"At least one result was returned");
        }
    }
}