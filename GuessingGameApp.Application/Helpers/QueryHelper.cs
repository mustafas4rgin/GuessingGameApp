using GuessingGameApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuessingGameApp.Application.Helpers;

public static class QueryHelper
{
    public static IQueryable<Role> ApplyIncludesForRole(IQueryable<Role> query, string include)
    {
        if (string.IsNullOrEmpty(include))
            return query;

        var includes = include.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (var inc in includes.Select(i => i.Trim().ToLower()))
        {
            switch (inc)
            {
                case "users": query.Include(r => r.Users); break;
            }
        }

        return query;
    }
}