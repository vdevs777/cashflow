using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(destiny => destiny.Password, config => config.Ignore());

        CreateMap<RequestExpenseJson, Expense>()
            .ForMember(
            destiny => destiny.Tags,
            config => config.MapFrom(
                source => source.Tags.Distinct()
            ));

        CreateMap<Communication.Enums.Tag, Tag>()
            .ForMember(
            destiny => destiny.Value,
            config => config.MapFrom(
                source => source
            ));
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseExpenseJson>()
            .ForMember(
            destiny => destiny.Tags,
            config => config.MapFrom(
                source => source.Tags.Select(
                    tag => tag.Value
                ))
            );

        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<User, ResponseUserProfileJson>();
    }
}
