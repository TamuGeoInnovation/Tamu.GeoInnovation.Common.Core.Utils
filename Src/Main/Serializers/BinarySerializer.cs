using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace USC.GISResearchLab.Common.Core.Serializers
{
    public class BinarySerializer
    {

        public static byte[] Serialize(object o)
        {
            
            byte[] ret = null;
            try
            {
                if (o != null)
                {
                    if (o.GetType().IsSerializable)
                    {
                        MemoryStream ms = new MemoryStream();
                        BinaryFormatter bf = new BinaryFormatter();

                        bf.Serialize(ms, o);
                        ret = ms.ToArray();
                        ms.Dispose();
                    }
                    else
                    {
                        throw new Exception("BinarySerializer Exception: object is not serializable");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("BinarySerializer.Serialize Exception: " + e.Message, e);
            }
            return ret;
        }


        public static object Deserialize(byte[] b)
        {
            object ret = null;
            try
            {
                if (b != null)
                {

                    MemoryStream ms = new MemoryStream(b);
                    BinaryFormatter bf = new BinaryFormatter();

                    ret = bf.Deserialize(ms);
                    ms.Dispose();
                }
            }
            catch (Exception e)
            {
                throw new Exception("BinarySerializer.Deserialize Exception: " + e.Message, e);
            }
            return ret;
        }
    }
}
