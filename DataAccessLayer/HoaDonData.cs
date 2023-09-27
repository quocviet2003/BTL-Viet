using DataAccessLayer.Interfaces;
using DataModel;

namespace DataAccessLayer
{
    public class HoaDonData:IHoaDonData
    {
        private IDatabaseHelper _dbHelper;

        public HoaDonData(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<HoaDonModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HD_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
