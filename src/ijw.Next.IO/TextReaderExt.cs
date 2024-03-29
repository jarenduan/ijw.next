﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ijw.Next.IO {
    /// <summary>
    /// 文本/字符流的扩展方法
    /// </summary>
    public static class TextReaderExt {
        /// <summary>
        /// 扩展方法, 读取流中的一行
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>行集合</returns>
        public static IEnumerable<string> ReadLines(this TextReader reader) {
            if (reader is null) {
                throw new ArgumentNullException(nameof(reader));
            }

            string line = reader.ReadLine();
            while (null != line) {
                yield return line;
                line = reader.ReadLine();
            }
        }

        /// <summary>
        /// 读取每一行的行号与内容
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IEnumerable<(string line, int lineNum)> ReadLinesWithLineNumber(this TextReader reader) {
            if (reader is null) {
                throw new ArgumentNullException(nameof(reader));
            }

            string line = reader.ReadLine();
            int num = 0;
            while (null != line) {
                num++;
                yield return (line, num);
                line = reader.ReadLine();
            }
        }
    }
}
