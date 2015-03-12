using System.ComponentModel;
using MicroB2c.Core.Model;

namespace MicroB2c.Core.DbModel
{
    public class NewsType : BaseTable
    {
        [DisplayName("新闻类型")]
        public virtual string Name { get; set; }
    }
}
