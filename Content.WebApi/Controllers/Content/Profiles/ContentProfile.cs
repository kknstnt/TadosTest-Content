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
                .ForMember(
                    dest => dest.Creator,
                    opts => opts.MapFrom(src => src.Creator))
                .Include<Article, ArticleListItemDto>()
                .Include<Video, VideoListItemDto>()
                .Include<Gallery, GalleryListItemDto>();

            CreateMap<Article, ArticleListItemDto>();
            CreateMap<Video, VideoListItemDto>();
            CreateMap<Gallery, GalleryListItemDto>();

            CreateMap<Content, ContentDto>()
                .ForMember(
                    dest => dest.AverageRating,
                    opts => opts.MapFrom(src => (src.ContentRatings.Count() > 0) ? src.ContentRatings.Select(rtg => rtg.Rate).Average() : 0))
                .ForMember(
                    dest => dest.Creator,
                    opts => opts.MapFrom(src => src.Creator))
                .ForPath(
                    dest => dest.Creator.City,
                    opts => opts.MapFrom(src => src.Creator.City))
                .ForPath(
                    dest => dest.Creator.City.CountryDto,
                    opts => opts.MapFrom(src => src.Creator.City.Country))
                .Include<Article, ArticleDto>()
                .Include<Video, VideoDto>()
                .Include<Gallery, GalleryDto>();

            CreateMap<Article, ArticleDto>();
            CreateMap<Video, VideoDto>();
            CreateMap<Gallery, GalleryDto>();
        }
    }
}
