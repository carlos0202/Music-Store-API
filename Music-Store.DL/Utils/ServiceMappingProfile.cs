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
            CreateMap<Album, AlbumDTO>()
                .ForMember(
                    dto => dto.Artist,
                    map => map.MapFrom(source => source.Artist.PublicName)
                )
                .ForMember(
                    dto => dto.Genre,
                    map => map.MapFrom(source => source.Genre.Name)
                )
                .ForMember(
                    dto => dto.ITunesReview,
                    map => map.MapFrom(source => source.Description)
                );
            CreateMap<IEnumerable<Review>, AlbumReviewInfo>()
                .ForMember(
                    dto => dto.ReviewsCount,
                    map => map.MapFrom(source => source.Count())
                )
                .ForMember(
                    dto => dto.AlbumId,
                    map => map.MapFrom(
                        (source, destination, _, context) =>
                        {
                            if (!source.Any())
                            {
                                return 0;
                            }

                            return source.First().AlbumId;
                        })
                )
                .ForMember(
                    dto => dto.AverageScore,
                    map => map.MapFrom(
                        (source, destination, _, context) =>
                        {
                            if (!source.Any())
                            {
                                return 0;
                            }

                            return source.Average(e => e.Score);
                        })
                );
            CreateMap<Song, SongDTO>()
                .ForMember(
                    dto => dto.Artist,
                    map => map.MapFrom(source => source.Artist.PublicName)
                )
                .ForMember(dto => dto.PopularityIndex,
                    opt => opt.MapFrom(
                        (source, destination, _, context) =>
                        {
                            // This context property needs to be sent when calling the
                            // mapper object.
                            var MaxUsers = Convert.ToDecimal(context.Options.Items["MaxUsers"]);

                            if (MaxUsers == 0)
                            {
                                return 0;
                            }

                            var UniqueReproductions =
                                source.Reproductions.GroupBy(x => x.UserId).Count();

                            return UniqueReproductions / MaxUsers;
                        }
                    )
                );
        }
    }
}
