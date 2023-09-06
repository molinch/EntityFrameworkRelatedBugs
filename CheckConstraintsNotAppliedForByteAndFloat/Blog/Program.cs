using Blog;
using Microsoft.EntityFrameworkCore;

await CreateDatabase();

using var db = new BlogContext();

db.Posts.ExecuteDelete();

List<Post> postToAdd = new()
{
    new() {PostType = PostType.Food},
    new() {PostType = PostType.Food},
    new() {PostType = PostType.Health},
    new() {PostType = PostType.Health},
    new() {PostType = PostType.Health},
    new() {PostType = PostType.Travel},
    new() {PostType = PostType.Travel},
    new() {PostType = PostType.Travel},
};

db.AddRange(postToAdd);

db.SaveChanges();

List<Post> foodPosts = db.Posts.Where(p => p.PostType == PostType.Food).ToList();

// Correctly got 2
Console.WriteLine(foodPosts.Count);


List<PostType> postTypes = new() { PostType.Health, PostType.Travel };

List<Post> healthAndTravelPosts = db.Posts.Where(p => postTypes.Contains(p.PostType)).ToList();

// Should be 6 but got 0
Console.WriteLine(healthAndTravelPosts.Count);


static async Task CreateDatabase()
{
    using (var dbcontext = new BlogContext())
    {
        await dbcontext.Database.MigrateAsync();
    }
}