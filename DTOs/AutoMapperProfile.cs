using AutoMapper;
using DataAccessLayer.Entities;
using DTOs.AnswerD;
using DTOs.BaseD;
using DTOs.CommentD;
using DTOs.QuestionD;
using DTOs.QuestionTagD;
using DTOs.SavedD;
using DTOs.TagD;
using DTOs.UserD;

namespace DTOs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Answer, AnswerDto>();
        CreateMap<AddAnswerDto , Answer>();
        CreateMap<UpdateAnswerDto, Answer>();

        CreateMap<BaseEntity, BaseDto>().ReverseMap();

        CreateMap<Comment, CommentDto>();
        CreateMap<AddCommentDto, Comment>();
        CreateMap<UpdateCommentDto, Comment>();

        CreateMap<Question, QuestionDto>();
        CreateMap<AddQuestionDto, Question>();
        CreateMap<UpdateQuestionDto, Question>();

        CreateMap<QuestionTag, QuestionTagDto>();
        CreateMap<AddQuestionTagDto, QuestionTag>();
        CreateMap<UpdateQuestionTagDto, QuestionTag>();


        CreateMap<Saved,SavedDto>();
        CreateMap<AddSavedDto, Saved>();
        CreateMap<UpdateSavedDto, Saved>();


        CreateMap<Tag, TagDto>();
        CreateMap<AddTagDto, Tag>();
        CreateMap<UpdateTagDto, Tag>();
    }
}
