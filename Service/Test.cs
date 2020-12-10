using System;
using Plantsist.Data;

namespace Plantsist.Service
{
    public class Test : ITest
    {
        private readonly AppDbContext _appDbContext;

        public Test(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }


        public void Add()
        {
            _appDbContext.Users.Add(new User(){
                Name = "Po Jen Su",
                Age = 28
            });
            _appDbContext.SaveChanges();
        }
    }
}