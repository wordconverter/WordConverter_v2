using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConverter_v2.Interface
{
    interface IService<K, T>
    {
        void setInBo(K inBo);
        T execute();
    }
}
