using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore
{
    /// <summary>
    /// 
    /// </summary>
    public class LockedHelp
    {
        public static Mutex _Mutex =
    }
    /// <summary>
    /// 解锁
    /// </summary>
    /// <param name="id">主键</param>
    public static void ThreadUnLocked(Guid id)
    {
        var slim = _Slim[id];
        if(_Count[id] == 1)

    }
}