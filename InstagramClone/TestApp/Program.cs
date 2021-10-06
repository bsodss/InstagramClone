using System;
using System.Linq;
using System.Threading.Tasks;
using InstagramClone.DAL;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {


            //var user = new User()
            //{
            //    UserProfile = new UserProfile()
            //    {
            //        UserName = "oleh",
            //        IsPrivate = false
            //    }
            //};

            //using (var db = new InstagramCloneDbContextFactory().CreateDbContext(new String[] { }))
            //{
            //    //var sub = new UserRelations()
            //    //{
            //    //    RequestedById = Guid.Parse("fc223e5d-957f-4ce6-246c-08d98347057a"),
            //    //    RequestedToId = Guid.Parse("f6259fe4-2092-45b2-fa9e-08d983470d38")
            //    //};
            //    //db.UserRelations.Add(sub);
            //    var user = db.Users.Include(i => i.Subscribers)
            //        .Include(i=>i.Subscriptions)
            //        .FirstOrDefault(f => f.Id == Guid.Parse("f6259fe4-2092-45b2-fa9e-08d983470d38"));

            //    Console.WriteLine(user.Subscribers.Count());

            //    db.SaveChanges();
            //    Console.WriteLine("Added");
            //}

            //Console.WriteLine("done");

            using (var db = new InstagramCloneDbContextFactory().CreateDbContext(new String[] { }))
            {
                IUnitOfWork uow = new UnitOfWork(db);

                var users = uow.GetGenericRepository<User>();
                foreach (var user in users.FindAll())
                {
                    Console.WriteLine($"{user.Id}");
                }

                await users.AddAsync(new User()
                {
                    UserProfile = new UserProfile()
                    {
                        IsPrivate = false,
                        UserName = "Vasya123"
                    }
                });
                await uow.SaveAsync();
                Console.WriteLine("After-------->");

                var users2 = uow.GetGenericRepository<User>();
                foreach (var user in users2.FindAll())
                {
                    Console.WriteLine($"{user.Id}");
                }

            }

        }

    }
}
