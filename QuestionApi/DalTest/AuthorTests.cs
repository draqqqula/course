using Dal;
using Dal.Authors.Interfaces;
using Dal.Authors.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalTest
{
    [TestFixture]
    public class AuthorTests
    {
        [Test]
        public async Task CheckCreateAuthor()
        {
            var services = new ServiceCollection();
            DalStartup.TryAddDal(services, "");
            var provider = new DefaultServiceProviderFactory().CreateServiceProvider(services);
            provider.CreateScope();
            var context = provider.GetService<QuestionDbContext>();
            var repository = provider.GetService<IAuthorRepository>();

            var name = "Jonny";

            var author = new AuthorDal
            {
                Name = name 
            };

            var id = await repository.CreateAsync(author);
            var entry = await repository.GetInfoAsync(id);
            Assert.That(entry.Name == name);
        }
    }
}
