using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace RArchInfoClassLibrary
{
    class RAITool
    {
        public static List<RArchInfo> ReadBasesFromVCB(string RAIpath)
        {
            List<RArchInfo> lRet = new List<RArchInfo>();

            FileInfo fn = new FileInfo(RAIpath);
            if (fn.Extension.Contains("rai"))
            {
                FileStream inputConfigStream = new FileStream(RAIpath, FileMode.Open, FileAccess.Read);
                GZipStream decompressedConfigStream = new GZipStream(inputConfigStream, CompressionMode.Decompress);
                IFormatter formatter = new BinaryFormatter();
                lRet = (List<RArchInfo>)formatter.Deserialize(decompressedConfigStream);
            }

            return lRet;
        }
        public static void ExportFile(List<RArchInfo> precomp, string outf)
        {
            CheckAndFixFolder(outf);
            Stream createConfigStream = new FileStream($@"{outf}\cores.rai", FileMode.Create, FileAccess.Write);
            GZipStream compressedStream = new GZipStream(createConfigStream, CompressionMode.Compress);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(compressedStream, precomp);
            compressedStream.Close();
            createConfigStream.Close();
        }
        private static void CheckAndFixFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}
