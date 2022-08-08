using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HttpClientMessenger.Service;
using HttpMessenger.Test.Feature.Dto;
using HttpMessenger.Test.Models;
using Xunit;
using Xunit.Abstractions;

namespace HttpMessenger.Test.Feature;

public class HttpMessengerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IHttpMessenger _messenger;

    public HttpMessengerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") };
        _messenger = new HttpClientMessenger.Service.HttpMessenger(client);
    }

    [Fact]
    public async Task GetPost_ShouldReturn_200Ok()
    {
        var actual = new Post
        {
            Id = 1,
            Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
            Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae " +
                   "ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto",
            UserId = 1
        };
        var (expected, success, statusCode) = await _messenger.Get<Post>("posts/1");

        expected.Should().BeEquivalentTo(actual);
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
    }
    
    [Fact]
    public async Task GetPosts_ShouldReturn_200Ok()
    {
        var (posts, success, statusCode) = await _messenger.Get<IList<Post>>("posts");
        
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
        posts.Should().BeOfType(typeof(List<>));
        posts.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task GetPosts_WithQueryParam_ObjectSyntax_ShouldReturn_200Ok()
    {
        var (posts, success, statusCode) = await _messenger.Get<IList<Post>>("posts", new { userId = 1 });
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
        posts.Should().BeOfType(typeof(List<>));
        posts.Should().NotBeEmpty();
        posts.Should().Contain(p => p.UserId == 1);
    }
    
    [Fact]
    public async Task GetPosts_WithQueryParam_NormalSyntax_ShouldReturn_200Ok()
    {
        var (posts, success, statusCode) = await _messenger.Get<IList<Post>>("posts?userId=1");
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
        posts.Should().BeOfType(typeof(List<>));
        posts.Should().NotBeEmpty();
        posts.Should().Contain(p => p.UserId == 1);
    }
    
    [Fact]
    public async Task GetPosts_WithMultipleQueryParams_ObjectSyntax_ShouldReturn_200Ok()
    {
        var (posts, success, statusCode) = 
            await _messenger.Get<IList<Post>>("posts", new { userId = 1, title = "qui est esse" });
        
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
        posts.Should().BeOfType(typeof(List<>));
        posts.Should().NotBeEmpty();
        posts.Should().Contain(p => p.UserId == 1 && p.Title == "qui est esse");
    }
    
    [Fact]
    public async Task GetPosts_WithMultipleQueryParams_NormalSyntax_ShouldReturn_200Ok()
    {
        var (posts, success, statusCode) = await _messenger.Get<IList<Post>>("posts?userId=1&title=qui est esse");
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
        posts.Should().BeOfType(typeof(List<>));
        posts.Should().NotBeEmpty();
        posts.Should().Contain(p => p.UserId == 1 && p.Title == "qui est esse");
    }

    [Fact]
    public async Task CreatePost_ShouldReturn_201Created()
    {
        var createPostDto = new CreatePostDto("Test Post", "Test Body", 1);
        
        var postDto = new PostDto(1, "Test Post", "Test Body", 1);

        (var data, bool success, int statusCode) = 
            await _messenger.Post<CreatePostDto, PostDto>("posts", createPostDto);
        
        Assert.Equal(postDto.Title, data.Title);
        Assert.Equal(postDto.Body, data.Body);
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.Created, statusCode);
    }

    [Fact]
    public async Task CreatePost_AsFormData_ShouldReturn201Created()
    {
        var formData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("title", "Test Post"),
            new KeyValuePair<string, string>("body", "Test Body"),
            new KeyValuePair<string, string>("userId", "1")
        });
        
        var postDto = new PostDto(1, "Test Post", "Test Body", 1);
        
        (var data, bool success, int statusCode) = 
            await _messenger.PostAsFormData<FormUrlEncodedContent, PostDto>("posts", formData);
        
        Assert.Equal(postDto.Title, data.Title);
        Assert.Equal(postDto.Body, data.Body);
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.Created, statusCode);
    }
    
    [Fact]
    public async Task CreatePost_AsMultipartFormData_ShouldReturn201Created()
    {
        var file = await File.ReadAllBytesAsync(Path.GetFullPath("./Resources/placeholder.png"));
        
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent("Test Post"), "title");
        formData.Add(new StringContent("Test body"), "body");
        formData.Add(new StringContent("1"), "userId");
        formData.Add(new ByteArrayContent(file), "file", "placeholder.png");
        
        (var data, bool success, int statusCode) = 
            await _messenger.PostAsFormData<MultipartFormDataContent, PostDto>("posts", formData);
        
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.Created, statusCode);
    }
    
    [Fact]
    public async Task PutPost_ShouldReturn_200Ok()
    {
        var updatePostDto = new UpdatePostDto(1, "Update Post", "Update Body", 1);

        var (success, statusCode) = 
            await _messenger.Put("posts/1", updatePostDto);
        
        Assert.True(success);
        // Should be a 204 No Content but since the free service
        // I'm using is not returning the correct code a 200 OK will do
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
    }

    [Fact]
    public async Task PutPost_WithTResponse_ShouldReturn_200Ok()
    {
        var updatePostDto = new UpdatePostDto(1, "Update Post", "Update Body", 1);
        var actual = new PostDto(1, "Update Post", "Update Body", 1);

        var (data, success, statusCode) = 
            await _messenger.Put<UpdatePostDto, PostDto>("posts/1", updatePostDto);
        
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
        data.Should().BeEquivalentTo(actual);
    }
    
    [Fact]
    public async Task PatchPost_ShouldReturn_200Ok()
    {
        var updatePostDto = new UpdatePostDto(1, "Update Post", "Update Body", 1);

        var (success, statusCode) = 
            await _messenger.Patch("posts/1", updatePostDto);
        
        Assert.True(success);
        // Should be a 204 No Content but since the free service
        // I'm using is not returning the correct code a 200 OK will do
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
    }

    [Fact]
    public async Task PatchPost_WithTResponse_ShouldReturn_200Ok()
    {
        var updatePostDto = new UpdatePostDto(1, "Update Post", "Update Body", 1);
        var actual = new PostDto(1, "Update Post", "Update Body", 1);

        var (data, success, statusCode) = 
            await _messenger.Patch<UpdatePostDto, PostDto>("posts/1", updatePostDto);
        
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
        data.Should().BeEquivalentTo(actual);
    }
    
    [Fact]
    public async Task DeletePost_ShouldReturn_204NoContent()
    {
        var (success, statusCode) = await _messenger.Delete("posts/1");
        
        Assert.True(success);
        // Should be a 204 No Content but since the free service
        // I'm using is not returning the correct code a 200 OK will do
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
    }
    
    [Fact]
    public async Task DeletePost_WithTResponse_ShouldReturn_200Ok()
    {
        var (data, success, statusCode) = await _messenger.Delete<PostDto>("posts/1");
        
        Assert.True(success);
        Assert.Equal((int)HttpStatusCode.OK, statusCode);
    }
}