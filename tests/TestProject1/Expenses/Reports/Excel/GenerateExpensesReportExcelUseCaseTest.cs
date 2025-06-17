using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Tests.Expenses.Reports.Excel;

public class GenerateExpensesReportExcelUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var loggedUser = UserBuilder.Build();
        var expenses = ExpenseBuilder.Collection(loggedUser);

        var useCase = CreateUseCase(loggedUser, expenses);

        var result = await useCase.Execute(DateOnly.FromDateTime(DateTime.Now));

        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Success_Empty()
    {
        var loggedUser = UserBuilder.Build();
        var expenses = new List<Expense>();
        var useCase = CreateUseCase(loggedUser, expenses);
        var result = await useCase.Execute(DateOnly.FromDateTime(DateTime.Now));
        result.Should().BeEmpty();
    }

    private GenerateExpensesReportExcelUseCase CreateUseCase(User user, List<Expense> expenses)
    {
        var repository = new ExpensesReadOnlyRepositoryBuilder().FilterByMonth(user, expenses).Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GenerateExpensesReportExcelUseCase(repository, loggedUser);
    }
}

