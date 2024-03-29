﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ijw.Next.Grid {
    /// <summary>
    /// 列集合. 无法继承.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ColumnCollection<T> : IndexedViewCollectionBase<T, Column<T>> {
        internal ColumnCollection(Grid<T> grid) : base(grid, grid.ColumnCount) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_grid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Column<T> createIndexedView(Grid<T> _grid, int index) => new Column<T>(_grid, index);
    }
}
