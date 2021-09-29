using System;
using System.Linq;
using InstagramClone.DAL;
using InstagramClone.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {


            //var user = new User()
            //{
            //    UserProfile = new UserProfile()
            //    {
            //        UserName = "oleh",
            //        IsPrivate = false
            //    }
            //};

            using (var db = new InstagramCloneDbContextFactory().CreateDbContext(new String[] { }))
            {
                //var sub = new UserRelations()
                //{
                //    RequestedById = Guid.Parse("fc223e5d-957f-4ce6-246c-08d98347057a"),
                //    RequestedToId = Guid.Parse("f6259fe4-2092-45b2-fa9e-08d983470d38")
                //};
                //db.UserRelations.Add(sub);
                var user = db.Users.Include(i => i.Subscribers)
                    .Include(i=>i.Subscriptions)
                    .FirstOrDefault(f => f.Id == Guid.Parse("f6259fe4-2092-45b2-fa9e-08d983470d38"));

                Console.WriteLine(user.Subscribers.Count());

                db.SaveChanges();
                Console.WriteLine("Added");
            }

            Console.WriteLine("done");
        }
    }
}
