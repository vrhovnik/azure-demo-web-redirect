using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RedirectApi.Models;

namespace RedirectApi.Helpers
{
    public static class StaticDataGenerator
    {
        private static readonly List<Person> list = new()
        {
            new() {FullName = "John Doe"},
            new() {FullName = "John Smith", Age = 33},
            new() {FullName = "Jane Do / Happy", Age = 33},
            new() {FullName = "JJ/", Age = 62},
            new() {FullName = "Maria Smith", Age = 30}
        };

        public static List<Person> GetPersonList() => list;

        public static MemoryStream GetPersonListAsMemoryStream()
        {
            var list = GetPersonList();
            var personList = JsonConvert.SerializeObject(list);
            var personListBytes = Encoding.UTF8.GetBytes(personList);
            var memoryStream = new MemoryStream();
            memoryStream.Write(personListBytes, 0, personListBytes.Length);
            memoryStream.Position = 0;
            return memoryStream;
        }

        public static List<Person> SearchingTheList(string parameter) =>
            string.IsNullOrEmpty(parameter) ? list : list.Where(d => d.FullName.ToLower().Contains(parameter.ToLower())).ToList();

        public static List<Person> SearchingTheListWithEncoded(string parameter)
        {
            if (string.IsNullOrEmpty(parameter)) return list;

            if (parameter.Contains("%252F")) parameter = parameter.Replace("%252F", "/");
            var results = list.Where(d => d.FullName.ToLower().Contains(parameter.ToLower())).ToList();
            return results;
        }
    }
}