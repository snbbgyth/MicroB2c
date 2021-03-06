﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using MicroB2c.Core.Model;

namespace MicroB2c.Core.DbModel
{
   public  class News:BaseTable
    {
       [DisplayName("标题")]
       public virtual string Title { get; set; }

       [DisplayName("标题图片")]
       public virtual string ImageForTitle { get; set; }

       [AllowHtml]
       [DisplayName("正文")]
       public virtual string Content { get; set; }

       [DisplayName("是否发布")]
       public virtual bool IsPublish { get; set; }
 
       public  virtual NewsType NewsType { get; set; }

       public virtual int NewsTypeId { get; set; }

       public virtual IEnumerable<NewsType> NewsTypeList { get; set; }

       public News()
       {
         NewsType=new NewsType();
       }
    }
}
