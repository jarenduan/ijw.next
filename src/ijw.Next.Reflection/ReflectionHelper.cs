﻿using System;
using System.Linq.Expressions;
using System.Linq;
using ijw.Next.Collection;

namespace ijw.Next.Reflection {
    /// <summary>
    /// 反射功能帮助类
    /// </summary>
    public static class ReflectionHelper {
        /// <summary>
        /// 根据属性名列表和值（字符串形式）列表创建指定类型的新实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyNames">属性名列表</param>
        /// <param name="values">字符串形式的值列表</param>
        /// <returns>创建的新实例</returns>
        public static T CreateNewInstance<T>(string[] propertyNames, string[] values) where T : class, new() {
            //TODO: remove new()

            propertyNames.ShouldBeNotNullArgument(nameof(propertyNames));
            int fieldCount = propertyNames.Count();
            values.ShouldBeNotNullArgument(nameof(values));
            values.ShouldSatisfy(s => s.Count() == fieldCount);

            T obj = new T();
            (values, propertyNames).ForEachPair((s, h) => {
                obj.SetPropertyValue(h, s);
            });

            return obj;
        }

        /// <summary>
        /// 获取属性的名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr">实例属性的表达式, 如foo => foo.bar </param>
        /// <returns>属性的名称</returns>
        public static string GetPropertyName<T>(Expression<Func<T, object>> expr) {
            var rtn = "";
            switch (expr.Body) {
                case UnaryExpression expression:
                    rtn = ((MemberExpression)expression.Operand).Member.Name;
                    break;
                case MemberExpression expression1:
                    rtn = expression1.Member.Name;
                    break;
                case ParameterExpression expression2:
                    rtn = expression2.Type.Name;
                    break;
            }
            return rtn;
        }
    }
}
