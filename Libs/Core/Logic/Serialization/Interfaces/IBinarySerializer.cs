using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic.Serialization.Interfaces;

public interface IBinarySerializer
{
    public byte[] Serialize<T>(T obj);

    public T? Deserialize<T>(byte[] data);
}
