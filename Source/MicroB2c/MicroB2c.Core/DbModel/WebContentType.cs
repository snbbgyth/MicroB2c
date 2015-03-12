using System.Collections.Generic;
using System.ComponentModel;
using MicroB2c.Core.Model;

namespace MicroB2c.Core.DbModel
{
   public class WebContentType:BaseTable
   {
       [DisplayName("类型名称")]
       public virtual string Name { get; set; }

       public virtual MenuType MenuType { get; set; }

       public virtual int MenuTypeId { get; set; }

       public virtual IEnumerable<MenuType> MenuTypeList { get; set; }

       public WebContentType()
       {
           MenuTypeList = new List<MenuType>();
       }
    }
}
