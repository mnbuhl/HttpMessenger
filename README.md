# HttpService

HttpService is a service that provides a simple generic wrapper around the HttpClient and makes it easier to make requests to an API.

## Usage guide
### Install the package
TODO

### Add the service to your app
Configure your HttpClient in the dependency injection container like you normally would.

Program.cs (.NET 6 >) example:
```c#
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/") 
});
```

Then add the HttpService service to your Dependency Injection container
```c#
builder.Services.AddHttpService();
```

Startup.cs (.NET 6 <) Example:
```c#
services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("Set your base address here") 
});
```

Then add the HttpService service to your Dependency Injection container
```c#
services.AddHttpService();
```

### Usage

The service is now available to use and can be injected into Blazor components, Controllers or any other service registered with the DI container.

#### Blazor component example
```c#
// Can be injected like this
@inject IHttpService _httpService

@code {
    // or this
    [Inject]
    private IHttpService HttpService { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        var response = await HttpService.Get<IList<ProductDto>>("products");
        _products = response.Data;
    }
}
```

#### Controller example
```c#
public class ProductsController : Controller
{
    private readonly IHttpService _httpService;
    
    public ProductsController(IHttpService httpService)
    {
        _httpService = httpService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _httpService.Get<IList<ProductDto>>("products");
        return View(response.Data);
    }
```

#### Service example
```c#
public class ProductsService : IProductsService
{
    private readonly IHttpService _httpService;
    private const string Endpoint = "api/products";
    
    public ProductsService(IHttpService httpService)
    {
        _httpService = httpService;
    }
    
    public async Task<List<ProductDto>> GetProducts()
    {
        var response = await _httpService.Get<List<ProductDto>>(Endpoint);
        return response.Data;
    }
    
    public async Task<ProductDto> CreateProduct(CreateProductDto product)
    {
        var response = await _httpService.Post<CreateProductDto, ProductDto>(Endpoint, product);
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