using MicroB2c.Core.DbModel;
using MicroB2c.Core.IDAL;

namespace MicroB2c.Core.DAL
{
    public class OtherLogInfoDal : DataOperationActivityBase<OtherLogInfo>, IOtherLogInfo
    {
        public static OtherLogInfoDal Current
        {
            get { return new OtherLogInfoDal(); }
        }
    }
}
