using System.Text;

namespace CarEdit_server.Extentions
{
    public static partial class StreamExtentions
    {
        public static string StreamToString(this Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static byte[] ReadFully(this Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static byte[] ReadAllBytes(this Stream instream)
        {
            if (instream is MemoryStream)
            {
                return ((MemoryStream)instream).ToArray();
            }

            using var memoryStream = new MemoryStream();
            instream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
