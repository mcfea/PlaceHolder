namespace PlaceHolderProject.Repositories.Users
{
    public static class UserRepositoryFactory
    {
        public static IUserRepository GetUserRepository() => new HttpUserRepository();
    }
}