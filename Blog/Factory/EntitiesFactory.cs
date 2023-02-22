using Blog.Models;

namespace Blog.Factory
{
    public static class EntitiesFactory
    {
        public static UserModel CreateUser(string email,
                                           string passwordHash,
                                           string bio,
                                           string image,
                                           string name)
        {
            return new UserModel()
            {
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Name = name,
                Slug = CreateSlug(name)
            };
        }

        public static RoleModel CreateRole(string name) 
        {
            return new RoleModel()
            {
                Name = name,
                Slug = CreateSlug(name)

            };
        }

        private static string CreateSlug(string name)
        {
            return $"{name}{Guid.NewGuid().ToString().Substring(0, 8)}";
        }

        public static CategoryModel CreateCategory(string name)
        {
            return new CategoryModel()
            {
                Name = name,
                Slug = CreateSlug(name)
            };
        }

        internal static TagModel CreateTag(string name)
        {
            return new TagModel()
            {
                Name = name,
                Slug = CreateSlug(name)
            };
        }

        internal static PostModel CreatePost(int idAuthor, int idCategory, string title, string summary, string body)
        {
            return new PostModel()
            {
                CategoryId = idCategory,
                AuthorId = idAuthor,
                Title = title,
                Summary = summary,
                Body = body,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                Slug = CreateSlug(title)
            };
        }

        public static PostTagModel CreatePostTag(int idPost, int idTag)
        {
            return new PostTagModel()
            {
                PostId = idPost,
                TagId = idTag,
            };
        }
    }
}
