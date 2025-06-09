﻿using CashFlow.Application.UseCases.User;
using CashFlow.Application.UseCases.User.Register;
using CashFlow.Communication.Requests;
using CommonTestUtilities.Requests;
using FluentAssertions;
using FluentValidation;

namespace Validators.Tests.Users;

public class PasswordValidatorTest
{
    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("aaa")]
    [InlineData("aaaa")]
    [InlineData("aaaaa")]
    [InlineData("aaaaaa")]
    [InlineData("aaaaaaa")]
    [InlineData("aaaaaaaa")]
    [InlineData("AAAAAAAA")]
    [InlineData("Aaaaaaaa")]
    [InlineData("Aaaaaaaa1")]
    public void Error_Password_Invalid(string password)
    {
        var validator = new PasswordValidator<RequestRegisterUserJson>();

        var result = validator.IsValid(new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson()), password);

        result.Should().BeFalse();
    }
}

