﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ijw.Next.Collection {
    /// <summary>
    /// 提供了IList接口的一系列扩展方法
    /// </summary>
    public static class IListExt {
        /// <summary>
        /// 对每个索引进行操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="action">进行的操作, 接受索引作为参数</param>
        public static void ForEachIndex<T>(this IList<T> list, Action<int> action) {
            for (int i = 0; i < list.Count; i++) {
                action(i);
            }
        }

        /// <summary>
        /// 在IList集合中查找第一个符合谓词的元素对象的索引
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="predicate">谓词, 为真则立即返回索引</param>
        /// <returns>返回第一个符合谓词的元素的索引, 如果没有符合的将会返回-1</returns>
        /// <remarks>
        /// 方法从前向后遍历列表, 因此时间复杂度是O(index), 即如果目标元素是第一个, 则只需要一次迭代.
        /// 此方法适用于预期元素处于列表中排位靠前的情况. 如果预期元素在较后的位置, 应该使用LastIndexOf&lt;T&gt;扩展方法.
        /// </remarks>
        public static int IndexOf<T>(this IList<T> collection, Predicate<T> predicate) {
            for (int i = 0; i < collection.Count; i++) {
                if (predicate(collection[i])) {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 在IList集合中查找最后一个符合谓词的元素对象的索引
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="predicate">谓词, 为真则立即返回索引</param>
        /// <returns>返回最后一个符合谓词的元素的索引, 如果没有符合的将会返回-1</returns>
        /// <remarks>
        /// 方法从后向前遍历列表, 因此时间复杂度是O(count-index), 即如果目标元素是最后一个, 则只需要一次迭代.
        /// 此方法适用于预期元素处于列表中排位靠后的情况. 如果预期元素在较前的位置, 应该使用<see cref="IndexOf{T}(IList{T}, Predicate{T})"/>扩展方法.
        /// </remarks>
        public static int LastIndexOf<T>(this IList<T> collection, Predicate<T> predicate) {
            for (int i = collection.Count - 1; i >= 0; i--) {
                if (predicate(collection[i])) {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 根据枚举策略查找第一个符合指定条件的元素的索引
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="collection">列表</param>
        /// <param name="predicate">条件, 为真则返回</param>
        /// <param name="strategies">查找策略, 从后向前或者从前向后.</param>
        /// <returns>返回符合谓词的元素的索引, 如果没有符合的将会返回-1</returns>
        /// <remarks>
        /// 内部实际上调用了IndexOf和LastIndexOf.
        /// 如果预期元素在较前的位置, 应该使用<see cref="FetchingStrategies.FirstFirst"/>, 反之是<see cref="FetchingStrategies.LastFirst"/>.
        /// </remarks>
        public static int IndexOf<T>(this IList<T> collection, Predicate<T> predicate, FetchingStrategies strategies) {
            int index = -1;
            switch (strategies) {
                case FetchingStrategies.FirstFirst:
                    index = collection.IndexOf(predicate); //O(index)
                    break;
                case FetchingStrategies.LastFirst:
                    index = collection.LastIndexOf(predicate); //O(count - index)
                    break;
                default:
                    break;
            }
            return index;
        }

        /// <summary>
        /// 从指定位置开始移除当前及其之后的所有元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="index">指定的索引处</param>
        /// <returns>移除的数目</returns>
        public static int RemoveRange<T>(this IList<T> collection, int index) {
            index.ShouldNotLargerThan(collection.Count - 1);
            int removeCount = collection.Count - index;

            for (int i = 0; i < removeCount; i++) {
                collection.RemoveAt(index);
            }

            return removeCount;
        }
    }
}
