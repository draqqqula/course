using Dal;
using Dal.Authors.Interfaces;
using Dal.Authors.Models;
using Dal.Tags.Interfaces;
using Dal.Tags.Models;
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
    public class TagTests
    {
        [Test]
        public async Task CheckCreateTag()
        {
            var services = new ServiceCollection();
            DalStartup.TryAddDal(services);
            var provider = new DefaultServiceProviderFactory().CreateServiceProvider(services);
            provider.CreateScope();
            var context = provider.GetService<QuestionDbContext>();
            var repository = provider.GetService<ITagRepository>();

            var text = "Foo";

            await repository.AddRangeAsync([new TagDal() { Text = text }]);

            var found = await repository.FindTagAsync(text);

            Assert.That(found is not null);
            Assert.That(found.Text == text);
        }
    }
}
