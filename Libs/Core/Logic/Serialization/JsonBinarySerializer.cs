using Core.Logic.Serialization.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Core.Logic.Serialization;

internal class JsonBinarySerializer : IBinarySerializer
{
    public T? Deserialize<T>(byte[] data)
    {
        var json = Encoding.UTF8.GetString(data);
        var obj = JsonConvert.DeserializeObject<T>(json);
        return obj;
    }

    public byte[] Serialize<T>(T obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        var bytes = Encoding.UTF8.GetBytes(json);
        return bytes;
    }
}
