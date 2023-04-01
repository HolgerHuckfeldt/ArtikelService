using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Mail.Smtp
{
    [DataContract]
    public class SmtpAttachment
    {
        [DataMember]
        private byte[] Data;

        [DataMember]
        public string Name;

        public void AddData( byte[] AttachData)
        {
            Data = AttachData;
            //try
            //{
            //    MemoryStream ms = new MemoryStream();

            //    using (BZip2OutputStream os = new BZip2OutputStream(ms))
            //    {
            //        os.Write(AttachData, 0, AttachData.Length);
            //    }

            //    Data = ms.ToArray();
            //} catch(Exception )
            //{
                
            //}
        }

        public byte[] GetData()
        {
            return Data;
            //try
            //{
            //    MemoryStream ms = new MemoryStream(Data);

            //    using (BZip2InputStream os = new BZip2InputStream(ms))
            //    {
                    
            //        byte[] back = new byte[os.Length];
            //        os.Read(back, 0, back.Length);
            //        return back;
            //    }

            //}
            //catch (Exception )
            //{
            //    return null;
            //}
        }

    }
}
