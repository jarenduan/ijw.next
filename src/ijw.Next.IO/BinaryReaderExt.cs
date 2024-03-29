﻿using System.IO;
using System.Collections.Generic;

namespace ijw.Next.IO {

    /// <summary>
    /// BinaryReader的扩展方法
    /// </summary>
    public static class BinaryReaderExt {
        /// <summary>
        /// 读取指定长度的二进制数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="length">字节数</param>
        /// <returns>读取到的二进制数据数组</returns>
        public static byte[] ReadBytes(this BinaryReader reader, long length) {
            byte[] result = new byte[length];
            long pos = 0;
            while (pos < length) {
                result[pos] = reader.ReadByte();
                pos++;
            }
            return result;
        }

        /// <summary>
        /// 读取全部的二进制数据
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<byte> ReadBytes(this BinaryReader reader) {
            List<byte> result = new List<byte>();
            byte[] buffer = reader.ReadBytes(256);
            while (buffer.Length > 0) {
                result.AddRange(buffer);
                buffer = reader.ReadBytes(256);// read next 256 bytes
            }
            return result;
        }
    }
}