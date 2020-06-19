using AutoMapper;
using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PackageEntity, Package>()
                .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.Cost - (src.Discount / 100 * src.Cost)));
            CreateMap<MemberEntity, Member>();
            CreateMap<TrainerEntity, Trainer>();
            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Password)))
                .ForMember(dest => dest.PasswordSalt, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.PasswordSalt)));
            CreateMap<FeedbackEntity, Feedback>();
        }
    }
}
