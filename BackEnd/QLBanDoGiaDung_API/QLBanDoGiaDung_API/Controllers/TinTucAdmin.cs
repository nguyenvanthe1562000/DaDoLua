using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Newtonsoft.Json;
using Service.Admin.Service.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVT.Controllers.Admin
{
    [Route("api/[controller]")]

    [ApiController]
    public class TinTucController : ControllerBase
    {
        private readonly ITinTucService _TinTucService;

        public TinTucController(ITinTucService TinTuc)
        {
            _TinTucService = TinTuc;
        }
        [HttpPost]
        [Route("insert")]

        public IActionResult Insert([FromBody] TinTucModel model)
        {
            try
            {
                var response =  _TinTucService.Insert(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - TinTucApi," + ex.InnerException.InnerException.Message + "");
            }
        }






        [HttpPut]
        [Route("Update")]
       
        public IActionResult Update([FromBody] TinTucModel model)
        {
            try
            {
                var responseData =  _TinTucService.Update(model);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Update - TinTucApi," + ex.InnerException.InnerException.Message + "");
            }
        }





        [HttpDelete]
        [Route("delete/{ID}")]
        public IActionResult Delete([FromRoute] string ID)
        {
            try
            {
                var response =  _TinTucService.Delete(ID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Delete- TinTucApi," + ex.InnerException.InnerException.Message + "");

            }
        }







        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var response =  _TinTucService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - TinTucApi," + ex.InnerException.InnerException.Message + "");
            }
        }



        [HttpGet]
        [Route("get-home")]
        public IActionResult GetHome()
        {
            try
            {
                var response =  _TinTucService.GetAll().Take(5).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - TinTucApi," + ex.InnerException.InnerException.Message + "");
            }
        }
        /// <summary> </summary>
        /// <returns> </returns>

       



        




        [HttpGet]
        [Route("GetById/{ID}")]
     
        public IActionResult GetById([FromRoute] string ID)
        {
            try
            {
                var responseData =  _TinTucService.GetById(ID);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - TinTucApi," + ex.InnerException.InnerException.Message + "");
            }
        }




    }
}











