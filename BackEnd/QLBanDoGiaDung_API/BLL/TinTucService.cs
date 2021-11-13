using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;

namespace Service.Admin.Service
{
    public class TinTucService : ITinTucService
    {
        private ITinTucRepository _TinTucRepository;
        public TinTucService(ITinTucRepository TinTuc)
        {
            _TinTucRepository = TinTuc;
        }

        public bool Insert(TinTucModel model)
        {

            return _TinTucRepository.Insert(model);
        }




        public bool Update(TinTucModel model)
        {
            return _TinTucRepository.Update(model);
        }


        public bool Delete(string ID)
        {
            return _TinTucRepository.Delete(ID);
        }


        public  List<TinTucModel> GetAll()
        {
            var result = _TinTucRepository.GetAll();
            return result;
        }


       

        public TinTucModel GetById(string ID)
        {
            var result = _TinTucRepository.GetById(ID);
            return result;
        }



    }
}










