using CashFlow.Application.UseCases.User.Profile;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Mapper;
using FluentAssertions;

namespace UseCases.Tests.Users.Profile;

public class GetUserProfileUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var user = UserBuilder.Build();
        var useCase = CreateUseCase(user);

        var response = await useCase.Execute();

        response.Should().NotBeNull();
        response.Name.Should().Be(user.Name);
        response.Email.Should().Be(user.Email);
    }

    private GetUserProfileUseCase CreateUseCase(User user)
    {
        var mapper = MapperBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GetUserProfileUseCase(loggedUser, mapper);
    }
}

