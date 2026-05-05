using AutoMapper;
using CodeApp.Models.DTOs;
using CodeApp.Models.Entities;

namespace CodeApp.Mappings
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food,FoodDTO>().ReverseMap();

            CreateMap<Producer, ProducerDTO>().ReverseMap();
            
            CreateMap<FoodProducer, FoodProducerCalorieDTO>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(fp => fp.producerId))
                .ForMember(dest => dest.name, opt => opt.MapFrom(fp => fp.producer.name))
                .ForMember(dest => dest.calories, opt => opt.MapFrom(fp => fp.calories));

            CreateMap<Food, FoodDetailsDTO>()
                .ForMember(dest => dest.producers, opt => opt.MapFrom(fd => fd.foodProducers))
                .ReverseMap();

            CreateMap<LinkFoodToProduerDTO, FoodProducer>()
                .ForMember(dest => dest.producerId, opt => opt.MapFrom(lftp => lftp.id))
                .ForMember(dest => dest.calories, opt => opt.MapFrom(lftp => lftp.calories))
                .ReverseMap();

            CreateMap<LinkProducerToFoodDTO, FoodProducer>()
                .ForMember(dest => dest.foodId, opt => opt.MapFrom(lftp => lftp.id))
                .ForMember(dest => dest.calories, opt => opt.MapFrom(lftp => lftp.calories))
                .ReverseMap();


            CreateMap<CreateFoodDTO, Food>()
                .ForMember(dest => dest.foodProducers, opt => opt.MapFrom(cf => cf.producers));
        }

    }
}
