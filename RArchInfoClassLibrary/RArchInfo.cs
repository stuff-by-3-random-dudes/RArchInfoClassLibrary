using System;

namespace RArchInfoClassLibrary
{ [Serializable]
    public class RArchInfo
    {
        public string CoreName;
        public string FileName;
        public string SupportedExtension;

        public RArchInfo()
        {

        }

        public RArchInfo(string cn, string fn, string se)
        {
            CoreName = cn;
            FileName = fn;
            SupportedExtension = se;
        }
    }
}
