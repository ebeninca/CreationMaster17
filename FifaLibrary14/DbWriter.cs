// Original code created by Rinaldo

using System;
using System.IO;

namespace FifaLibrary
{
  public class DbWriter : BinaryWriter
  {
    private int m_CurrentByte;
    private int m_CurrentBitPosition;
    private FifaPlatform m_Platform;

    public DbWriter(Stream stream, FifaPlatform platform)
      : base(stream)
    {
      this.m_Platform = platform;
    }

    public FifaPlatform Platform
    {
      get
      {
        return this.m_Platform;
      }
      set
      {
        this.m_Platform = value;
      }
    }

    public override void Write(short value)
    {
      if (this.m_Platform == FifaPlatform.XBox)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse((Array) bytes);
        this.Write(bytes);
      }
      else
        base.Write(value);
    }

    public override void Write(ushort value)
    {
      if (this.m_Platform == FifaPlatform.XBox)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse((Array) bytes);
        this.Write(bytes);
      }
      else
        base.Write(value);
    }

    public override void Write(int value)
    {
      if (this.m_Platform == FifaPlatform.XBox)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse((Array) bytes);
        this.Write(bytes);
      }
      else
        base.Write(value);
    }

    public override void Write(uint value)
    {
      if (this.m_Platform == FifaPlatform.XBox)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse((Array) bytes);
        this.Write(bytes);
      }
      else
        base.Write(value);
    }

    public override void Write(long value)
    {
      if (this.m_Platform == FifaPlatform.XBox)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse((Array) bytes);
        this.Write(bytes);
      }
      else
        base.Write(value);
    }

    public override void Write(ulong value)
    {
      if (this.m_Platform == FifaPlatform.XBox)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse((Array) bytes);
        this.Write(bytes);
      }
      else
        base.Write(value);
    }

    public override void Write(float value)
    {
      if (this.m_Platform == FifaPlatform.XBox)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse((Array) bytes);
        this.Write(bytes);
      }
      else
        base.Write(value);
    }

    public override void Write(double value)
    {
      if (this.m_Platform == FifaPlatform.XBox)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse((Array) bytes);
        this.Write(bytes);
      }
      else
        base.Write(value);
    }

    public void PushInteger(int value, FieldDescriptor fieldDescriptor)
    {
      if (this.m_Platform == FifaPlatform.PC)
        this.PushIntegerPc(value, fieldDescriptor);
      else
        this.PushIntegerXbox(value, fieldDescriptor);
    }

    private void PushIntegerXbox(int value, FieldDescriptor fieldDescriptor)
    {
      BinaryReader binaryReader = new BinaryReader(this.BaseStream);
      int num1 = 0;
      if (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
      {
        num1 = (int) binaryReader.ReadByte();
        --binaryReader.BaseStream.Position;
      }
      int num2 = fieldDescriptor.BitOffset % 8;
      int num3 = value - fieldDescriptor.RangeLow;
      for (int index = fieldDescriptor.Depth - 1; index >= 0; --index)
      {
        int num4 = num3 & 1 << index;
        int num5 = 128 >> num2;
        if (num4 == 0)
          num1 &= ~num5;
        else
          num1 |= num5;
        ++num2;
        if (num2 == 8)
        {
          this.Write((byte) num1);
          num2 = 0;
          num1 = 0;
          if (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
          {
            num1 = (int) binaryReader.ReadByte();
            --binaryReader.BaseStream.Position;
          }
        }
      }
      if (num2 == 0)
        return;
      this.Write((byte) num1);
    }

    private void PushIntegerPc(int value, FieldDescriptor fieldDescriptor)
    {
      int depth = fieldDescriptor.Depth;
      bool flag = false;
      int num1 = value - fieldDescriptor.RangeLow;
      do
      {
        if (this.m_CurrentBitPosition + depth > 8)
        {
          int num2 = 8 - this.m_CurrentBitPosition;
          int num3 = (1 << num2) - 1;
          this.m_CurrentByte += (num1 & num3) << this.m_CurrentBitPosition;
          this.Write((byte) this.m_CurrentByte);
          num1 >>= num2;
          this.m_CurrentByte = 0;
          this.m_CurrentBitPosition = 0;
          depth -= num2;
        }
        else if (this.m_CurrentBitPosition + depth < 8)
        {
          this.m_CurrentByte += num1 << this.m_CurrentBitPosition;
          this.m_CurrentBitPosition += depth;
          flag = true;
        }
        else
        {
          this.m_CurrentByte += num1 << this.m_CurrentBitPosition;
          this.Write((byte) this.m_CurrentByte);
          this.m_CurrentByte = 0;
          this.m_CurrentBitPosition = 0;
          flag = true;
        }
      }
      while (!flag);
    }

    public void WritePendingByte()
    {
      if (this.m_CurrentBitPosition == 0)
        return;
      this.Write((byte) this.m_CurrentByte);
      this.m_CurrentBitPosition = 0;
      this.m_CurrentByte = 0;
    }

    public void Align(long position)
    {
      this.BaseStream.Position = position;
      this.m_CurrentBitPosition = 0;
      this.m_CurrentByte = 0;
    }

    public void AlignToByte()
    {
      if (this.m_CurrentBitPosition == 0)
        return;
      this.Write(this.m_CurrentByte);
    }

    public void AlignTo32Bit()
    {
      if (this.m_CurrentBitPosition != 0)
        this.Write(this.m_CurrentByte);
      int num = (int) (this.BaseStream.Position & 3L);
      if (num == 0)
        return;
      for (; num < 4; ++num)
        this.Write((byte) 0);
    }
  }
}
