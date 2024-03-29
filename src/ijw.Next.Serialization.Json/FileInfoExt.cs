﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ijw.Next.Serialization.Json {
    /// <summary>
    /// 一系列 FileInfo 的Json反序列化的扩展方法
    /// </summary>
    public static class FileInfoExt {
        /// <summary>
        /// 使用 UTF8 编码反序列化指定类型的对象
        /// </summary>
        /// <typeparam name="T">指定的类型</typeparam>
        /// <param name="fileinfo"></param>
        /// <returns>反序列化出来的对象实例</returns>
        public static T LoadObject<T>(this FileInfo fileinfo) 
            => JsonSerializationHelper.LoadJsonObjectFromFile<T>(fileinfo);

        /// <summary>
        /// 使用指定编码反序列化指定类型的对象
        /// </summary>
        /// <typeparam name="T">指定的类型</typeparam>
        /// <param name="fileinfo"></param>
        /// <param name="encoding">指定的编码</param>
        /// <returns>反序列化出来的对象实例</returns>
        public static T LoadObject<T>(this FileInfo fileinfo, Encoding encoding)
            => JsonSerializationHelper.LoadJsonObjectFromFile<T>(fileinfo, encoding);

        /// <summary>
        /// 使用指定编码反序列化指定类型的对象
        /// </summary>
        /// <param name="fileinfo"></param>
        /// <param name="objectType">指定的类型</param>
        /// <returns>反序列化出来的对象实例</returns>
        public static object LoadObject(this FileInfo fileinfo, Type objectType)
            => JsonSerializationHelper.LoadJsonObjectFromFile(fileinfo, objectType);
    }
}
