
using DAL;
using DAL.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Data.Reponsitory
{
    public class TinTucRepository : ITinTucRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public TinTucRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public bool Insert(TinTucModel model)
        {
            try
            {
                string msg = "";
                var result =  _dbHelper.ExecuteScalarSProcedureWithTransaction(out msg, "TinTuc_create", "@ID", model.ID, "@TieuDe", model.TieuDe, "@HinhAnh", model.HinhAnh, "@NoiDung", model.NoiDung, "@NgayDang", model.NgayDang, "@TrangThai", model.TrangThai);
                if (!string.IsNullOrEmpty(msg))
                {
                    return false;
                    throw new Exception(msg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }











        public bool Update(TinTucModel model)
        {

            try
            {
                string msg = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msg, "TinTuc_update", "@ID", model.ID, "@TieuDe", model.TieuDe, "@HinhAnh", model.HinhAnh, "@NoiDung", model.NoiDung, "@NgayDang", model.NgayDang, "@TrangThai", model.TrangThai
                );
                if (!string.IsNullOrEmpty(msg))
                {
                    return false;
                    throw new Exception(msg);
                }
                return true;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete(string ID)
        {

            try
            {
                string msg = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msg, "TinTuc_delete", "@ID", ID);
                if (!string.IsNullOrEmpty(msg))
                {
                    return false;
                    throw new Exception(msg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<TinTucModel> GetAll()
        {
            try
            {
                string msg = "";
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msg, "TinTuc_get_all");
                if (!string.IsNullOrEmpty(msg))
                {
                   
                    throw new Exception(msg);
                }

                return result.ConvertTo<TinTucModel>().ToList();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public List<TinTucModel>> Search()
        //{
        //    try
        //    {
        //        var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("TinTuc_search", );
        //        if (!string.IsNullOrEmpty(dt.message))
        //        {
        //            throw new Exception(dt.message);
        //        }
        //        var list = await dt.Item2.ConvertToAsync<TinTucModel>();
        //        return list.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}







        public TinTucModel GetById(string ID)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "TinTuc_get_by_id", "@ID", ID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var list =  dt.ConvertTo<TinTucModel>();
                return list.ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {

                if (_dbHelper != null)
                {
                    _dbHelper = null;

                    //GC.Collect();
                }
                disposed = true;
            }

        }
        ~TinTucRepository()
        {
            Dispose(false);

        }
    }
}


















