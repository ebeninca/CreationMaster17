// Original code created by Rinaldo

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FifaLibrary
{
  public class FifaUtil
  {
    private static uint[] c_LanguageHashtable = new uint[256]
    {
      0U,
      1996959894U,
      3993919788U,
      2567524794U,
      124634137U,
      1886057615U,
      3915621685U,
      2657392035U,
      249268274U,
      2044508324U,
      3772115230U,
      2547177864U,
      162941995U,
      2125561021U,
      3887607047U,
      2428444049U,
      498536548U,
      1789927666U,
      4089016648U,
      2227061214U,
      450548861U,
      1843258603U,
      4107580753U,
      2211677639U,
      325883990U,
      1684777152U,
      4251122042U,
      2321926636U,
      335633487U,
      1661365465U,
      4195302755U,
      2366115317U,
      997073096U,
      1281953886U,
      3579855332U,
      2724688242U,
      1006888145U,
      1258607687U,
      3524101629U,
      2768942443U,
      901097722U,
      1119000684U,
      3686517206U,
      2898065728U,
      853044451U,
      1172266101U,
      3705015759U,
      2882616665U,
      651767980U,
      1373503546U,
      3369554304U,
      3218104598U,
      565507253U,
      1454621731U,
      3485111705U,
      3099436303U,
      671266974U,
      1594198024U,
      3322730930U,
      2970347812U,
      795835527U,
      1483230225U,
      3244367275U,
      3060149565U,
      1994146192U,
      31158534U,
      2563907772U,
      4023717930U,
      1907459465U,
      112637215U,
      2680153253U,
      3904427059U,
      2013776290U,
      251722036U,
      2517215374U,
      3775830040U,
      2137656763U,
      141376813U,
      2439277719U,
      3865271297U,
      1802195444U,
      476864866U,
      2238001368U,
      4066508878U,
      1812370925U,
      453092731U,
      2181625025U,
      4111451223U,
      1706088902U,
      314042704U,
      2344532202U,
      4240017532U,
      1658658271U,
      366619977U,
      2362670323U,
      4224994405U,
      1303535960U,
      984961486U,
      2747007092U,
      3569037538U,
      1256170817U,
      1037604311U,
      2765210733U,
      3554079995U,
      1131014506U,
      879679996U,
      2909243462U,
      3663771856U,
      1141124467U,
      855842277U,
      2852801631U,
      3708648649U,
      1342533948U,
      654459306U,
      3188396048U,
      3373015174U,
      1466479909U,
      544179635U,
      3110523913U,
      3462522015U,
      1591671054U,
      702138776U,
      2966460450U,
      3352799412U,
      1504918807U,
      783551873U,
      3082640443U,
      3233442989U,
      3988292384U,
      2596254646U,
      62317068U,
      1957810842U,
      3939845945U,
      2647816111U,
      81470997U,
      1943803523U,
      3814918930U,
      2489596804U,
      225274430U,
      2053790376U,
      3826175755U,
      2466906013U,
      167816743U,
      2097651377U,
      4027552580U,
      2265490386U,
      503444072U,
      1762050814U,
      4150417245U,
      2154129355U,
      426522225U,
      1852507879U,
      4275313526U,
      2312317920U,
      282753626U,
      1742555852U,
      4189708143U,
      2394877945U,
      397917763U,
      1622183637U,
      3604390888U,
      2714866558U,
      953729732U,
      1340076626U,
      3518719985U,
      2797360999U,
      1068828381U,
      1219638859U,
      3624741850U,
      2936675148U,
      906185462U,
      1090812512U,
      3747672003U,
      2825379669U,
      829329135U,
      1181335161U,
      3412177804U,
      3160834842U,
      628085408U,
      1382605366U,
      3423369109U,
      3138078467U,
      570562233U,
      1426400815U,
      3317316542U,
      2998733608U,
      733239954U,
      1555261956U,
      3268935591U,
      3050360625U,
      752459403U,
      1541320221U,
      2607071920U,
      3965973030U,
      1969922972U,
      40735498U,
      2617837225U,
      3943577151U,
      1913087877U,
      83908371U,
      2512341634U,
      3803740692U,
      2075208622U,
      213261112U,
      2463272603U,
      3855990285U,
      2094854071U,
      198958881U,
      2262029012U,
      4057260610U,
      1759359992U,
      534414190U,
      2176718541U,
      4139329115U,
      1873836001U,
      414664567U,
      2282248934U,
      4279200368U,
      1711684554U,
      285281116U,
      2405801727U,
      4167216745U,
      1634467795U,
      376229701U,
      2685067896U,
      3608007406U,
      1308918612U,
      956543938U,
      2808555105U,
      3495958263U,
      1231636301U,
      1047427035U,
      2932959818U,
      3654703836U,
      1088359270U,
      936918000U,
      2847714899U,
      3736837829U,
      1202900863U,
      817233897U,
      3183342108U,
      3401237130U,
      1404277552U,
      615818150U,
      3134207493U,
      3453421203U,
      1423857449U,
      601450431U,
      3009837614U,
      3294710456U,
      1567103746U,
      711928724U,
      3020668471U,
      3272380065U,
      1510334235U,
      755167117U
    };
    private static UTF8Encoding ue = new UTF8Encoding();

    public static short SwapEndian(short x)
    {
      byte num = (byte) ((uint) x & (uint) byte.MaxValue);
      return (short) ((int) (byte) (((int) x & 65280) >> 8) + (int) num * 256);
    }

    public static ushort SwapEndian(ushort x)
    {
      byte num = (byte) ((uint) x & (uint) byte.MaxValue);
      return (ushort) ((uint) (byte) (((int) x & 65280) >> 8) + (uint) num * 256U);
    }

    public static int SwapEndian(int x)
    {
      int num1 = x & (int) byte.MaxValue;
      x >>= 8;
      int num2 = num1 * 256 + (x & (int) byte.MaxValue);
      x >>= 8;
      int num3 = num2 * 256 + (x & (int) byte.MaxValue);
      x >>= 8;
      return num3 * 256 + (x & (int) byte.MaxValue);
    }

    public static uint SwapEndian(uint x)
    {
      uint num1 = x & (uint) byte.MaxValue;
      x >>= 8;
      uint num2 = (uint) ((int) num1 * 256 + ((int) x & (int) byte.MaxValue));
      x >>= 8;
      uint num3 = (uint) ((int) num2 * 256 + ((int) x & (int) byte.MaxValue));
      x >>= 8;
      return (uint) ((int) num3 * 256 + ((int) x & (int) byte.MaxValue));
    }

    public static long SwapEndian(long x)
    {
      long num1 = x & (long) byte.MaxValue;
      x >>= 8;
      long num2 = num1 * 256L + (x & (long) byte.MaxValue);
      x >>= 8;
      long num3 = num2 * 256L + (x & (long) byte.MaxValue);
      x >>= 8;
      long num4 = num3 * 256L + (x & (long) byte.MaxValue);
      x >>= 8;
      long num5 = num4 * 256L + (x & (long) byte.MaxValue);
      x >>= 8;
      long num6 = num5 * 256L + (x & (long) byte.MaxValue);
      x >>= 8;
      long num7 = num6 * 256L + (x & (long) byte.MaxValue);
      x >>= 8;
      return num7 * 256L + (x & (long) byte.MaxValue);
    }

    public static ulong SwapEndian(ulong x)
    {
      ulong num1 = x & (ulong) byte.MaxValue;
      x >>= 8;
      ulong num2 = (ulong) ((long) num1 * 256L + ((long) x & (long) byte.MaxValue));
      x >>= 8;
      ulong num3 = (ulong) ((long) num2 * 256L + ((long) x & (long) byte.MaxValue));
      x >>= 8;
      ulong num4 = (ulong) ((long) num3 * 256L + ((long) x & (long) byte.MaxValue));
      x >>= 8;
      ulong num5 = (ulong) ((long) num4 * 256L + ((long) x & (long) byte.MaxValue));
      x >>= 8;
      ulong num6 = (ulong) ((long) num5 * 256L + ((long) x & (long) byte.MaxValue));
      x >>= 8;
      ulong num7 = (ulong) ((long) num6 * 256L + ((long) x & (long) byte.MaxValue));
      x >>= 8;
      return (ulong) ((long) num7 * 256L + ((long) x & (long) byte.MaxValue));
    }

    public static string ReadNullTerminatedString(BinaryReader r)
    {
      char[] chArray = new char[256];
      int length = 0;
      byte num;
      while ((num = r.ReadByte()) != (byte) 0 && r.PeekChar() != -1)
      {
        chArray[length] = (char) num;
        ++length;
        if (length == 256)
          return (string) null;
      }
      return new string(chArray, 0, length);
    }

    public static string ReadNullTerminatedByteArray(BinaryReader r, int length)
    {
      char[] chArray = new char[length];
      int length1 = 0;
      for (int index = 0; index < length; ++index)
      {
        if (r.PeekChar() == -1)
        {
          length1 = index;
          break;
        }
        byte num;
        if ((num = r.ReadByte()) == (byte) 0 && length1 == 0)
          length1 = index;
        chArray[index] = (char) num;
      }
      return new string(chArray, 0, length1);
    }

    public static string ReadNullTerminatedString(BinaryReader r, int padding)
    {
      string str = FifaUtil.ReadNullTerminatedString(r);
      int num = (str.Length + 1) % padding;
      if (num != 0)
        r.ReadBytes(padding - num);
      return str;
    }

    public static string ReadNullPaddedString(BinaryReader r, int length)
    {
      byte[] bytes = r.ReadBytes(length);
      int count = 0;
      while (count < length && bytes[count] != (byte) 0)
        ++count;
      return count == 0 ? string.Empty : FifaUtil.ue.GetString(bytes, 0, count);
    }

    public static void WriteNullPaddedString(BinaryWriter w, string str, int length)
    {
      if (str == null)
        str = string.Empty;
      byte[] bytes = FifaUtil.ue.GetBytes(str);
      if (bytes.Length > length)
      {
        w.Write(bytes, 0, length);
      }
      else
      {
        w.Write(bytes);
        for (int length1 = bytes.Length; length1 < length; ++length1)
          w.Write((byte) 0);
      }
    }

    public static int ComputeAlignement(int v)
    {
      int num = 1;
      if (v == 0)
        return 1;
      for (int index = 0; index < 31; ++index)
      {
        if ((v & num) != 0)
          return (num + 1) / 2;
        num = num * 2 + 1;
      }
      return 0;
    }

    public static int ComputeAlignementLong(long v)
    {
      int num = 1;
      if (v == 0L)
        return 1;
      for (int index = 0; index < 63; ++index)
      {
        if ((v & (long) num) != 0L)
          return (num + 1) / 2;
        num = num * 2 + 1;
      }
      return 0;
    }

    public static void WriteNullTerminatedString(BinaryWriter w, string s)
    {
      foreach (byte num in s.ToCharArray(0, s.Length))
        w.Write(num);
      w.Write((byte) 0);
    }

    public static void WriteNullTerminatedByteArray(BinaryWriter w, string s, int nBytes)
    {
      char[] charArray = s.ToCharArray(0, s.Length);
      for (int index = 0; index < nBytes; ++index)
      {
        if (index < charArray.Length)
          w.Write((byte) charArray[index]);
        else
          w.Write((byte) 0);
      }
    }

    public static int ComputeHash(string fileName)
    {
      int num = 4700322;
      char[] charArray = fileName.ToCharArray(0, fileName.Length);
      int length = charArray.Length;
      for (int index = 0; index < length; ++index)
        num = (num + (int) charArray[index]) * 33;
      return num;
    }

    public static int ComputeBucket(int hash, string extension)
    {
      extension.ToLower();
      int num;
      if (extension.Equals(".fsh"))
        num = 0;
      else if (extension.Equals(".jdi"))
        num = 32;
      else if (extension.Equals(".ini"))
        num = 32;
      else if (extension.Equals(".tvb"))
        num = 64;
      else if (extension.Equals(".irr"))
        num = 64;
      else if (extension.Equals(".loc"))
        num = 96;
      else if (extension.Equals(".cs"))
        num = 96;
      else if (extension.Equals(".shd"))
        num = 128;
      else if (extension.Equals(".txt"))
        num = 128;
      else if (extension.Equals(".dat"))
        num = 128;
      else if (extension.Equals(".hud"))
        num = 128;
      else if (extension.Equals(".ttf"))
        num = 192;
      else if (extension.Equals(".bin"))
        num = 192;
      else if (extension.Equals(".skn"))
        num = 192;
      else if (extension.Equals(".o"))
        num = 224;
      else if (extension.Equals(".big"))
      {
        num = 224;
      }
      else
      {
        if (!extension.Equals(".ebo"))
          return 0;
        num = 224;
      }
      return (33 * hash + num) % 256 & (int) byte.MaxValue;
    }

    public static ulong ComputeBhHash(byte[] name, int length)
    {
      ulong num1 = 5381;
      for (int index = 0; index < length; ++index)
      {
        int num2 = (int) name[index];
        num1 = (num1 << 5) + num1 + (ulong) (uint) num2;
      }
      return num1;
    }

    public static ulong ComputeBhHash(string name)
    {
      ulong num1 = 5381;
      for (int index = 0; index < name.Length; ++index)
      {
        int num2 = (int) name[index];
        num1 = (num1 << 5) + num1 + (ulong) (uint) num2;
      }
      return num1;
    }

    public static int ComputeCrcDb11(byte[] bytes)
    {
      int num1 = -1;
      for (uint index = 0; (long) index < (long) bytes.Length; ++index)
      {
        int num2 = 7;
        num1 ^= (int) bytes[index] << 24;
        do
        {
          if (num1 >= 0)
            num1 *= 2;
          else
            num1 = num1 * 2 ^ 79764919;
          --num2;
        }
        while (num2 >= 0);
      }
      return num1;
    }

    public static int ComputeCrcDb11(string text)
    {
      return FifaUtil.ComputeCrcDb11(FifaUtil.ue.GetBytes(text));
    }

    public static uint ComputeLanguageHash(string name)
    {
      byte[] bytes = FifaUtil.ue.GetBytes(name);
      return FifaUtil.EAHash(bytes, bytes.Length);
    }

    public static bool TryAllaCrc32(byte[] bytes, uint expected)
    {
      int length = bytes.Length;
      uint num1 = FifaUtil.SwapEndian(expected);
      uint num2 = FifaUtil.sdbm(bytes, length);
      if ((int) num2 == (int) expected || (int) num2 == (int) num1)
        return true;
      uint num3 = FifaUtil.RSHash(bytes, length);
      if ((int) num3 == (int) expected || (int) num3 == (int) num1)
        return true;
      uint num4 = FifaUtil.JSHash(bytes, length);
      if ((int) num4 == (int) expected || (int) num4 == (int) num1)
        return true;
      uint num5 = FifaUtil.PJWHash(bytes, length);
      if ((int) num5 == (int) expected || (int) num5 == (int) num1)
        return true;
      uint num6 = FifaUtil.ELFHash(bytes, length);
      if ((int) num6 == (int) expected || (int) num6 == (int) num1)
        return true;
      uint num7 = FifaUtil.BKDRHash(bytes, length);
      if ((int) num7 == (int) expected || (int) num7 == (int) num1)
        return true;
      uint num8 = FifaUtil.SDBMHash(bytes, length);
      if ((int) num8 == (int) expected || (int) num8 == (int) num1)
        return true;
      uint num9 = FifaUtil.DJBHash(bytes, length);
      if ((int) num9 == (int) expected || (int) num9 == (int) num1)
        return true;
      uint num10 = FifaUtil.DEKHash(bytes, length);
      if ((int) num10 == (int) expected || (int) num10 == (int) num1)
        return true;
      uint num11 = FifaUtil.BPHash(bytes, length);
      if ((int) num11 == (int) expected || (int) num11 == (int) num1)
        return true;
      uint num12 = FifaUtil.FNVHash(bytes, length);
      if ((int) num12 == (int) expected || (int) num12 == (int) num1)
        return true;
      uint num13 = FifaUtil.APHash(bytes, length);
      if ((int) num13 == (int) expected || (int) num13 == (int) num1)
        return true;
      uint num14 = FifaUtil.adler32(bytes, length);
      if ((int) num14 == (int) expected || (int) num14 == (int) num1)
        return true;
      uint num15 = FifaUtil.fletcher32(bytes, length);
      if ((int) num15 == (int) expected || (int) num15 == (int) num1)
        return true;
      uint num16 = FifaUtil.jenkins_one_at_a_time_hash(bytes, length);
      if ((int) num16 == (int) expected || (int) num16 == (int) num1)
        return true;
      uint bhHash = (uint) FifaUtil.ComputeBhHash(bytes, length);
      if ((int) bhHash == (int) expected || (int) bhHash == (int) num1)
        return true;
      uint crcDb11 = (uint) FifaUtil.ComputeCrcDb11(bytes);
      return (int) crcDb11 == (int) expected || (int) crcDb11 == (int) num1;
    }

    private static uint sdbm(byte[] str, int length)
    {
      uint num = 0;
      for (int index = 0; index < length; ++index)
        num = (uint) str[index] + ((num << 6) + (num << 16) - num);
      return num;
    }

    private static uint fletcher32(byte[] str, int len)
    {
      uint num1 = 0;
      uint num2 = 0;
      for (int index = 0; index < len; ++index)
      {
        num1 += (uint) str[index];
        if (num1 >= (uint) ushort.MaxValue)
          num1 -= (uint) ushort.MaxValue;
        num2 += num1;
        if (num2 >= (uint) ushort.MaxValue)
          num2 -= (uint) ushort.MaxValue;
      }
      return num2 << 16 | num1;
    }

    private static uint EAHash(byte[] str, int length)
    {
      uint num1 = 0;
      for (int index = 0; index < length; ++index)
      {
        uint num2 = ((uint) str[index] & 223U ^ num1) & (uint) byte.MaxValue;
        num1 = num1 >> 8 ^ FifaUtil.c_LanguageHashtable[num2];
      }
      return num1 ^ 2147483648U;
    }

    private static uint RSHash(byte[] str, int length)
    {
      uint num1 = 378551;
      uint num2 = 63689;
      uint num3 = 0;
      for (int index = 0; index < length; ++index)
      {
        num3 = num3 * num2 + (uint) str[index];
        num2 *= num1;
      }
      return num3;
    }

    private static uint JSHash(byte[] str, int length)
    {
      uint num = 1315423911;
      for (int index = 0; index < length; ++index)
        num ^= (num << 5) + (uint) str[index] + (num >> 2);
      return num;
    }

    private static uint PJWHash(byte[] str, int length)
    {
      uint num1 = 32;
      uint num2 = num1 * 3U / 4U;
      uint num3 = num1 / 8U;
      uint num4 = (uint) (-1 << (int) num1 - (int) num3);
      uint num5 = 0;
      for (int index = 0; index < length; ++index)
      {
        num5 = (num5 << (int) num3) + (uint) str[index];
        uint num6;
        if ((num6 = num5 & num4) != 0U)
          num5 = (uint) (((int) num5 ^ (int) (num6 >> (int) num2)) & ~(int) num4);
      }
      return num5;
    }

    private static uint ELFHash(byte[] str, int length)
    {
      uint num1 = 0;
      for (int index = 0; index < length; ++index)
      {
        uint num2 = (num1 << 4) + (uint) str[index];
        uint num3;
        if ((num3 = num2 & 4026531840U) != 0U)
          num2 ^= num3 >> 24;
        num1 = num2 & ~num3;
      }
      return num1;
    }

    private static uint BKDRHash(byte[] str, int length)
    {
      uint num1 = 131;
      uint num2 = 0;
      for (int index = 0; index < length; ++index)
        num2 = num2 * num1 + (uint) str[index];
      return num2;
    }

    private static uint SDBMHash(byte[] str, int length)
    {
      uint num = 0;
      for (int index = 0; index < length; ++index)
        num = (uint) ((int) str[index] + ((int) num << 6) + ((int) num << 16)) - num;
      return num;
    }

    private static uint DJBHash(byte[] str, int length)
    {
      uint num = 5381;
      for (int index = 0; index < length; ++index)
        num = (num << 5) + num + (uint) str[index];
      return num;
    }

    private static uint DEKHash(byte[] str, int length)
    {
      uint num = (uint) length;
      for (int index = 0; index < length; ++index)
        num = num << 5 ^ num >> 27 ^ (uint) str[index];
      return num;
    }

    private static uint BPHash(byte[] str, int length)
    {
      uint num = 0;
      for (int index = 0; index < length; ++index)
        num = num << 7 ^ (uint) str[index];
      return num;
    }

    private static uint FNVHash(byte[] str, int length)
    {
      uint num1 = 2166136261;
      for (int index = 0; index < length; ++index)
      {
        byte num2 = str[index];
        if (num2 >= (byte) 65 && num2 <= (byte) 90)
          num2 += (byte) 32;
        num1 = (num1 ^ (uint) num2) * 16777619U;
      }
      return num1;
    }

    private static uint APHash(byte[] str, int length)
    {
      uint num = 2863311530;
      for (int index = 0; index < length; ++index)
        num ^= (index & 1) == 0 ? (uint) ((int) num << 7 ^ (int) str[index] * (int) (num >> 3)) : (uint) ~(((int) num << 11) + ((int) str[index] ^ (int) (num >> 5)));
      return num;
    }

    private static uint adler32(byte[] str, int length)
    {
      ulong num1 = 1;
      ulong num2 = 0;
      for (int index = 0; index < length; ++index)
      {
        num1 = (num1 + (ulong) str[index]) % 65521UL;
        num2 = (num2 + num1) % 65521UL;
      }
      return (uint) (num2 << 16 | num1);
    }

    private static uint jenkins_one_at_a_time_hash(byte[] str, int length)
    {
      uint num1;
      uint num2;
      for (num2 = num1 = 0U; (long) num1 < (long) length; ++num1)
      {
        uint num3 = num2 + (uint) str[num1];
        uint num4 = num3 + (num3 << 10);
        num2 = num4 ^ num4 >> 6;
      }
      uint num5 = num2 + (num2 << 3);
      uint num6 = num5 ^ num5 >> 11;
      return num6 + (num6 << 15);
    }

    private static uint MurmurHash2(byte[] str, int length)
    {
      uint num1 = (uint) length;
      int index = 0;
      for (; length >= 4; length -= 4)
      {
        uint num2 = ((((uint) str[index] * 256U + (uint) str[index + 1]) * 256U + (uint) str[index + 2]) * 256U + (uint) str[index + 3]) * 1540483477U;
        uint num3 = (num2 ^ num2 >> 24) * 1540483477U;
        num1 = num1 * 1540483477U ^ num3;
        index += 4;
      }
      if (length == 3)
        num1 ^= (uint) str[index + 2] << 16;
      if (length >= 2)
        num1 ^= (uint) str[index + 1] << 8;
      uint num4 = (num1 ^ (uint) str[index]) * 1540483477U;
      uint num5 = (num4 ^ num4 >> 13) * 1540483477U;
      return num5 ^ num5 >> 15;
    }

    public static string ReadString(BinaryReader r, int offset)
    {
      long position = r.BaseStream.Position;
      r.BaseStream.Position = (long) offset;
      int count = (int) r.ReadInt16();
      string str = FifaUtil.ue.GetString(r.ReadBytes(count));
      r.BaseStream.Position = position;
      return str;
    }

    public static string ConvertBytesToString(byte[] bytes)
    {
      return FifaUtil.ue.GetString(bytes);
    }

    public static byte[] ConvertStringToBytes(string str)
    {
      return FifaUtil.ue.GetBytes(str);
    }

    public static string ReadString(BinaryReader r, long offset, int length)
    {
      long position = r.BaseStream.Position;
      r.BaseStream.Position = offset;
      string str = FifaUtil.ue.GetString(r.ReadBytes(length));
      r.BaseStream.Position = position;
      return str;
    }

    public static int WriteString(BinaryWriter w, int offset, string s)
    {
      long position1 = w.BaseStream.Position;
      w.BaseStream.Position = (long) offset;
      if (s == null)
        s = " ";
      short byteCount = (short) FifaUtil.ue.GetByteCount(s);
      int num1 = (int) byteCount + 2;
      w.Write(byteCount);
      w.Write(FifaUtil.ue.GetBytes(s));
      if ((num1 & 3) != 0)
      {
        int num2 = 4 - (num1 & 3);
        for (int index = 0; index < num2; ++index)
          w.Write((byte) 0);
      }
      int position2 = (int) w.BaseStream.Position;
      w.BaseStream.Position = position1;
      return position2;
    }

    public static int StringSize(string s)
    {
      return FifaUtil.RoundUp4((int) (short) FifaUtil.ue.GetByteCount(s) + 2);
    }

    public static int ComputeBitUsed(uint range)
    {
      if (range == 0U)
        return 1;
      for (int index = 32; index > 0; --index)
      {
        uint num = (uint) (1 << index - 1);
        if (((int) range & (int) num) != 0)
          return index;
      }
      return 0;
    }

    public static int RoundUp4(int v)
    {
      return v + 3 & -4;
    }

    public static int RoundUp(int v, int align)
    {
      return v + (align - 1) & ~(align - 1);
    }

    public static long RoundUp(long v, int align)
    {
      return v + (long) (align - 1) & (long) ~(align - 1);
    }

    public static bool CompareWildcardString(string pattern, string target)
    {
      int index1 = 0;
      int num = 0;
      pattern = pattern.ToLower();
      target = target.ToLower();
      int index2;
      for (index2 = 0; index2 < target.Length && index1 < pattern.Length; ++index2)
      {
        switch (pattern[index1])
        {
          case '*':
            if (index1 == pattern.Length - 1)
              return true;
            ++index1;
            num = 1;
            break;
          case '/':
          case '\\':
            if (num == 0)
            {
              if ('\\' != target[index2] && '/' != target[index2])
                return false;
              ++index1;
              break;
            }
            if ('\\' == target[index2] || '/' == target[index2])
            {
              num = 0;
              ++index1;
              break;
            }
            break;
          case '?':
            ++index1;
            break;
          default:
            if (num == 0)
            {
              if ((int) pattern[index1] != (int) target[index2])
                return false;
              ++index1;
              break;
            }
            if ((int) pattern[index1] == (int) target[index2])
            {
              num = 0;
              ++index1;
              break;
            }
            break;
        }
      }
      return index2 == target.Length && index1 == pattern.Length;
    }

    public static DateTime ConvertToDate(int gregorian)
    {
      DateTime dateTime = new DateTime(1582, 10, 14, 12, 0, 0);
      return gregorian < 0 ? dateTime : dateTime.AddDays((double) gregorian);
    }

    public static int ConvertFromDate(DateTime date)
    {
      DateTime dateTime = new DateTime(1582, 10, 14, 0, 0, 0);
      return (date - dateTime).Days;
    }

    public static string PadBlanks(string s, int len)
    {
      if (len > s.Length)
      {
        int num = len - s.Length;
        for (int index = 0; index < num; ++index)
          s = " " + s;
      }
      return s;
    }

    public static int Limit(int val, int min, int max)
    {
      if (val < min)
        return min;
      return val > max ? max : val;
    }

    public static float ConvertToFloat(short float16Bit)
    {
      int num1 = ((int) float16Bit & 32768) == 0 ? 1 : -1;
      int num2 = ((int) float16Bit & 31744) >> 10;
      int num3 = ((int) float16Bit & 1023) + 1024;
      if (num2 == 0 && num3 == 0)
        return 0.0f;
      if (num2 == 31)
        return float.NaN;
      float num4 = (float) Math.Pow(2.0, (double) (num2 - 15));
      return (float) (num1 * num3) / 1024f * num4;
    }

    public static ushort ConvertFloat16ToShort(float f)
    {
      if ((double) f == 0.0)
        return 0;
      int num1 = 1;
      if ((double) f < 0.0)
      {
        f = -f;
        num1 = -1;
      }
      float num2 = f * 32768f;
      int num3 = 0;
      while ((double) num2 >= 2.0)
      {
        num2 /= 2f;
        ++num3;
      }
      ushort num4 = 0;
      if (num1 < 0)
        num4 = (ushort) 32768;
      if (num3 > 31)
        num3 = 31;
      return (ushort) ((uint) (ushort) ((uint) num4 | (uint) (num3 << 10)) | ((double) num2 < 1.0 ? 1U : (uint) Convert.ToUInt16(((double) num2 - 1.0) * 1024.0)));
    }

    public static float SwapAndConvertToFloat(BinaryReader r)
    {
      byte[] buffer = new byte[4]
      {
        (byte) 0,
        (byte) 0,
        (byte) 0,
        r.ReadByte()
      };
      buffer[2] = r.ReadByte();
      buffer[1] = r.ReadByte();
      buffer[0] = r.ReadByte();
      MemoryStream memoryStream = new MemoryStream(buffer);
      float num = new BinaryReader((Stream) memoryStream).ReadSingle();
      memoryStream.Close();
      return num;
    }

    public static void SwapAndWriteFloat(BinaryWriter w, float f)
    {
      byte[] buffer = new byte[4];
      MemoryStream memoryStream = new MemoryStream(buffer);
      new BinaryWriter((Stream) memoryStream).Write(f);
      memoryStream.Close();
      w.Write(buffer[3]);
      w.Write(buffer[2]);
      w.Write(buffer[1]);
      w.Write(buffer[0]);
    }

    public static bool IsFileLocked(string filePath)
    {
      try
      {
        using (File.Open(filePath, FileMode.Open))
          ;
      }
      catch (IOException ex)
      {
        int num = Marshal.GetHRForException((Exception) ex) & (int) ushort.MaxValue;
        return num == 32 || num == 33;
      }
      return false;
    }
  }
}
