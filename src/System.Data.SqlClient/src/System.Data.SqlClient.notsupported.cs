// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#pragma warning disable CA2215,CS0114

namespace Microsoft.SqlServer.Server
{
    public enum DataAccessKind
    {
        None = 0,
        Read = 1,
    }
    public enum Format
    {
        Unknown = 0,
        Native = 1,
        UserDefined = 2,
    }
    public partial interface IBinarySerialize
    {
        void Read(System.IO.BinaryReader r);
        void Write(System.IO.BinaryWriter w);
    }
    public sealed partial class InvalidUdtException : System.SystemException
    {
        internal InvalidUdtException() { }
    }
    public partial class SqlDataRecord : System.Data.IDataRecord
    {
        public SqlDataRecord(params Microsoft.SqlServer.Server.SqlMetaData[] metaData) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual int FieldCount { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public virtual object this[int ordinal] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public virtual object this[string name] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public virtual bool GetBoolean(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual byte GetByte(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferOffset, int length) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual char GetChar(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual long GetChars(int ordinal, long fieldOffset, char[] buffer, int bufferOffset, int length) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual string GetDataTypeName(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.DateTime GetDateTime(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.DateTimeOffset GetDateTimeOffset(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual decimal GetDecimal(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual double GetDouble(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Type GetFieldType(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual float GetFloat(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Guid GetGuid(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual short GetInt16(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual int GetInt32(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual long GetInt64(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual string GetName(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual int GetOrdinal(string name) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlBinary GetSqlBinary(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlBoolean GetSqlBoolean(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlByte GetSqlByte(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlBytes GetSqlBytes(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlChars GetSqlChars(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlDateTime GetSqlDateTime(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlDecimal GetSqlDecimal(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlDouble GetSqlDouble(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Type GetSqlFieldType(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlGuid GetSqlGuid(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlInt16 GetSqlInt16(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlInt32 GetSqlInt32(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlInt64 GetSqlInt64(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual Microsoft.SqlServer.Server.SqlMetaData GetSqlMetaData(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlMoney GetSqlMoney(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlSingle GetSqlSingle(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlString GetSqlString(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual object GetSqlValue(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual int GetSqlValues(object[] values) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlXml GetSqlXml(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual string GetString(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.TimeSpan GetTimeSpan(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual object GetValue(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual int GetValues(object[] values) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual bool IsDBNull(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetBoolean(int ordinal, bool value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetByte(int ordinal, byte value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferOffset, int length) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetChar(int ordinal, char value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetChars(int ordinal, long fieldOffset, char[] buffer, int bufferOffset, int length) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetDateTime(int ordinal, System.DateTime value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetDateTimeOffset(int ordinal, System.DateTimeOffset value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetDBNull(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetDecimal(int ordinal, decimal value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetDouble(int ordinal, double value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetFloat(int ordinal, float value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetGuid(int ordinal, System.Guid value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetInt16(int ordinal, short value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetInt32(int ordinal, int value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetInt64(int ordinal, long value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlBinary(int ordinal, System.Data.SqlTypes.SqlBinary value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlBoolean(int ordinal, System.Data.SqlTypes.SqlBoolean value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlByte(int ordinal, System.Data.SqlTypes.SqlByte value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlBytes(int ordinal, System.Data.SqlTypes.SqlBytes value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlChars(int ordinal, System.Data.SqlTypes.SqlChars value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlDateTime(int ordinal, System.Data.SqlTypes.SqlDateTime value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlDecimal(int ordinal, System.Data.SqlTypes.SqlDecimal value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlDouble(int ordinal, System.Data.SqlTypes.SqlDouble value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlGuid(int ordinal, System.Data.SqlTypes.SqlGuid value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlInt16(int ordinal, System.Data.SqlTypes.SqlInt16 value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlInt32(int ordinal, System.Data.SqlTypes.SqlInt32 value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlInt64(int ordinal, System.Data.SqlTypes.SqlInt64 value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlMoney(int ordinal, System.Data.SqlTypes.SqlMoney value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlSingle(int ordinal, System.Data.SqlTypes.SqlSingle value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlString(int ordinal, System.Data.SqlTypes.SqlString value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetSqlXml(int ordinal, System.Data.SqlTypes.SqlXml value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetString(int ordinal, string value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetTimeSpan(int ordinal, System.TimeSpan value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual void SetValue(int ordinal, object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual int SetValues(params object[] values) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        System.Data.IDataReader System.Data.IDataRecord.GetData(int ordinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
#if NET
    [System.AttributeUsageAttribute(System.AttributeTargets.Field | System.AttributeTargets.Parameter | System.AttributeTargets.Property | System.AttributeTargets.ReturnValue, AllowMultiple=false, Inherited=false)]
    public partial class SqlFacetAttribute : System.Attribute
    {
        public SqlFacetAttribute() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public bool IsFixedLength { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsNullable { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int MaxSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int Precision { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int Scale { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
#endif
    [System.AttributeUsageAttribute(System.AttributeTargets.Method, AllowMultiple=false, Inherited=false)]
    public partial class SqlFunctionAttribute : System.Attribute
    {
        public SqlFunctionAttribute() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public Microsoft.SqlServer.Server.DataAccessKind DataAccess { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string FillRowMethodName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsDeterministic { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsPrecise { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Name { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public Microsoft.SqlServer.Server.SystemDataAccessKind SystemDataAccess { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string TableDefinition { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    public sealed partial class SqlMetaData
    {
        public SqlMetaData(string name, System.Data.SqlDbType dbType) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, bool useServerDefault, bool isUniqueKey, System.Data.SqlClient.SortOrder columnSortOrder, int sortOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, byte precision, byte scale) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, byte precision, byte scale, bool useServerDefault, bool isUniqueKey, System.Data.SqlClient.SortOrder columnSortOrder, int sortOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, long maxLength) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, long maxLength, bool useServerDefault, bool isUniqueKey, System.Data.SqlClient.SortOrder columnSortOrder, int sortOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, long maxLength, byte precision, byte scale, long locale, System.Data.SqlTypes.SqlCompareOptions compareOptions, System.Type userDefinedType) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, long maxLength, byte precision, byte scale, long localeId, System.Data.SqlTypes.SqlCompareOptions compareOptions, System.Type userDefinedType, bool useServerDefault, bool isUniqueKey, System.Data.SqlClient.SortOrder columnSortOrder, int sortOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, long maxLength, long locale, System.Data.SqlTypes.SqlCompareOptions compareOptions) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, long maxLength, long locale, System.Data.SqlTypes.SqlCompareOptions compareOptions, bool useServerDefault, bool isUniqueKey, System.Data.SqlClient.SortOrder columnSortOrder, int sortOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, string database, string owningSchema, string objectName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, string database, string owningSchema, string objectName, bool useServerDefault, bool isUniqueKey, System.Data.SqlClient.SortOrder columnSortOrder, int sortOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, System.Type userDefinedType) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, System.Type userDefinedType, string serverTypeName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlMetaData(string name, System.Data.SqlDbType dbType, System.Type userDefinedType, string serverTypeName, bool useServerDefault, bool isUniqueKey, System.Data.SqlClient.SortOrder columnSortOrder, int sortOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlCompareOptions CompareOptions { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.DbType DbType { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsUniqueKey { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public long LocaleId { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public static long Max { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public long MaxLength { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Name { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public byte Precision { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public byte Scale { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SortOrder SortOrder { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int SortOrdinal { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlDbType SqlDbType { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Type Type { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string TypeName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool UseServerDefault { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string XmlSchemaCollectionDatabase { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string XmlSchemaCollectionName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string XmlSchemaCollectionOwningSchema { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool Adjust(bool value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public byte Adjust(byte value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public byte[] Adjust(byte[] value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public char Adjust(char value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public char[] Adjust(char[] value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlBinary Adjust(System.Data.SqlTypes.SqlBinary value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlBoolean Adjust(System.Data.SqlTypes.SqlBoolean value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlByte Adjust(System.Data.SqlTypes.SqlByte value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlBytes Adjust(System.Data.SqlTypes.SqlBytes value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlChars Adjust(System.Data.SqlTypes.SqlChars value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlDateTime Adjust(System.Data.SqlTypes.SqlDateTime value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlDecimal Adjust(System.Data.SqlTypes.SqlDecimal value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlDouble Adjust(System.Data.SqlTypes.SqlDouble value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlGuid Adjust(System.Data.SqlTypes.SqlGuid value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlInt16 Adjust(System.Data.SqlTypes.SqlInt16 value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlInt32 Adjust(System.Data.SqlTypes.SqlInt32 value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlInt64 Adjust(System.Data.SqlTypes.SqlInt64 value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlMoney Adjust(System.Data.SqlTypes.SqlMoney value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlSingle Adjust(System.Data.SqlTypes.SqlSingle value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlString Adjust(System.Data.SqlTypes.SqlString value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlXml Adjust(System.Data.SqlTypes.SqlXml value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.DateTime Adjust(System.DateTime value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.DateTimeOffset Adjust(System.DateTimeOffset value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public decimal Adjust(decimal value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public double Adjust(double value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Guid Adjust(System.Guid value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public short Adjust(short value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public int Adjust(int value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public long Adjust(long value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public object Adjust(object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public float Adjust(float value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public string Adjust(string value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.TimeSpan Adjust(System.TimeSpan value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static Microsoft.SqlServer.Server.SqlMetaData InferFromValue(object value, string name) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Method, AllowMultiple=false, Inherited=false)]
    public sealed partial class SqlMethodAttribute : Microsoft.SqlServer.Server.SqlFunctionAttribute
    {
        public SqlMethodAttribute() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public bool InvokeIfReceiverIsNull { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsMutator { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool OnNullCall { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.Struct, AllowMultiple=false, Inherited=false)]
    public sealed partial class SqlUserDefinedAggregateAttribute : System.Attribute
    {
        public const int MaxByteSizeValue = 8000;
        public SqlUserDefinedAggregateAttribute(Microsoft.SqlServer.Server.Format format) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public Microsoft.SqlServer.Server.Format Format { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsInvariantToDuplicates { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsInvariantToNulls { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsInvariantToOrder { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsNullIfEmpty { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int MaxByteSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Name { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.Struct, AllowMultiple=false, Inherited=true)]
    public sealed partial class SqlUserDefinedTypeAttribute : System.Attribute
    {
        public SqlUserDefinedTypeAttribute(Microsoft.SqlServer.Server.Format format) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public Microsoft.SqlServer.Server.Format Format { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsByteOrdered { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IsFixedLength { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int MaxByteSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Name { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string ValidationMethodName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    public enum SystemDataAccessKind
    {
        None = 0,
        Read = 1,
    }
}
namespace System.Data
{
    public sealed partial class OperationAbortedException : System.SystemException
    {
        internal OperationAbortedException() { }
    }
}
namespace System.Data.Sql
{
    public sealed partial class SqlNotificationRequest
    {
        public SqlNotificationRequest() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlNotificationRequest(string userData, string options, int timeout) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public string Options { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int Timeout { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string UserData { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
}
namespace System.Data.SqlClient
{
    public enum ApplicationIntent
    {
        ReadWrite = 0,
        ReadOnly = 1,
    }
    public delegate void OnChangeEventHandler(object sender, System.Data.SqlClient.SqlNotificationEventArgs e);
#if NET
    public enum PoolBlockingPeriod
    {
        Auto = 0,
        AlwaysBlock = 1,
        NeverBlock = 2,
    }
#endif
    public enum SortOrder
    {
        Unspecified = -1,
        Ascending = 0,
        Descending = 1,
    }
    public sealed partial class SqlBulkCopy : System.IDisposable
    {
        public SqlBulkCopy(System.Data.SqlClient.SqlConnection connection) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlBulkCopy(System.Data.SqlClient.SqlConnection connection, System.Data.SqlClient.SqlBulkCopyOptions copyOptions, System.Data.SqlClient.SqlTransaction externalTransaction) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlBulkCopy(string connectionString) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlBulkCopy(string connectionString, System.Data.SqlClient.SqlBulkCopyOptions copyOptions) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public int BatchSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int BulkCopyTimeout { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SqlBulkCopyColumnMappingCollection ColumnMappings { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string DestinationTableName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool EnableStreaming { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int NotifyAfter { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public event System.Data.SqlClient.SqlRowsCopiedEventHandler SqlRowsCopied { add { } remove { } }
        public void Close() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        void System.IDisposable.Dispose() { }
        public void WriteToServer(System.Data.Common.DbDataReader reader) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void WriteToServer(System.Data.DataRow[] rows) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void WriteToServer(System.Data.DataTable table) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void WriteToServer(System.Data.DataTable table, System.Data.DataRowState rowState) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void WriteToServer(System.Data.IDataReader reader) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.Common.DbDataReader reader) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.DataRow[] rows) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.DataRow[] rows, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.DataTable table) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.DataTable table, System.Data.DataRowState rowState) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.DataTable table, System.Data.DataRowState rowState, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.DataTable table, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.IDataReader reader) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task WriteToServerAsync(System.Data.IDataReader reader, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlBulkCopyColumnMapping
    {
        public SqlBulkCopyColumnMapping() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlBulkCopyColumnMapping(int sourceColumnOrdinal, int destinationOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlBulkCopyColumnMapping(int sourceColumnOrdinal, string destinationColumn) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlBulkCopyColumnMapping(string sourceColumn, int destinationOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlBulkCopyColumnMapping(string sourceColumn, string destinationColumn) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public string DestinationColumn { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int DestinationOrdinal { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string SourceColumn { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int SourceOrdinal { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    public sealed partial class SqlBulkCopyColumnMappingCollection : System.Collections.CollectionBase
    {
        internal SqlBulkCopyColumnMappingCollection() { }
        public System.Data.SqlClient.SqlBulkCopyColumnMapping this[int index] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SqlBulkCopyColumnMapping Add(System.Data.SqlClient.SqlBulkCopyColumnMapping bulkCopyColumnMapping) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlBulkCopyColumnMapping Add(int sourceColumnIndex, int destinationColumnIndex) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlBulkCopyColumnMapping Add(int sourceColumnIndex, string destinationColumn) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlBulkCopyColumnMapping Add(string sourceColumn, int destinationColumnIndex) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlBulkCopyColumnMapping Add(string sourceColumn, string destinationColumn) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new void Clear() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public bool Contains(System.Data.SqlClient.SqlBulkCopyColumnMapping value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void CopyTo(System.Data.SqlClient.SqlBulkCopyColumnMapping[] array, int index) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public int IndexOf(System.Data.SqlClient.SqlBulkCopyColumnMapping value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void Insert(int index, System.Data.SqlClient.SqlBulkCopyColumnMapping value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void Remove(System.Data.SqlClient.SqlBulkCopyColumnMapping value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new void RemoveAt(int index) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    [System.FlagsAttribute]
    public enum SqlBulkCopyOptions
    {
        Default = 0,
        KeepIdentity = 1,
        CheckConstraints = 2,
        TableLock = 4,
        KeepNulls = 8,
        FireTriggers = 16,
        UseInternalTransaction = 32,
    }
    public sealed partial class SqlClientFactory : System.Data.Common.DbProviderFactory
    {
        internal SqlClientFactory() { }
        public static readonly System.Data.SqlClient.SqlClientFactory Instance;
        public override System.Data.Common.DbCommand CreateCommand() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.Common.DbCommandBuilder CreateCommandBuilder() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.Common.DbConnection CreateConnection() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.Common.DbConnectionStringBuilder CreateConnectionStringBuilder() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.Common.DbDataAdapter CreateDataAdapter() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.Common.DbParameter CreateParameter() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public static partial class SqlClientMetaDataCollectionNames
    {
        public static readonly string Columns;
        public static readonly string Databases;
        public static readonly string ForeignKeys;
        public static readonly string IndexColumns;
        public static readonly string Indexes;
        public static readonly string Parameters;
        public static readonly string ProcedureColumns;
        public static readonly string Procedures;
        public static readonly string Tables;
        public static readonly string UserDefinedTypes;
        public static readonly string Users;
        public static readonly string ViewColumns;
        public static readonly string Views;
    }
    public sealed partial class SqlCommand : System.Data.Common.DbCommand, System.ICloneable
    {
        public SqlCommand() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlCommand(string cmdText) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlCommand(string cmdText, System.Data.SqlClient.SqlConnection connection) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlCommand(string cmdText, System.Data.SqlClient.SqlConnection connection, System.Data.SqlClient.SqlTransaction transaction) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override string CommandText { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override int CommandTimeout { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Data.CommandType CommandType { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlConnection Connection { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        protected override System.Data.Common.DbConnection DbConnection { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        protected override System.Data.Common.DbParameterCollection DbParameterCollection { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        protected override System.Data.Common.DbTransaction DbTransaction { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool DesignTimeVisible { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.Sql.SqlNotificationRequest Notification { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlParameterCollection Parameters { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlTransaction Transaction { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Data.UpdateRowSource UpdatedRowSource { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public event System.Data.StatementCompletedEventHandler StatementCompleted { add { } remove { } }
        public System.IAsyncResult BeginExecuteNonQuery() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.IAsyncResult BeginExecuteNonQuery(System.AsyncCallback callback, object stateObject) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.IAsyncResult BeginExecuteReader() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.IAsyncResult BeginExecuteReader(System.AsyncCallback callback, object stateObject) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.IAsyncResult BeginExecuteReader(System.AsyncCallback callback, object stateObject, System.Data.CommandBehavior behavior) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.IAsyncResult BeginExecuteReader(System.Data.CommandBehavior behavior) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.IAsyncResult BeginExecuteXmlReader() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.IAsyncResult BeginExecuteXmlReader(System.AsyncCallback callback, object stateObject) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void Cancel() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlCommand Clone() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Data.Common.DbParameter CreateDbParameter() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlParameter CreateParameter() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override void Dispose(bool disposing) { }
        public int EndExecuteNonQuery(System.IAsyncResult asyncResult) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlDataReader EndExecuteReader(System.IAsyncResult asyncResult) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Xml.XmlReader EndExecuteXmlReader(System.IAsyncResult asyncResult) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Data.Common.DbDataReader ExecuteDbDataReader(System.Data.CommandBehavior behavior) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Threading.Tasks.Task<System.Data.Common.DbDataReader> ExecuteDbDataReaderAsync(System.Data.CommandBehavior behavior, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int ExecuteNonQuery() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Threading.Tasks.Task<int> ExecuteNonQueryAsync(System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlDataReader ExecuteReader() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlDataReader ExecuteReader(System.Data.CommandBehavior behavior) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Threading.Tasks.Task<System.Data.SqlClient.SqlDataReader> ExecuteReaderAsync() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Threading.Tasks.Task<System.Data.SqlClient.SqlDataReader> ExecuteReaderAsync(System.Data.CommandBehavior behavior) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Threading.Tasks.Task<System.Data.SqlClient.SqlDataReader> ExecuteReaderAsync(System.Data.CommandBehavior behavior, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Threading.Tasks.Task<System.Data.SqlClient.SqlDataReader> ExecuteReaderAsync(System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override object ExecuteScalar() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Threading.Tasks.Task<object> ExecuteScalarAsync(System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Xml.XmlReader ExecuteXmlReader() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task<System.Xml.XmlReader> ExecuteXmlReaderAsync() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Threading.Tasks.Task<System.Xml.XmlReader> ExecuteXmlReaderAsync(System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void Prepare() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void ResetCommandTimeout() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        object System.ICloneable.Clone() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlCommandBuilder : System.Data.Common.DbCommandBuilder
    {
        public SqlCommandBuilder() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlCommandBuilder(System.Data.SqlClient.SqlDataAdapter adapter) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.Common.CatalogLocation CatalogLocation { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string CatalogSeparator { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlDataAdapter DataAdapter { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string QuotePrefix { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string QuoteSuffix { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string SchemaSeparator { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        protected override void ApplyParameterInfo(System.Data.Common.DbParameter parameter, System.Data.DataRow datarow, System.Data.StatementType statementType, bool whereClause) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static void DeriveParameters(System.Data.SqlClient.SqlCommand command) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand GetDeleteCommand() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand GetDeleteCommand(bool useColumnsForParameterNames) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand GetInsertCommand() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand GetInsertCommand(bool useColumnsForParameterNames) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override string GetParameterName(int parameterOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override string GetParameterName(string parameterName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override string GetParameterPlaceholder(int parameterOrdinal) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Data.DataTable GetSchemaTable(System.Data.Common.DbCommand srcCommand) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand GetUpdateCommand() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand GetUpdateCommand(bool useColumnsForParameterNames) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Data.Common.DbCommand InitializeCommand(System.Data.Common.DbCommand command) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override string QuoteIdentifier(string unquotedIdentifier) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override void SetRowUpdatingHandler(System.Data.Common.DbDataAdapter adapter) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override string UnquoteIdentifier(string quotedIdentifier) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlConnection : System.Data.Common.DbConnection, System.ICloneable
    {
        public SqlConnection() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlConnection(string connectionString) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlConnection(string connectionString, System.Data.SqlClient.SqlCredential credential) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public string AccessToken { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Guid ClientConnectionId { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string ConnectionString { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override int ConnectionTimeout { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SqlCredential Credential { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string Database { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string DataSource { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool FireInfoMessageEventOnUserErrors { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int PacketSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string ServerVersion { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Data.ConnectionState State { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool StatisticsEnabled { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string WorkstationId { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public event System.Data.SqlClient.SqlInfoMessageEventHandler InfoMessage { add { } remove { } }
        protected override System.Data.Common.DbTransaction BeginDbTransaction(System.Data.IsolationLevel isolationLevel) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlTransaction BeginTransaction() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlTransaction BeginTransaction(System.Data.IsolationLevel iso) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlTransaction BeginTransaction(System.Data.IsolationLevel iso, string transactionName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlTransaction BeginTransaction(string transactionName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void ChangeDatabase(string database) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static void ChangePassword(string connectionString, System.Data.SqlClient.SqlCredential credential, System.Security.SecureString newPassword) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static void ChangePassword(string connectionString, string newPassword) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static void ClearAllPools() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static void ClearPool(System.Data.SqlClient.SqlConnection connection) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void Close() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand CreateCommand() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Data.Common.DbCommand CreateDbCommand() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override void Dispose(bool disposing) { }
        public override System.Data.DataTable GetSchema() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.DataTable GetSchema(string collectionName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.DataTable GetSchema(string collectionName, string[] restrictionValues) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void Open() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Threading.Tasks.Task OpenAsync(System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void ResetStatistics() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Collections.IDictionary RetrieveStatistics() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        object System.ICloneable.Clone() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlConnectionStringBuilder : System.Data.Common.DbConnectionStringBuilder
    {
        public SqlConnectionStringBuilder() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlConnectionStringBuilder(string connectionString) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.ApplicationIntent ApplicationIntent { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string ApplicationName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string AttachDBFilename { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int ConnectRetryCount { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int ConnectRetryInterval { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int ConnectTimeout { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string CurrentLanguage { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string DataSource { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool Encrypt { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool Enlist { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string FailoverPartner { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string InitialCatalog { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool IntegratedSecurity { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override object this[string keyword] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Collections.ICollection Keys { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int LoadBalanceTimeout { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int MaxPoolSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int MinPoolSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool MultipleActiveResultSets { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool MultiSubnetFailover { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int PacketSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Password { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool PersistSecurityInfo { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
#if NET
        public System.Data.SqlClient.PoolBlockingPeriod PoolBlockingPeriod { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
#endif
        public bool Pooling { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool Replication { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string TransactionBinding { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool TrustServerCertificate { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string TypeSystemVersion { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string UserID { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public bool UserInstance { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Collections.ICollection Values { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string WorkstationID { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override void Clear() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool ContainsKey(string keyword) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool Remove(string keyword) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool ShouldSerialize(string keyword) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool TryGetValue(string keyword, out object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlCredential
    {
        public SqlCredential(string userId, System.Security.SecureString password) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Security.SecureString Password { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string UserId { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    public sealed partial class SqlDataAdapter : System.Data.Common.DbDataAdapter, System.Data.IDataAdapter, System.Data.IDbDataAdapter, System.ICloneable
    {
        public SqlDataAdapter() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlDataAdapter(System.Data.SqlClient.SqlCommand selectCommand) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlDataAdapter(string selectCommandText, System.Data.SqlClient.SqlConnection selectConnection) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlDataAdapter(string selectCommandText, string selectConnectionString) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand DeleteCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlCommand InsertCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlCommand SelectCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        System.Data.IDbCommand System.Data.IDbDataAdapter.DeleteCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        System.Data.IDbCommand System.Data.IDbDataAdapter.InsertCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        System.Data.IDbCommand System.Data.IDbDataAdapter.SelectCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        System.Data.IDbCommand System.Data.IDbDataAdapter.UpdateCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override int UpdateBatchSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlCommand UpdateCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public event System.Data.SqlClient.SqlRowUpdatedEventHandler RowUpdated { add { } remove { } }
        public event System.Data.SqlClient.SqlRowUpdatingEventHandler RowUpdating { add { } remove { } }
        protected override void OnRowUpdated(System.Data.Common.RowUpdatedEventArgs value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override void OnRowUpdating(System.Data.Common.RowUpdatingEventArgs value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        object System.ICloneable.Clone() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public partial class SqlDataReader : System.Data.Common.DbDataReader
#if NET
, System.Data.Common.IDbColumnSchemaGenerator
#endif
, System.IDisposable
    {
        internal SqlDataReader() { }
        protected System.Data.SqlClient.SqlConnection Connection { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override int Depth { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override int FieldCount { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool HasRows { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool IsClosed { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override object this[int i] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override object this[string name] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override int RecordsAffected { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override int VisibleFieldCount { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool GetBoolean(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override byte GetByte(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override long GetBytes(int i, long dataIndex, byte[] buffer, int bufferIndex, int length) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override char GetChar(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override long GetChars(int i, long dataIndex, char[] buffer, int bufferIndex, int length) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
#if NET
        public System.Collections.ObjectModel.ReadOnlyCollection<System.Data.Common.DbColumn> GetColumnSchema() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
#endif
        public override string GetDataTypeName(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.DateTime GetDateTime(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.DateTimeOffset GetDateTimeOffset(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override decimal GetDecimal(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override double GetDouble(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Collections.IEnumerator GetEnumerator() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Type GetFieldType(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Threading.Tasks.Task<T> GetFieldValueAsync<T>(int i, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override T GetFieldValue<T>(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override float GetFloat(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Guid GetGuid(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override short GetInt16(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int GetInt32(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override long GetInt64(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override string GetName(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int GetOrdinal(string name) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Type GetProviderSpecificFieldType(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override object GetProviderSpecificValue(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int GetProviderSpecificValues(object[] values) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Data.DataTable GetSchemaTable() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlBinary GetSqlBinary(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlBoolean GetSqlBoolean(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlByte GetSqlByte(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlBytes GetSqlBytes(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlChars GetSqlChars(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlDateTime GetSqlDateTime(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlDecimal GetSqlDecimal(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlDouble GetSqlDouble(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlGuid GetSqlGuid(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlInt16 GetSqlInt16(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlInt32 GetSqlInt32(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlInt64 GetSqlInt64(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlMoney GetSqlMoney(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlSingle GetSqlSingle(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlString GetSqlString(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual object GetSqlValue(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual int GetSqlValues(object[] values) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Data.SqlTypes.SqlXml GetSqlXml(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.IO.Stream GetStream(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override string GetString(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.IO.TextReader GetTextReader(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.TimeSpan GetTimeSpan(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override object GetValue(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int GetValues(object[] values) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public virtual System.Xml.XmlReader GetXmlReader(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected internal bool IsCommandBehavior(System.Data.CommandBehavior condition) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool IsDBNull(int i) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Threading.Tasks.Task<bool> IsDBNullAsync(int i, System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool NextResult() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Threading.Tasks.Task<bool> NextResultAsync(System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool Read() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Threading.Tasks.Task<bool> ReadAsync(System.Threading.CancellationToken cancellationToken) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlDependency
    {
        public SqlDependency() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlDependency(System.Data.SqlClient.SqlCommand command) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlDependency(System.Data.SqlClient.SqlCommand command, string options, int timeout) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public bool HasChanges { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Id { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public event System.Data.SqlClient.OnChangeEventHandler OnChange { add { } remove { } }
        public void AddCommandDependency(System.Data.SqlClient.SqlCommand command) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static bool Start(string connectionString) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static bool Start(string connectionString, string queue) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static bool Stop(string connectionString) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public static bool Stop(string connectionString, string queue) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlError
    {
        internal SqlError() { }
        public byte Class { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int LineNumber { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Message { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int Number { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Procedure { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Server { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Source { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public byte State { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string ToString() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlErrorCollection : System.Collections.ICollection, System.Collections.IEnumerable
    {
        internal SqlErrorCollection() { }
        public int Count { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SqlError this[int index] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        bool System.Collections.ICollection.IsSynchronized { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        object System.Collections.ICollection.SyncRoot { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public void CopyTo(System.Array array, int index) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void CopyTo(System.Data.SqlClient.SqlError[] array, int index) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Collections.IEnumerator GetEnumerator() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlException : System.Data.Common.DbException
    {
        internal SqlException() { }
        public byte Class { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Guid ClientConnectionId { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SqlErrorCollection Errors { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int LineNumber { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int Number { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Procedure { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Server { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string Source { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public byte State { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo si, System.Runtime.Serialization.StreamingContext context) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override string ToString() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlInfoMessageEventArgs : System.EventArgs
    {
        internal SqlInfoMessageEventArgs() { }
        public System.Data.SqlClient.SqlErrorCollection Errors { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Message { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Source { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string ToString() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public delegate void SqlInfoMessageEventHandler(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e);
    public partial class SqlNotificationEventArgs : System.EventArgs
    {
        public SqlNotificationEventArgs(System.Data.SqlClient.SqlNotificationType type, System.Data.SqlClient.SqlNotificationInfo info, System.Data.SqlClient.SqlNotificationSource source) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlNotificationInfo Info { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SqlNotificationSource Source { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SqlNotificationType Type { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    public enum SqlNotificationInfo
    {
        AlreadyChanged = -2,
        Unknown = -1,
        Truncate = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
        Drop = 4,
        Alter = 5,
        Restart = 6,
        Error = 7,
        Query = 8,
        Invalid = 9,
        Options = 10,
        Isolation = 11,
        Expired = 12,
        Resource = 13,
        PreviousFire = 14,
        TemplateLimit = 15,
        Merge = 16,
    }
    public enum SqlNotificationSource
    {
        Client = -2,
        Unknown = -1,
        Data = 0,
        Timeout = 1,
        Object = 2,
        Database = 3,
        System = 4,
        Statement = 5,
        Environment = 6,
        Execution = 7,
        Owner = 8,
    }
    public enum SqlNotificationType
    {
        Unknown = -1,
        Change = 0,
        Subscribe = 1,
    }
    public sealed partial class SqlParameter : System.Data.Common.DbParameter, System.ICloneable
    {
        public SqlParameter() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlParameter(string parameterName, System.Data.SqlDbType dbType) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlParameter(string parameterName, System.Data.SqlDbType dbType, int size) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlParameter(string parameterName, System.Data.SqlDbType dbType, int size, System.Data.ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, System.Data.DataRowVersion sourceVersion, object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlParameter(string parameterName, System.Data.SqlDbType dbType, int size, System.Data.ParameterDirection direction, byte precision, byte scale, string sourceColumn, System.Data.DataRowVersion sourceVersion, bool sourceColumnNullMapping, object value, string xmlSchemaCollectionDatabase, string xmlSchemaCollectionOwningSchema, string xmlSchemaCollectionName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlParameter(string parameterName, System.Data.SqlDbType dbType, int size, string sourceColumn) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlParameter(string parameterName, object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlTypes.SqlCompareOptions CompareInfo { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Data.DbType DbType { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Data.ParameterDirection Direction { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool IsNullable { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int LocaleId { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public int Offset { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string ParameterName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new byte Precision { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new byte Scale { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override int Size { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override string SourceColumn { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool SourceColumnNullMapping { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Data.DataRowVersion SourceVersion { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlDbType SqlDbType { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public object SqlValue { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string TypeName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string UdtTypeName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override object Value { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string XmlSchemaCollectionDatabase { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string XmlSchemaCollectionName { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string XmlSchemaCollectionOwningSchema { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override void ResetDbType() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void ResetSqlDbType() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        object System.ICloneable.Clone() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override string ToString() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public sealed partial class SqlParameterCollection : System.Data.Common.DbParameterCollection
    {
        internal SqlParameterCollection() { }
        public override int Count { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool IsFixedSize { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool IsReadOnly { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlParameter this[int index] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlParameter this[string parameterName] { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override object SyncRoot { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public System.Data.SqlClient.SqlParameter Add(System.Data.SqlClient.SqlParameter value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int Add(object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlParameter Add(string parameterName, System.Data.SqlDbType sqlDbType) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlParameter Add(string parameterName, System.Data.SqlDbType sqlDbType, int size) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlParameter Add(string parameterName, System.Data.SqlDbType sqlDbType, int size, string sourceColumn) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void AddRange(System.Array values) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void AddRange(System.Data.SqlClient.SqlParameter[] values) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public System.Data.SqlClient.SqlParameter AddWithValue(string parameterName, object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void Clear() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public bool Contains(System.Data.SqlClient.SqlParameter value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool Contains(object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool Contains(string value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void CopyTo(System.Array array, int index) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void CopyTo(System.Data.SqlClient.SqlParameter[] array, int index) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override System.Collections.IEnumerator GetEnumerator() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Data.Common.DbParameter GetParameter(int index) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Data.Common.DbParameter GetParameter(string parameterName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public int IndexOf(System.Data.SqlClient.SqlParameter value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int IndexOf(object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int IndexOf(string parameterName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void Insert(int index, System.Data.SqlClient.SqlParameter value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void Insert(int index, object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void Remove(System.Data.SqlClient.SqlParameter value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void Remove(object value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void RemoveAt(int index) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void RemoveAt(string parameterName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override void SetParameter(int index, System.Data.Common.DbParameter value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override void SetParameter(string parameterName, System.Data.Common.DbParameter value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
    public partial class SqlRowsCopiedEventArgs : System.EventArgs
    {
        public SqlRowsCopiedEventArgs(long rowsCopied) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public bool Abort { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public long RowsCopied { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    public delegate void SqlRowsCopiedEventHandler(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e);
    public sealed partial class SqlRowUpdatedEventArgs : System.Data.Common.RowUpdatedEventArgs
    {
        public SqlRowUpdatedEventArgs(System.Data.DataRow row, System.Data.IDbCommand command, System.Data.StatementType statementType, System.Data.Common.DataTableMapping tableMapping) : base (default(System.Data.DataRow), default(System.Data.IDbCommand), default(System.Data.StatementType), default(System.Data.Common.DataTableMapping)) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public new System.Data.SqlClient.SqlCommand Command { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    public delegate void SqlRowUpdatedEventHandler(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e);
    public sealed partial class SqlRowUpdatingEventArgs : System.Data.Common.RowUpdatingEventArgs
    {
        public SqlRowUpdatingEventArgs(System.Data.DataRow row, System.Data.IDbCommand command, System.Data.StatementType statementType, System.Data.Common.DataTableMapping tableMapping) : base (default(System.Data.DataRow), default(System.Data.IDbCommand), default(System.Data.StatementType), default(System.Data.Common.DataTableMapping)) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override System.Data.IDbCommand BaseCommand { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public new System.Data.SqlClient.SqlCommand Command { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
    }
    public delegate void SqlRowUpdatingEventHandler(object sender, System.Data.SqlClient.SqlRowUpdatingEventArgs e);
    public sealed partial class SqlTransaction : System.Data.Common.DbTransaction
    {
        internal SqlTransaction() { }
        public new System.Data.SqlClient.SqlConnection Connection { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        protected override System.Data.Common.DbConnection DbConnection { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override System.Data.IsolationLevel IsolationLevel { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override void Commit() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        protected override void Dispose(bool disposing) { }
        public override void Rollback() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void Rollback(string transactionName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public void Save(string savePointName) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
}
#if NET
namespace System.Data.SqlTypes
{
    public sealed partial class SqlFileStream : System.IO.Stream
    {
        public SqlFileStream(string path, byte[] transactionContext, System.IO.FileAccess access) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public SqlFileStream(string path, byte[] transactionContext, System.IO.FileAccess access, System.IO.FileOptions options, long allocationSize) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override bool CanRead { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool CanSeek { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override bool CanWrite { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override long Length { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public string Name { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override long Position { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } set { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public byte[] TransactionContext { get { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); } }
        public override void Flush() { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override int Read(byte[] buffer, int offset, int count) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override long Seek(long offset, System.IO.SeekOrigin origin) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void SetLength(long value) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
        public override void Write(byte[] buffer, int offset, int count) { throw new System.PlatformNotSupportedException(System.SR.PlatformNotSupported_DataSqlClient); }
    }
}
#endif
