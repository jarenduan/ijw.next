﻿using System;
using System.Collections.Generic;
using static System.Math;
using System.Linq;

namespace ijw.Next {
    /// <summary>
    /// 提供对Integer类型的若干扩展方法
    /// </summary>
    public static class IntegerNumberExt {
        #region Number sequence

        /// <summary>
        /// 返回由当前数字开始直到指定数字所组成的递增整数数组
        /// </summary>
        /// <param name="number">当前的数字</param>
        /// <param name="toNumber">结束的数字</param>
        /// <returns></returns>
        public static IEnumerable<int> To(this int number, int toNumber) {
            if (toNumber < number) {
                throw new ArgumentOutOfRangeException("toNumber should be not less.");
            }

            int count = toNumber - number + 1;

            for (int i = 0; i < count; i++) {
                yield return number + i;
            }
        }

        /// <summary>
        /// 返回由当前数字及指定数目的后续整数一起所组成的递增整数数组. 例如: 11.ToNext(5) 将返回 [11, 12, 13, 14, 15, 16].
        /// </summary>
        /// <param name="number"></param>
        /// <param name="howManyNext"></param>
        /// <returns></returns>
        public static IEnumerable<int> ToNext(this int number, int howManyNext) {
            return number.To(number + howManyNext);
        }

        /// <summary>
        /// 返回从当前数字开始的指定长度的递增整数数组. 例如: 11.ToNext(5) 将返回 [11, 12, 13, 14, 15].
        /// </summary>
        /// <param name="number"></param>
        /// <param name="totalLength"></param>
        /// <returns></returns>
        public static IEnumerable<int> ToTotal(this int number, int totalLength) {
            return number.To(number + totalLength - 1);
        }

        #endregion

        #region Pow

        /// <summary>
        /// 幂计算
        /// </summary>
        /// <param name="number"></param>
        /// <param name="power">幂</param>
        /// <returns></returns>
        public static int Pow(this int number, int power) => (int)Math.Pow(number, power);

        /// <summary>
        /// 幂计算
        /// </summary>
        /// <param name="number"></param>
        /// <param name="power">幂</param>
        /// <returns></returns>
        public static int Pow(this int number, float power) => (int)Math.Pow(number, power);

        /// <summary>
        /// 幂计算
        /// </summary>
        /// <param name="number"></param>
        /// <param name="power">幂</param>
        /// <returns></returns>
        public static int Pow(this int number, double power) => (int)Math.Pow(number, power);

        #endregion

        #region Times
        /// <summary>
        /// 反复运行委托一定次数
        /// </summary>
        /// <param name="times"></param>
        /// <param name="loopBody"></param>
        public static void Times(this int times, Action loopBody) {
            for (int i = 0; i < times; i++) {
                loopBody();
            }
        }

        /// <summary>
        /// 反复运行委托一定次数
        /// </summary>
        /// <param name="times"></param>
        /// <param name="loopBody"></param>
        public static void Times(this int times, Action<int> loopBody) {
            for (int i = 0; i < times; i++) {
                loopBody(i);
            }
        }

        /// <summary>
        /// 字符串重复指定次数
        /// </summary>
        /// <param name="times"></param>
        /// <param name="aString">欲重复的字符串</param>
        /// <returns>重复之后的新字符串</returns>
        public static string Times(this int times, string aString) {
            if (times <= 0) {
                throw new ArgumentOutOfRangeException();
            }
            return aString.Repeat(times);
        }
        #endregion

        #region Odd or Even
        /// <summary>
        /// 判断是否是奇数
        /// </summary>
        /// <param name="number"></param>
        /// <returns>奇数返回true，反之返回false</returns>
        public static bool IsOdd(this int number) {
            return !number.IsEven();
        }

        /// <summary>
        /// 判断是否是偶数
        /// </summary>
        /// <param name="number"></param>
        /// <returns>偶数返回true，反之返回false</returns>
        public static bool IsEven(this int number) {
            return number % 2 == 0;
        }
        #endregion

        #region ToString
        /// <summary>
        /// 将整数变成序数字符串, 比如 1.ToOrdinalString() 生成字符串: "1st".
        /// </summary>
        /// <param name="number"></param>
        /// <param name="lastNumber">指定最后一个数字, 对于此数字将返回"last"</param>
        /// <returns>序数字符串</returns>
        public static string ToOrdinalString(this int number, int lastNumber = -1) {
            if (number == lastNumber) {
                return "last";
            }
            else {
                return number.ToString().AppendOrdinalPostfix();
            }
        }

        /// <summary>
        /// 将整数变成序数字符串, 比如 1.ToOrdinalString() 生成字符串: "1st".
        /// </summary>
        /// <param name="number"></param>
        /// <param name="lastNumber">指定最后一个数字, 对于此数字将返回"last"</param>
        /// <returns>序数字符串</returns>
        public static string ToOrdinalString(this long number, long lastNumber = -1L) {
            if (number == lastNumber) {
                return "last";
            }
            else {
                return number.ToString().AppendOrdinalPostfix();
            }
        }

        #endregion

        #region Limiting Diff

        /// <summary>
        /// 限制波动过滤. 用前一个值+波动幅度代替. 
        /// </summary>
        /// <param name="curr">欲过滤的值</param>
        /// <param name="prev">前一个值</param>
        /// <param name="diff">波动幅度限制</param>
        /// <return>过滤后的新值</return>
        public static long LimitingDiff(this long curr, long prev, long diff) {
            long r;
            if ((curr - prev) > diff) {
                r = prev + diff;
            }
            else if ((prev - curr) > diff) {
                r = prev - diff;
            }
            else {
                r = curr;
            }
            return r;
        }

        /// <summary>
        /// 限制波动过滤. 用前一个值+波动幅度代替. 
        /// </summary>
        /// <param name="curr">欲过滤的值</param>
        /// <param name="prev">前一个值</param>
        /// <param name="diff">波动幅度限制</param>
        /// <return>过滤后的新值</return>
        public static int LimitingDiff(this int curr, int prev, int diff) {
            int r;
            if ((curr - prev) > diff) {
                r = prev + diff;
            }
            else if ((prev - curr) > diff) {
                r = prev - diff;
            }
            else {
                r = curr;
            }
            return r;
        }

        #endregion

        #region LimitingAmplify

        /// <summary>
        /// 限幅过滤. 放弃掉波动过大的数值, 用前一个数值代替.  
        /// </summary>
        /// <param name="curr">欲过滤的值</param>
        /// <param name="prev">前一个值</param>
        /// <param name="diff">波动最大值绝对值</param>
        /// <return>过滤后的新值</return>
        public static long LimitingAmplify(this long curr, long prev, long diff) {
            long r;
            if (Abs(curr - prev) > diff) {
                r = prev;
            }
            else {
                r = curr;
            }
            return r;
        }

        /// <summary>
        /// 限幅过滤. 放弃掉波动过大的数值, 用前一个数值代替.  
        /// </summary>
        /// <param name="curr">欲过滤的值</param>
        /// <param name="prev">前一个值</param>
        /// <param name="diff">波动最大值绝对值</param>
        /// <return>过滤后的新值</return>
        public static int LimitingAmplify(this int curr, int prev, int diff) {
            int r;
            if (Abs(curr - prev) > diff) {
                r = prev;
            }
            else {
                r = curr;
            }
            return r;
        }

        #endregion
    }
}