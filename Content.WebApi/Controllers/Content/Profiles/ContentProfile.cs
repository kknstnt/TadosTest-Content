namespace Content.WebApi.Controllers.Content.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using Dto;
    using System.Linq;

    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, ContentListItemDto>()
                .ForMember(
                    dest => dest.AverageRating,
                    opts => opts.MapFrom(src => (src.ContentRatings.Count() > 0)? src.ContentRatings.Select(rtg => rtg.Rate).Average() : 0))
                .Include<Article, ArticleListItemDto>()
                .Include<Video, VideoListItemDto>()
                .Include<Gallery, GalleryListItemDto>();

            CreateMap<Article, ArticleListItemDto>();
            CreateMap<Video, VideoListItemDto>();
            CreateMap<Gallery, GalleryListItemDto>()
                .ForMember(
                    dest => dest.ImagesUrls,
                    opts => opts.MapFrom(src => src.Images.Select(i => i.Url)));

            CreateMap<Content, ContentDto>()
                .ForMember(
                    dest => dest.AverageRating,
                    opts => opts.MapFrom(src => (src.ContentRatings.Count() > 0) ? src.ContentRatings.Select(rtg => rtg.Rate).Average() : 0))
                .Include<Article, ArticleDto>()
                .Include<Video, VideoDto>()
                .Include<Gallery, GalleryDto>();

            CreateMap<Article, ArticleDto>();
            CreateMap<Video, VideoDto>();
            CreateMap<Gallery, GalleryDto>()
                .ForMember(
                    dest => dest.ImagesUrls,
                    opts => opts.MapFrom(src => src.Images.Select(i => i.Url)));
        }
    }
}
