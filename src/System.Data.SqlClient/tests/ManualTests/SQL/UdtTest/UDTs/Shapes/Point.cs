// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using System.Data.SqlTypes;
using System.Text;

using Microsoft.SqlServer.Server;

namespace Microsoft.Samples.SqlServer
{
    [Serializable]
    [SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true, MaxByteSize = 9)]
    public class Point : INullable, IBinarySerialize
    {
        private int x;
        private int y;
        private bool fIsNull;

        public static Point Null { get { return new Point(true); } }
        public const int MaxByteSize = 9;
        public const bool IsFixedLength = true;
        public const bool IsByteOrdered = false;

        public void Read(BinaryReader r)
        {
            x = r.ReadInt32();
            y = r.ReadInt32();
            fIsNull = BitConverter.ToBoolean(r.ReadBytes(1), 0);
        }

        public void Write(BinaryWriter w)
        {
            w.Write(x);
            w.Write(y);
            w.Write(fIsNull);
        }

        public Point()
        {
            x = 0;
            y = 0;
            fIsNull = false;
        }

        public Point(bool fNull)
        {
            fIsNull = true;
        }

        public Point(int ix, int iy)
        {
            x = ix;
            y = iy;
            fIsNull = false;
        }

        public bool IsNull
        {
            get
            {
                return fIsNull;
            }
        }

        public void FillFromBytesInternal(byte[] data)
        {
            if (data.Length != 9)
                throw new ArgumentException("Data Length not as expected.", nameof(data));

            x = BitConverter.ToInt32(data, 0);
            y = BitConverter.ToInt32(data, 4);
        }

        public void FillFromBytes(SqlBytes value)
        {
            if (value.IsNull)
            {
                fIsNull = true;
                return;
            }

            byte[] bytes = value.Value;
            FillFromBytesInternal(bytes);

            fIsNull = false;
            return;
        }

        public void FillBytes(SqlBytes value)
        {
            if (fIsNull)
            {
                if (value.IsNull)
                    return;
                else
                {
                    value.SetNull();
                    return;
                }
            }

            byte[] bigbytes = new byte[9];
            byte[] bytes = BitConverter.GetBytes(x);
            bytes.CopyTo(bigbytes, 0);
            bytes = BitConverter.GetBytes(y);
            bytes.CopyTo(bigbytes, 4);

            int i;
            for (i = 0; i < bigbytes.Length; i++)
                value[i] = bigbytes[i];
            value.SetLength(i);

            return;
        }

        public static Point Parse(SqlString data)
        {
            string[] array = data.Value.Split(new char[] { ',' });
            int x;
            int y;

            if (array.Length != 2)
                throw new ArgumentException("Data length not as expected", nameof(data));
            x = int.Parse(array[0]);
            y = int.Parse(array[1]);

            return new Point(x, y);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(x);
            builder.Append(',');
            builder.Append(y);

            return builder.ToString();
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public double Distance()
        {
            return DistanceFromXY(0, 0);
        }

        public double DistanceFrom(Point pFrom)
        {
            return DistanceFromXY(pFrom.x, pFrom.y);
        }

        public double DistanceFromXY(int ix, int iy)
        {
            return Math.Sqrt(Math.Pow(ix - x, 2.0) + Math.Pow(iy - y, 2.0));
        }

        public const int MaxByteSizeValue = 12;
    }
}
