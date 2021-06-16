using FluentValidation;
using Netension.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiabloII_Cookbook.Api.Extensions
{
    public static class RuleBuilderOptionsExtensions
    {
        public static IRuleBuilderOptions<TObject, TProperty> IsValueOf<TObject, TProperty>(this IRuleBuilderOptions<TObject, TProperty> builder, IEnumerable<Enumeration> values)
        {
            builder.Custom((property, context) =>
            {
                if (context.PropertyValue is null || !values.Any(v => v.Name.Equals(context.PropertyValue.ToString(), StringComparison.CurrentCultureIgnoreCase))) context.AddFailure(context.PropertyName, "Invalid value");
            });

            return builder;
        }
    }
}
