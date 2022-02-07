using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PlaceHolderProject.Repositories.Albums;
using PlaceHolderProject.Repositories.Comments;
using PlaceHolderProject.Repositories.Factories;
using PlaceHolderProject.Repositories.Photos;
using PlaceHolderProject.Repositories.Posts;
using PlaceHolderProject.Repositories.Todos;
using PlaceHolderProject.Repositories.Users;

namespace PlaceHolderProject.App_Start
{
    public class Startup
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // register controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // data repositories
            builder.Register(x => UserRepositoryFactory.GetRepository()).As<IUserRepository>().InstancePerRequest();
            builder.Register(x => PostRepositoryFactory.GetRepository()).As<IPostRepository>().InstancePerRequest();
            builder.Register(x => PhotoRepositoryFactory.GetRepository()).As<IPhotoRepository>().InstancePerRequest();
            builder.Register(x => AlbumRepositoryFactory.GetRepository()).As<IAlbumRepository>().InstancePerRequest();
            builder.Register(x => CommentRepositoryFactory.GetRepository()).As<ICommentRepository>().InstancePerRequest();
            builder.Register(x => ToDoRepositoryFactory.GetRepository()).As<IToDoRepository>().InstancePerRequest();

            // set resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}