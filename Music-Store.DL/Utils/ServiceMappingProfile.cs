using AutoMapper;
using Music_Store.DAL.Models;
using Music_Store.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Utils
{
    /// <summary>
    /// Automapper mapping profile to transform model values 
    /// obtained from repositories into DTOs to send to the
    /// API's controller layer.
    /// </summary>
    public class ServiceMappingProfile : Profile
    {
        /// <summary>
        /// Creates maps between selected entities from DAL layer
        /// with DTOs defined inside the DL layer to get only relevant
        /// data returned to the client calling code.
        /// </summary>
        public ServiceMappingProfile()
        {
            CreateMap<Album, AlbumDTO>();
            CreateMap<IEnumerable<Review>, AlbumReviewInfo>()
                .ForMember(
                    dto => dto.AlbumId, 
                    map => map.MapFrom(source => source.Single().Album)
                )
                .ForMember(
                    dto => dto.AverageScore,
                    map => map.MapFrom(source => source.Average(e => e.Score))
                );
            CreateMap<Song, SongDTO>()
                .ForMember(dto => dto.PopularityIndex,
                    opt => opt.MapFrom(
                        (source, destination, _, context) =>
                        {
                            // This context property needs to be sent when calling the
                            // mapper object.
                            var MaxUsers = (int)context.Options.Items["bar"];
                            var UniqueReproductions =
                                source.Reproductions.GroupBy(x => x.UserId).Count();

                            return UniqueReproductions / MaxUsers;
                        }
                    )
                );
        }
    }
}
