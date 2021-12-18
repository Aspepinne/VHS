using HiQ.NetStandard.Util.Data;

namespace VHSApi.Web.Repository
{
    public abstract class ADbRepositoryBase
    {

        private readonly SqlDbAccess _sqlDbAccess;

        protected ADbRepositoryBase()
        {
            _sqlDbAccess = new SqlDbAccess("Server=************;Initial Catalog=VHS;UID=sa;Password=********;");
        }

        protected SqlDbAccess DbAccess
        {
            get { return _sqlDbAccess; }
        }
    }
}
