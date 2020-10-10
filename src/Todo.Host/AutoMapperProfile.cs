using AutoMapper;
using Todo.Application.Commands;
using Todo.Application.Domain.LableAggregate;
using Todo.Application.Queries;
using Todo.Host.Controllers;

namespace Todo.Host
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Create Label
            CreateMap<CreateLabelViewModel, CreateLabelCommand>();
            CreateMap<LabelColorViewModel, CreateLabelCommanColor>();

            // Update Label
            CreateMap<UpdateLabelViewModel, UpdateLabelCommand>();
            CreateMap<LabelColorViewModel, UpdateLabelCommanColor>();

            // Get Label By Id
            CreateMap<Label, GetLabelQueryResponse>();
            CreateMap<Color, GetLabelQueryResponseColor>();
            CreateMap<GetLabelQueryResponse, LabelViewModel>();
            CreateMap<GetLabelQueryResponseColor, LabelColorViewModel>();

            // Get Labels
            CreateMap<Label, GetLabelsQueryResponseLabel>();
            CreateMap<Color, GetLabelsQueryResponseColor>();
            CreateMap<GetLabelsQueryResponseLabel, LabelViewModel>();
            CreateMap<GetLabelsQueryResponseColor, LabelColorViewModel>();
        }
    }
}
