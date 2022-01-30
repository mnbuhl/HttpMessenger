# HttpMessenger

HttpMessenger is a service for ASP.NET Core that provides a simple generic wrapper around the HttpClient and makes it easier to make requests to an API.

## Usage guide
### Install the package
Package Manager Console:
```bash
Install-Package HttpMessenger
```

dotnet CLI:
```bash
dotnet add package HttpMessenger
```

Or simply get it from the [NuGet Gallery](https://www.nuget.org/packages/HttpMessenger/).

### Add the service to your app
Configure your HttpClient in the dependency injection container like you normally would.

Program.cs (.NET 6 >) example:
```c#
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/") 
});
```

Then add the HttpMessenger service to your Dependency Injection container
```c#
builder.Services.AddHttpMessenger();
```

Startup.cs (.NET 6 <) Example:
```c#
services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("Set your base address here") 
});
```

Then add the HttpMessenger service to your Dependency Injection container
```c#
services.AddHttpMessenger();
```

### Usage

The service is now available to use and can be injected into Blazor components, Controllers or any other service registered with the DI container.

#### Blazor component example
```c#
// Can be injected like this
@inject IHttpMessenger _httpMessenger

@code {
    // or this
    [Inject]
    private IHttpMessenger HttpMessenger { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        var response = await HttpMessenger.Get<IList<ProductDto>>("products");
        _products = response.Data;
    }
}
```

#### Controller example
```c#
public class ProductsController : Controller
{
    private readonly IHttpMessenger _httpMessenger;
    
    public ProductsController(IHttpMessenger httpMessenger)
    {
        _httpMessenger = httpMessenger;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _httpMessenger.Get<IList<ProductDto>>("products");
        return View(response.Data);
    }
```

#### Service example
```c#
public class ProductsService : IProductsService
{
    private readonly IHttpMessenger _httpMessenger;
    private const string Endpoint = "api/products";
    
    public ProductsService(IHttpMessenger httpMessenger)
    {
        _httpMessenger = httpMessenger;
    }
    
    public async Task<List<ProductDto>> GetProducts()
    {
        var response = await _httpMessenger.Get<List<ProductDto>>(Endpoint);
        return response.Data;
    }
    
    public async Task<ProductDto> CreateProduct(CreateProductDto product)
    {
        var response = await _httpMessenger.Post<CreateProductDto, ProductDto>(Endpoint, product);
        return response.Data;
    }
}
```

### Supported HTTP methods
* GET
* POST
* PUT
* PATCH
* DELETE

## TODO
* Simple query parameters (have to be manually added to the url)
* Proper tests
* IHttpClientFactory support if you want to use multiple HttpClients

### Something missing?
Feel free to open an issue or make a pull request.