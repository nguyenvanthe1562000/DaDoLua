using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface ITinTucRepository
    {
        bool Insert(TinTucModel model);

        bool Update(TinTucModel model);

        bool Delete(string ID);


        List<TinTucModel> GetAll();






        TinTucModel GetById(string ID);


    }
}





