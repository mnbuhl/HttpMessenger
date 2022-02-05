namespace HttpMessenger.Test.Feature.Dto;

public record PostDto(int Id, string? Title, string? Body, int UserId);
public record CreatePostDto(string? Title, string? Body, int UserId);
public record UpdatePostDto(int Id, string? Title, string? Body, int UserId);