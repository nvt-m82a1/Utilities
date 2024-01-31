﻿using Utilities.Container.Base;
using Utilities.Container.Option;

namespace Utilities.Container.Converter
{
    /// <summary>
    /// Đọc và gán dữ liệu vào đối tượng (reference)
    /// </summary>
    public class DataBinding
    {
        public static DataBinding Instance = new DataBinding();
        protected DataBinding() { }

        /// <summary>
        /// Đọc thuộc tính trong item
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="item">Đối tượng</param>
        /// <param name="forceClass">Lấy danh sách members trực tiếp nếu là class</param>
        public byte[]? ReadMembers<T>(T item, bool forceClass = false) where T : class
        {
            if (item == null) return null;

            var container = new DataContainer();
            var dataTypes = TypesPool.Scan(item.GetType(), forceClass);
            foreach (var type in dataTypes)
                type.BindingContainer(item, container, TypeConvert.Instance);

            return container.Export().ToArray();
        }

        /// <summary>
        /// Ghi vào item những thuộc tính trong data
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="item">Đối tượng</param>
        /// <param name="data">Dữ liệu</param>
        /// <param name="forceClass">Lấy danh sách members trực tiếp nếu là class</param>
        public void WriteMembers<T>(T item, byte[]? data, bool forceClass = false) where T : class
        {
            if (data == null) return;

            var container = new DataContainer();
            container.Import(data);

            var dataTypes = TypesPool.Scan<T>(forceClass);
            foreach (var type in dataTypes)
                type.BindingItem(item, container, TypeConvert.Instance);
        }
    }
}
