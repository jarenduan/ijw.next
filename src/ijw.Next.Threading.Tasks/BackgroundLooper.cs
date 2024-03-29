﻿using System;
namespace ijw.Next.Threading.Tasks {
    /// <summary>
    /// 封装异步执行循环任务的通用类, 提供启动, 暂停和退出的功能. 
    /// 可以执行指定的循环体, 循环中每次迭代会检查指定的停止条件和暂停条件.
    /// </summary>
    public class BackgroundLooper : BackgroundLooperBase {
        /// <summary>
        /// 循环中每次迭代的循环体, 当Looper的<see cref="BackgroundLooperBase.State"/>不等于<see cref="LooperState.Suspending"/> 并且 <see cref="BackgroundLooperBase.SleepCondition"/>为假时 会被调用.
        /// </summary>
        public Action? LoopAction { get; set; }

        /// <summary>
        /// 循环体
        /// </summary>
        protected override void loopBody() {
            if(this.LoopAction != null) {
                DebugHelper.WriteLine("Loop body started.");
                this.LoopAction();
                DebugHelper.WriteLine("Loop body ended.");
            }
        }
    }
}
