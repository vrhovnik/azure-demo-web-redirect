using System.Collections.Generic;
using System.Linq;
using RedirectApi.Models;

namespace RedirectApi.Helpers
{
    public static class StaticDataGenerator
    {
        private static readonly List<Person> list = new()
        {
            new() {FullName = "John Doe"},
            new() {FullName = "John Smith", Age = 33},
            new() {FullName = "Maria Smith", Age = 30}
        };
        
        public static List<Person> GetPersonList() => list;
        public static List<Person> SearchingTheList(string parameter)
        {
            if (string.IsNullOrEmpty(parameter)) return list;
            return list.Where(d => d.FullName.ToLower().Contains(parameter)).ToList();
        }
    }
}