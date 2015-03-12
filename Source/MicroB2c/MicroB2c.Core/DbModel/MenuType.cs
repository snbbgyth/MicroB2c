using System.ComponentModel;
using MicroB2c.Core.Model;

namespace MicroB2c.Core.DbModel
{
   public class MenuType:BaseTable
    {
       [DisplayName("菜单名称")]
       public virtual string Name { get; set; }
    }
}
