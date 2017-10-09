﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Mono;
using Puresharp;
using Puresharp.Confluence;

namespace Mono.Cecil
{
    static internal class __FieldDefinition
    {
        static public CustomAttribute Attribute<T>(this FieldDefinition field)
            where T : Attribute
        {
            var _attribute = new CustomAttribute(field.Module.Import(typeof(T).GetConstructor(System.Type.EmptyTypes)));
            field.CustomAttributes.Add(_attribute);
            return _attribute;
        }

        static public CustomAttribute Attribute<T>(this FieldDefinition field, Expression<Func<T>> expression)
            where T : Attribute
        {
            var _constructor = (expression.Body as NewExpression).Constructor;
            var _attribute = new CustomAttribute(field.Module.Import(_constructor));
            foreach (var _argument in (expression.Body as NewExpression).Arguments) { _attribute.ConstructorArguments.Add(new CustomAttributeArgument(field.Module.Import(_argument.Type), Expression.Lambda<Func<object>>(Expression.Convert(_argument, Metadata<object>.Type)).Compile()())); }
            field.CustomAttributes.Add(_attribute);
            return _attribute;
        }

        static public FieldReference Relative(this FieldDefinition field)
        {
            if (field.DeclaringType.GenericParameters.Count == 0) { return field; }
            return new FieldReference(field.Name, field.DeclaringType.Module.Import(field.FieldType), field.DeclaringType.MakeGenericType(field.DeclaringType.GenericParameters));
        }
    }
}
