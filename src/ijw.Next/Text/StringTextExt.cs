﻿using System.Text;

namespace ijw.Next {
    /// <summary>
    /// 文本编码相关的string类扩展
    /// </summary>
    public static class StringTextExt {
        /// <summary>
        /// 把字符串转换为指定编码的字节数组
        /// </summary>
        /// <param name="aString"></param>
        /// <param name="encoding"></param>
        /// <returns>转换后的字节数组</returns>
        public static byte[] ToBytes(this string aString, Encoding encoding) {
            return encoding.GetBytes(aString);
        }

        /// <summary>
        /// 使用UTF8编码转换成字节数组
        /// </summary>
        /// <param name="aString"></param>
        /// <returns>转换后的字节数组</returns>
        public static byte[] ToBytes(this string aString) {
            return aString.ToBytes(Encoding.Unicode);
        }
    }
}