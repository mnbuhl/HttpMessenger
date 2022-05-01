using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HttpClientMessenger.Exceptions;
using HttpClientMessenger.Helpers;
using HttpMessenger.Test.Models;
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
    
    [Fact]
    public void Query_IsCorrectlyParsed_WhenDateTimeUsed()
    {
        // Arrange
        var date = DateTime.Parse("01/02/2022 22.08.09");
        var queryParams = new { date };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?date=2022-02-01T22%3a08%3a09.0000000", result);
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

    [Fact]
    public void Query_IsCorrectlyParsed_WhenCustomRecordUsed()
    {
        var weather = new Weather("London", 20.5);
        
        // Arrange
        var queryParams = new { weather };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?city=London&temperature=20.5", result);
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
    public void Query_IsCorrectlyParsed_WhenArrayUsed()
    {
        int[] arr = { 1, 2, 3 };

        // Arrange
        var queryParams = new { arr };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?arr=1&arr=2&arr=3", result);
    }
    
    // A list of objects should be parsed as a query string
    [Fact]
    public void Query_ThrowsExceptionWhen_EnumerableOfObjectsUsed()
    {
        // Arrange
        var person1 = new Person { Name = "John", Age = 30 };
        var person2 = new Person { Name = "Mark", Age = 32 };

        // Act
        Person[] arr = { person1, person2 };
        var arrParams = new { arr };

        var list = new List<Person> { person1, person2 };
        var listParams = new { list };
        
        var collection = new Collection<Person> { person1, person2 };
        var collectionParams = new { collection };

        // Assert
        Assert.Throws<EnumerableOfObjectsException>(() => QueryParameterParser.GetQueryString(arrParams));
        Assert.Throws<EnumerableOfObjectsException>(() => QueryParameterParser.GetQueryString(listParams));
        Assert.Throws<EnumerableOfObjectsException>(() => QueryParameterParser.GetQueryString(collectionParams));
    }
    
    [Fact]
    public void Query_IsCorrectlyParsed_WhenListOfIntUsed()
    {
        var list = new List<int> { 1, 2, 3 };

        // Arrange
        var queryParams = new { list };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?list=1&list=2&list=3", result);
    }
    
    [Fact]
    public void Query_IsCorrectlyParsed_WhenListOfStringUsed()
    {
        var list = new List<string> { "Hello", "World" };

        // Arrange
        var queryParams = new { list };
        
        // Act
        string result = QueryParameterParser.GetQueryString(queryParams);
        
        // Assert
        Assert.Equal("?list=Hello&list=World", result);
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