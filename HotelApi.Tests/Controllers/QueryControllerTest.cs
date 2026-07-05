using HotelApi.Api;
using HotelApi.Application.Services.Hotels.Services;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class QuerryControllerTests
{
    private MssqlDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<MssqlDbContext>()
            .UseSqlServer("QueryDb")
            .Options;

        return new MssqlDbContext(options);
    }

    [Fact]
    public void QueryHotels_ReturnsBadRequest_WhenNull()
    {
        var controller = new QuerryController(
            CreateContext(),
            new SortHotelsByDistance(),
            new FilterByRadiusAndPrice()
        );

        var result = controller.QueryHotels(null);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}
