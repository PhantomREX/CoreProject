using CoreProject.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject
{
    //public class ConInitializer
    //{
    //    public static void Seed(IApplicationBuilder applicationBuilder)
    //    {


    //        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
    //        {
    //            var context = serviceScope.ServiceProvider.GetService<Context>();

    //            context.Database.EnsureCreated();

    //            if (!context.Admins.Any())
    //            {
    //                context.Admins.AddRange(new List<Admin>()
    //                {
    //                new Admin()
    //                    {
    //                     AdminID=1,
    //                     UserName="yasin",
    //                     Password="1234",
    //                     AdminRole="a"
    //                    },
    //                    new Admin()
    //                    {

    //                     AdminID=2,
    //                     UserName="barıs",
    //                     Password="1234",
    //                     AdminRole="u"
    //                    }

    //                });
    //                context.SaveChanges();

    //            }


    //            if (!context.Categories.Any())
    //            {
    //                context.Categories.AddRange(new List<Category>()
    //                {
    //                new Category()
    //                    {
    //                    CategoryID=1,CategoryName="Kitchen1",CategoryDescription="Kitchen things description",IsApprovedStatu=false
    //                    },
    //                    new Category()
    //                    {
    //                       CategoryID=1, CategoryName="Seat1",CategoryDescription="Seat description",IsApprovedStatu=true
    //                    }

    //                });
    //                context.SaveChanges();

    //            }


    //            if (!context.Items.Any())
    //            {
    //                context.Items.AddRange(new List<AddItem>()
    //                {
    //                new AddItem()
    //                    {
                       
    //                   Name="Kitchen1e ait item 1",
    //                   Description="Kitchen1e ait item 1 açıklaması",
    //                   Price=31,
    //                   ImageURL=,
    //                   Stock=31,
    //                   CategoryID=1,


    //                     },
    //                    new AddItem()
    //                    {
                            
    //                        Name="Seat1  ait item1",
    //                   Description="Seat1 e ait item1 açıklaması",
    //                   Price=44,
    //                   ImageURL=,
    //                   Stock=1000,
    //                   CategoryID=2,


    //                         },

    //                     new AddItem()
    //                    {
                             
    //                        Name="Seat1 e ait item2",
    //                   Description="Seat1 e ait item2 açıklaması",
    //                   Price=222,
    //                   ImageURL=,
    //                   Stock=4554,
    //                   CategoryID=2,


    //                         }

    //                });
    //                context.SaveChanges();

    //            }





    //        }
    //    }

    //}
}
