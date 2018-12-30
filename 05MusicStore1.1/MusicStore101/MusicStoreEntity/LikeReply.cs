using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreEntity.UserAndRole;

namespace MusicStoreEntity
{
    /// <summary>
    /// 保存点赞或踩的实体
    /// </summary>
    public class LikeReply
    {
        public Guid ID { get; set; }
        public virtual Reply Reply { get; set; }
        public bool IsNotLiKe { get; set; }
        public virtual Person Person { get; set; }//上级回复
        public DateTime CreateDateTime { get; set; }//回复时间

        //赞
        public int Like { get; set; } = 0;

        //踩
        public int Hate { get; set; } = 0;

        public LikeReply()
        {
            ID = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }
    }
}
