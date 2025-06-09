﻿using CashFlow.Domain.Entities;

namespace WebApi.Test.Resources;

public class ExpenseIdentityManager
{
    private Expense _expense;

    public ExpenseIdentityManager(Expense expense)
    {
        _expense = expense;
    }

    public long GetId() => _expense.Id;
}

