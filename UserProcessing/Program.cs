using System;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using UserProcessing.Interfaces;
using UserProcessing.Models;
using UserProcessing.Validators;

namespace UserProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Register services using in-built container
            var serviceProvider = ConfigureServices(new ServiceCollection())
                .BuildServiceProvider();

            // Resolve services
            var userProcessor = serviceProvider.GetRequiredService<IUserProcessor>();

            // Use services
            var user = new User("Duy Phan",
                "870101XXXX",
                new RegionInfo("SE"),
                new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));

            var result = userProcessor.Register(user);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services) =>
            services
                .AddTransient<IUserProcessor, Services.UserProcessor>()
                .AddTransient<ISocialSecurityNumberValidator, SocialSecurityNumberValidator>();

        //.AddTransient<IHandler<User>>(x =>
        //    new SocialSecurityNumberValidatorHandler(x.GetRequiredService<ISocialSecurityNumberValidator>()));
        //.AddTransient<IHandler<User>>(x => new AgeValidationHandler())
        //.AddTransient<IHandler<User>>(x => new NameValidationHandler())
        //.AddTransient<IHandler<User>>(x => new CitizenshipRegionValidationHandler());
    }
}
