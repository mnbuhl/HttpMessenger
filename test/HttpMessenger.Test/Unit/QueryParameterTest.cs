using HttpMessenger.Helpers;
using Xunit;

namespace HttpMessenger.Test.Unit;

public class QueryParameterTest
{
    [Fact]
    public void Query_IsCorrectlyParsed_WhenStringsUsed()
    {
        // Arrange
        var queryParams = new { foo = "bar", fee = "bas" };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?foo=bar&fee=bas", result);
    }
    
    [Fact]
    public void Query_IsCorrectlyParsed_WhenNumbersUsed()
    {
        // Arrange
        var queryParams = new { one = 1, two = 2 };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?one=1&two=2", result);
    }
    
    private class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
    
    [Fact]
    public void Query_IsCorrectlyParsed_WhenCustomClassUsed()
    {
        var person = new Person { Name = "John", Age = 30 };
        
        // Arrange
        var queryParams = new { person };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?name=John&age=30", result);
    }
    
    private class Wallet
    {
        public string? Currency { get; set; }
        public long Balance { get; set; }
        public Person Person { get; set; }
    }
    
    [Fact]
    public void Query_IsCorrectlyParsed_WhenClassWithNestedObjectUsed()
    {
        var person = new Person { Name = "John", Age = 30 };

        var wallet = new Wallet
        {
            Currency = "DKK",
            Balance = 100000,
            Person = person
        };
        
        // Arrange
        var queryParams = new { wallet };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?currency=DKK&balance=100000&name=John&age=30", result);
    }

    [Fact]
    public void Query_IsCorrectlyEncoded_WhenSpecialCharsUsed()
    {
        // Arrange
        var queryParams = new { foo = "[b @: r]" };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?foo=%5bb+%40%3a+r%5d", result);
    }

    [Fact]
    public void QueryParameter_IsConverted_ToCamelCase()
    {
        // Arrange
        var queryParams = new { FooBar = "fooBar", FeeBas = "feeBas" };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?fooBar=fooBar&feeBas=feeBas", result);
    }
}