using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3.Core.Services
{
    public interface ISoungsManagerService
    {
        List<DataMusic> getPlayList { get; }
    }
}
