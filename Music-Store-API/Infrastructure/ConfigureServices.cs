using Microsoft.Extensions.DependencyInjection;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
using Music_Store.DL.Repositories;
using Music_Store.DL.Services;

namespace Music_Store_API.Infrastructure
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Album, long>, AlbumRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IRepository<Review, long>, ReviewRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMusicStoreService, MusicStoreService>();
        }
    }
}
