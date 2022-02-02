using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HttpMessenger.Service;
using HttpMessenger.Test.Feature.Dto;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace HttpMessenger.Test.Feature;

public class HttpMessengerTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IHttpMessenger _messenger;

    public HttpMessengerTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var client = new HttpClient { BaseAddress = new Uri("https://reqres.in/api/") };
        _messenger = new Service.HttpMessenger(client);
    }

    [Fact]
    public async Task Get_ShouldReturn_200Ok()
    {
        var actual = new Response
        {
            Data = new Data
            {
                Id = 1,
                Name = "cerulean",
                Year = 2000,
                Color = "#98B2D1",
                Pantone_Value = "15-4020"
            },
            Support = new Support
            {
                Url = "https://reqres.in/#support-heading",
                Text = "To keep ReqRes free, contributions towards server costs are appreciated!"
            }
        };
        
        var (expected, success, statusCode) = await _messenger.Get<Response>("product/1");

        expected.Should().BeEquivalentTo(actual);
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
    }

    [Fact]
    async Task CreateProduct_ShouldReturn_201Created()
    {
        var createProductDto = new CreateProductDto("Test Name", "Test Description", 10000);
        
        var productDto = new ProductDto("200", "Test Name", "Test Description", 10000, DateTime.UtcNow);

        (var data, bool success, int statusCode) = 
            await _messenger.Post<CreateProductDto, ProductDto>("products", createProductDto);
        
        Assert.Equal(productDto.Name, data.Name);
        Assert.Equal(productDto.Description, data.Description);
        Assert.Equal(productDto.Price, data.Price);
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.Created, statusCode);
    }
}