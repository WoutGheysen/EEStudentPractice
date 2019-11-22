using AutoMapper;
using Oefenplatform.Lib.Models;
using Oefenplatform.Lib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oefenplatform.Lib.DTO.QuestionDto;

namespace Oefenplatform.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile")
        {

        }

        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            //Math Questions DTO's
            CreateMap<Question, MathFirstGradeQuestionDto>();
            CreateMap<Question, MathSecondGradeQuestionDto>();

            //Language Questions DTO's
            CreateMap<Question, LangFirstGradeQuestionDto>().ForMember(
                dest => dest.Answer,
                opts => opts.MapFrom(src => src.Answer.LangAnswer));
            CreateMap<Question,LangSecondGradeQuestionDto>().ForMember(
                dest => dest.Answer,
                opts => opts.MapFrom(src => src.Answer.LangAnswer));
            CreateMap<Question, LangThirdGradeQuestionDto>().ForMember(
                dest => dest.Answer,
                opts => opts.MapFrom(src => src.Answer.LangAnswer));
        }
    }
}
