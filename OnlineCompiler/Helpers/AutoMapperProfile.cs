using AutoMapper;
using OnlineCompiler.Data.DBModels;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<AppTask, AppTaskDTO>().ReverseMap();
            CreateMap<CompletedTask, CompletedTaskDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Answer, AnswerDTO>().ReverseMap(); 
        }
    }
}
