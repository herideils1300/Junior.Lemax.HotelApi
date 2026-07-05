using HotelApi.Api;
using HotelApi.Domain.Data.Location.Dto;
using HotelApi.Domain.Data.Users.Dto;
using HotelApi.Infrastructure.Persistance.Context.Variance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
public class HotelControllerTests
{
    private MssqlDbContext CreateContext()
    {
        var options = new ConfigurationBuilder()
            .SetBasePath("HotelApi/appsettings.json");

        return new MssqlDbContext(options);
    }

    [Fact]
    public void Get_ReturnsAllHotels()
    {
        var context = CreateContext();
        context.Hotels.Add(new HotelDto { Id = 1, Name = "Test", Location = new LocationDto() });
        context.SaveChanges();

        var controller = new HotelController(context);

        var result = controller.Get().Result as OkObjectResult;

        Assert.NotNull(result);
        Assert.That((IEnumerable<HotelDto>)result.Value);
    }

    [Fact]
    public void Post_ReturnsBadRequest_WhenNull()
    {
        var controller = new HotelController(CreateContext());

        var result = controller.Post(null);

        Assert.IsType<BadRequestResult>(result);
    }
}
