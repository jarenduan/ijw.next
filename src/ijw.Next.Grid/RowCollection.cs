﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ijw.Next.Grid {
    /// <summary>
    /// 行集合. 无法继承.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class RowCollection<T> : IndexedViewCollectionBase<T, Row<T>> {
        internal RowCollection(Grid<T> grid): base(grid, grid.RowCount) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_grid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Row<T> createIndexedView(Grid<T> _grid, int index) => new Row<T>(_grid, index);
    }
}