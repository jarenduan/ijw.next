﻿using System;
using System.Reflection;

namespace ijw.Next {
    /// <summary>
    /// 
    /// </summary>
    public static class TypeExt {
        /// <summary>
        /// 返回命名空间.类名[命名空间.泛型参数1类名,命名空间.泛型参数2类名,...,命名空间.泛型参数n类名]
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeName(this Type type) {
            //TODO: check #if condition what about netstandard 2.0
#if NETSTANDARD1_4
            string typename = type.ToString();
#else
            string typename = $"{type.Namespace}.{type.Name}";
            if (type.IsGenericType) {
                typename += IjwHelper.ToAllEnumStrings(type.GetGenericArguments(), (s) => s.GetTypeName(),",", "[", "]");
            }
#endif
            return typename;
        }

        /// <summary>
        /// 根据属性名获取PropertyInfo
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName">属性名, 大小写敏感</param>
        /// <returns>如果没有找到,  返回null</returns>
        public static PropertyInfo GetPropertyInfo(this Type type, string propertyName) 
#if NETSTANDARD1_4
            => type.GetTypeInfo().GetDeclaredProperty(propertyName);
#else
            => type.GetProperty(propertyName);
#endif

        /// <summary>
        /// 根据方法名获取MethodInfo
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName">方法名, 大小写敏感</param>
        /// <returns>没找到返回null</returns>
        public static MethodInfo GetMethodInfo(this Type type, string methodName)
#if NETSTANDARD1_4
            => type.GetTypeInfo().GetDeclaredMethod(methodName);
#else
            => type.GetMethod(methodName);
#endif

        /// <summary>
        /// 获取缺省值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object? GetDefaultValue(this Type type) {
#if NETSTANDARD1_4
            TypeInfo t = type.GetTypeInfo();
#else
            Type t = type;
#endif
            return t.IsValueType ? Activator.CreateInstance(type) : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsEnumType(this Type type)
#if NETSTANDARD1_4
            => type.GetTypeInfo().IsEnum;
#else
            => type.IsEnum;
#endif
    }
}