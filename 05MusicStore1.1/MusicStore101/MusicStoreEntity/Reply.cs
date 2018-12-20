using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreEntity
{
    /// <summary>
    /// 回复
    /// </summary>
    public class Reply
    {
        public Guid ID { get; set; }
        [Display(Name = "标题")]
        [Requirwd]
        public virtual string Title { get; set; }

        [Display(Name = "内容")]
        [Requirwd]
        public virtual string Content { get; set; }

        [Requirwd]
        public virtual Person Person { get; set; }

        [Requirwd]
        public virtual Album Album { get; set; }

       // [Requirwd]
        //public virtual Reply ParentReply { get; set; }//上级回复

        public DateTime CreateDateTime { get; set; }//回复时间

        public Reply()
        {
            ID = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }
    }
}
