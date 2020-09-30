namespace CarRentalSystem.Infrastructure
{
    using System;
    using System.Reflection;
    using AutoMapper;
    using Common.Events;
    using Common.Persistence;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        //[Fact]
        //public void AddRepositoriesShouldRegisterRepositories()
        //{
        //    // Arrange
        //    var serviceCollection = new ServiceCollection()
        //        .AddDbContext<CarRentalDbContext>(opts => opts
        //            .UseInMemoryDatabase(Guid.NewGuid().ToString()))
        //        .AddScoped<IDealershipDbContext>(provider => provider
        //            .GetService<CarRentalDbContext>())
        //        .AddTransient<IEventDispatcher, EventDispatcher>();

        //    // Act
        //    var services = serviceCollection
        //        .AddAutoMapper(Assembly.GetExecutingAssembly())
        //        .AddRepositories()
        //        .BuildServiceProvider();

        //    // Assert
        //    services
        //        .GetService<ICarAdQueryRepository>()
        //        .Should()
        //        .NotBeNull();
        //}
    }
}
