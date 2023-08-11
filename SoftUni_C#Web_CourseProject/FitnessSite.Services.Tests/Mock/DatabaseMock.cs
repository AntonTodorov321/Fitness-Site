namespace FitnessSite.Services.Tests.Mock
{
    using Microsoft.EntityFrameworkCore;

    using Web.Data;

    public static class DatabaseMock
    {
        public static FitnessSiteDbContext Instance
        {
            get
            {
                var dbOptions = new DbContextOptionsBuilder<FitnessSiteDbContext>()
                .UseInMemoryDatabase("FitnessSiteInMemory" + Guid.NewGuid().ToString())
                .Options;

                return new FitnessSiteDbContext(dbOptions);
            }
        }
    }
}
