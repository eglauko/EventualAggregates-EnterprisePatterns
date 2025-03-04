using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using RoyalCode.Persistence.EntityFramework.UnitOfWork.Interceptors;
using RoyalCode.UnitOfWork.Abstractions;
using Xunit;

namespace RoyalCode.Persistence.Tests.UnitOfWork;

public class UnitOfWorkContextTests
{
    [Fact]
    public void InitializerInterceptor_From_DI()
    {
        ServiceCollection services = new();
        services.AddTransient<IInitializerInterceptorFromDIService, InitializerInterceptorFromDiService>();
        
        services.AddUnitOfWork<InitializerInterceptorFromDIDbContext>()
            .ConfigureDbContext(builder =>
            {
                builder.UseInMemoryDatabase(nameof(InitializerInterceptor_From_DI));
                builder.AddInterceptors(new InitializerInterceptorFromDIInitializerInterceptor());
            });

        var sp = services.BuildServiceProvider();

        var uow = sp.GetService<IUnitOfWork>();
        Assert.NotNull(uow);
        Assert.True(InitializerInterceptorFromDIInitializerInterceptor.Intercepted);
        Assert.True(InitializerInterceptorFromDIInitializerInterceptor.ServiceFounded);
    }
}


#region InitializerInterceptor_From_DI classes 

public class InitializerInterceptorFromDIDbContext : DbContext
{
    public InitializerInterceptorFromDIDbContext(DbContextOptions<InitializerInterceptorFromDIDbContext> options) : base(options) { }

}

public interface IInitializerInterceptorFromDIService { }

public class InitializerInterceptorFromDiService : IInitializerInterceptorFromDIService { }

public class InitializerInterceptorFromDIInitializerInterceptor : UnitOfWorkInterceptor
{
    public static bool Intercepted = false;
    public static bool ServiceFounded = false;

    public override void Initializing(UnitOfWorkItems items)
    {
        var service = items.Db.GetService<IInitializerInterceptorFromDIService>();

        Intercepted = true;
        ServiceFounded = service != null;
    }
}

#endregion

