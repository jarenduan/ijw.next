﻿using System;
using Xunit;

namespace ijw.Next.Reflection.xTest {
    public class UnitTestObjectExt {
        [Fact]
        public void UnitTestCreateNewInstance() {
            string[] propertyNames = {
                "PropDateTime",  "PropDateTimeNullable",
                "PropInt32",     "PropInt32Nullable",
                "PropInt16",     "PropInt16Nullable",
                "PropInt64",     "PropInt64Nullable",
                "PropDouble",    "PropDoubleNullable",
                "PropSingle",    "PropSingleNullable",
                "PropDecimal",   "PropDecimalNullable",
                "PropChar",      "PropCharNullable",
                "PropByte",      "PropByteNullable",
                "PropBoolean",   "PropBooleanNullable",
                "PropString",
                "PropUInt16",    "PropUInt16Nullable",
                "PropUInt32",    "PropUInt32Nullable",
                "PropUInt64",    "PropUInt64Nullable",
                "PropEnum",     "PropEnumNullable",
                "PropDBNull"
            };
            string[] values = {
                "2016/08/08 16:44:33", "",
                "32",       "32",
                "16",       "",
                "64",       "64",
                "128.0",    "128.0",
                "256.0",    "",
                "123.45",   "123.45",
                "C",        "",
                "65",        "65",
                "False",    "",
                "just a string",
                "16",       "",
                "32",       "32",
                "64",       "",
                "First",    "",
                ""
            };
            TestClass t = ReflectionHelper.CreateNewInstance<TestClass>(propertyNames, values);
            Assert.Equal(new DateTime(2016, 8, 8, 16, 44, 33), t.PropDateTime);
            Assert.Null(t.PropDateTimeNullable);
            Assert.Equal(32, t.PropInt32); Assert.Equal(32, t.PropInt32Nullable);
            Assert.Equal(16, t.PropInt16); Assert.Null(t.PropInt16Nullable);
            Assert.Equal(64, t.PropInt64); Assert.Equal(64, t.PropInt64Nullable);
            Assert.Equal(128.0d, t.PropDouble); Assert.Equal(128.0d, t.PropDoubleNullable);
            Assert.Equal(256.0f, t.PropSingle); Assert.Null(t.PropSingleNullable);
            Assert.Equal(123.45m, t.PropDecimal); Assert.Equal(123.45m, t.PropDecimalNullable);
            Assert.Equal('C', t.PropChar); Assert.Null(t.PropCharNullable);
            Assert.Equal((byte)65, t.PropByte); Assert.Equal((byte)65, t.PropByteNullable);
            Assert.False(t.PropBoolean); Assert.Null(t.PropBooleanNullable);
            Assert.Equal("just a string", t.PropString);
            Assert.Equal(32u, t.PropUInt32); Assert.Equal(32u, t.PropUInt32Nullable);
            Assert.Equal(16u, t.PropUInt16); Assert.Null(t.PropUInt16Nullable);
            Assert.Equal(64u, t.PropUInt64); Assert.Null(t.PropUInt64Nullable);
            Assert.Equal(TestEnum.First, t.PropEnum); Assert.Null(t.PropEnumNullable);
            Assert.Equal(DBNull.Value, t.PropDBNull);
        }

        private class TestClass {
            public DateTime PropDateTime { get; set; }
            public DateTime? PropDateTimeNullable { get; set; }
            public int PropInt32 { get; set; }
            public int? PropInt32Nullable { get; set; }
            public Int16 PropInt16 { get; set; }
            public Int16? PropInt16Nullable { get; set; }
            public Int64 PropInt64 { get; set; }
            public Int64? PropInt64Nullable { get; set; }
            public double? PropDouble { get; set; }
            public double? PropDoubleNullable { get; set; }
            public float PropSingle { get; set; }
            public float? PropSingleNullable { get; set; }
            public decimal PropDecimal { get; set; }
            public decimal? PropDecimalNullable { get; set; }
            public char PropChar { get; set; }
            public char? PropCharNullable { get; set; }
            public byte PropByte { get; set; }
            public byte? PropByteNullable { get; set; }
            public bool PropBoolean { get; set; }
            public bool? PropBooleanNullable { get; set; }
            public string PropString { get; set; } = string.Empty;

            public UInt16 PropUInt16 { get; set; }
            public UInt32 PropUInt32 { get; set; }
            public UInt64 PropUInt64 { get; set; }
            public UInt16? PropUInt16Nullable { get; set; }
            public UInt32? PropUInt32Nullable { get; set; }
            public UInt64? PropUInt64Nullable { get; set; }
            public TestEnum PropEnum { get; set; }
            public TestEnum? PropEnumNullable { get; set; }
            public DBNull PropDBNull { get; set; } = DBNull.Value;
        }

        public enum TestEnum { None = 0, First, Second, Last}
    }
}
