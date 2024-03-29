﻿using System.IO;

namespace ijw.Next {
    /// <summary>
    /// string类与契约相关的扩展方法
    /// </summary>
    public static class StringContractMustExt {

        #region Exist Such File

        /// <summary>
        /// 应该存在这样的文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns>存在指定路径的文件, Contract的IsKept为true. 否则抛出FileNotFoundException异常.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static Contract<string> MustExistSuchFile(this string path) {
            FileInfo fi = new FileInfo(path);
            var brokenMessage = $"File doesn't exist: {fi.FullName}";
            if (!fi.Exists) {
                throw new FileNotFoundException(brokenMessage);
            }
            return new Contract<string>(path, brokenMessage);
        }

        /// <summary>
        /// 应该存在这样的文件
        /// </summary>
        /// <param name="contract"></param>
        /// <returns>存在指定路径的文件, Contract的IsKept为true. 否则抛出FileNotFoundException异常.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static Contract<string> AndMustExistSuchFile(this Contract<string> contract)
            => contract.Value.MustExistSuchFile();

        #endregion

        #region Must a Full Filename

        /// <summary>
        /// 应该是有效的绝对路径名
        /// </summary>
        /// <param name="path"></param>
        /// <returns>是有效的绝对路径名, Contract的IsKept为true.</returns>
        public static Contract<string> MustFullFileName(this string path) {
            var isKept = (path.Length > 3 && path[1] == ':' && path[2] == '\\');
            var brokenMessage = $"{path} is not an absolute path.";
            if (isKept) {
                throw new ContractBrokenException(brokenMessage);
            }
            return new Contract<string>(path, brokenMessage);
        }

        /// <summary>
        /// 应该是有效的绝对路径名
        /// </summary>
        /// <param name="contract"></param>
        /// <returns>是有效的绝对路径名, Contract的IsKept为true.</returns>
        public static Contract<string> AndMustFullFileName(this Contract<string> contract)
             => contract.Value.MustFullFileName();
#endregion
    }
}
