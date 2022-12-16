using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShpakEkzamKpzWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShpakEkzamKpzWebApi
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(new Client()
                    {
                        Name = "Oleksandr",
                        TypeOfWork = "cut",
                        MastersName = "Andriy"
                    },
                    new Client()
                    {
                        Name = "Roman",
                        TypeOfWork = "cut, paint",
                        MastersName = "Evgeniia"
                    },
                    new Client()
                    {
                        Name = "Vlad",
                        TypeOfWork = "cut",
                        MastersName = "Oksana"
                    });
                    
                }
                context.SaveChanges();
                context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Records.Any())
                {
                    context.Records.AddRange(new Record
                    {
                        Date = "25.12.2022 13:40",
                        Client = context.Clients.FirstOrDefault()
                    },
                    new Record
                    {
                        Date = "25.12.2022 11:20",
                        Client = context.Clients.FirstOrDefault()
                    },
                   new Record
                   {
                       Date = "26.12.2022 8:30",
                       Client = context.Clients.FirstOrDefault()
                   }) ;
                }
                context.SaveChanges();
            }
        }
    }

}

