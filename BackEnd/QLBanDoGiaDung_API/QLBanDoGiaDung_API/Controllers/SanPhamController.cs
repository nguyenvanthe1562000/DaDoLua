using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;
using QLBanDoGiaDung_API.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace QLBanDoGiaDung_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBussiness _spBusiness;
        //private readonly IPhotoService photoService;
        private string _path;
        private string _userContentFolder;

        public SanPhamController(ISanPhamBussiness newBusiness, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _spBusiness = newBusiness;
            //this.photoService = photoService;
            _path = configuration["AppSettings:PATH"];
             _userContentFolder ="";
        }

        //public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        //{
        //    if (dataFromBase64String.Contains("base64,"))
        //    {
        //        dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
        //    }
        //    return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        //}
        //public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        //{
        //    try
        //    {
        //        string result = "";
        //        string serverRootPathFolder = _path;
        //        string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
        //        string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
        //        if (!Directory.Exists(fullPathFolder))
        //            Directory.CreateDirectory(fullPathFolder);
        //        System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //[Route("upload")]
        //[HttpPost, DisableRequestSizeLimit]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    try
        //    {
        //        if (file.Length > 0)
        //        {
        //            string filePath = $"upload/{file.FileName}";
        //            var fullPath = CreatePathFile(filePath);
        //            using (var fileStream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(fileStream);
        //            }
        //            return Ok(new { filePath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Không tìm thây");
        //    }
        //}

        //[NonAction]
        //private string CreatePathFile(string RelativePathFileName)
        //{
        //    try
        //    {
        //        string serverRootPathFolder = _path;
        //        string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
        //        string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
        //        if (!Directory.Exists(fullPathFolder))
        //            Directory.CreateDirectory(fullPathFolder);
        //        return fullPathFile;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
        //[HttpPost("add/photo/{id}")]
        //public async Task<IActionResult> AddProductPhoto(IFormFile file, int proId)
        //{
        //    var result = await photoService.UploadPhotoAsync(file);
        //    if (result.Error != null)
        //    {
        //        return BadRequest(result.Error.Message);
        //    }
        //    return Ok(201);
        //}

        // GET: api/<SanPhamController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SanPhamModel> GetDataAll()
        {
            return _spBusiness.GetDataAll();
        }
        [Route("get-home")]
        [HttpGet]
        public IEnumerable<SanPhamModel> Gethome()
        {
            return _spBusiness.GetDataAll().Take(10).ToList();
        }
        [Route("product-all-paginate")]
        [HttpPost]
        public ResponseModel GetDataAllPaginate([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                long total = 0;
                var data = _spBusiness.GetDataAllPaginate(page, pageSize, out total);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        [Route("get-product-by-category")]
        [HttpPost]
        public ResponseModel GetProductByCategory([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string maloai = "";
                if (formData.Keys.Contains("maloai") && !string.IsNullOrEmpty(Convert.ToString(formData["maloai"])))
                {
                    maloai = Convert.ToString(formData["maloai"]);
                }
                long total = 0;
                var data = _spBusiness.GetProductByCategory(page, pageSize, out total, maloai);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        
        [Route("get-product-by-brand")]
        [HttpPost]
        public ResponseModel GetProductByBrand([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string mahang = "";
                if (formData.Keys.Contains("mahang") && !string.IsNullOrEmpty(Convert.ToString(formData["mahang"]))) { mahang = Convert.ToString(formData["mahang"]); }
                string tenhang = "";
                if (formData.Keys.Contains("tenhang") && !string.IsNullOrEmpty(Convert.ToString(formData["tenhang"]))) { tenhang = Convert.ToString(formData["tenhang"]); }
                long total = 0;
                var data = _spBusiness.GetProductByBrand(page, pageSize, out total, mahang, tenhang);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        [Route("get-product-new")]
        [HttpGet]
        public IEnumerable<SanPhamModel> GetProductNew()
        {
            return _spBusiness.GetProductNew();
        }


        [Route("get-by-id/{masp}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(string masp)
        {
            return _spBusiness.GetDatabyID(masp);
        }
        
        [Route("create-product")]
        [HttpPost]
        public async Task<SanPhamModel> CreateProduct([FromForm] ProductCreateRequest model)
        {
            model.MaSanPham = Guid.NewGuid().ToString();
            SanPhamModel sanPhamModel = new SanPhamModel()
            {
                MaSanPham = model.MaSanPham,
                TenSanPham = model.TenSanPham,
                MaLoai = model.MaLoai,
                TenLoai = model.TenLoai,
                MaHang = model.MaHang,
                TenHang = model.TenHang,
                XuatXu = model.XuatXu,
                BaoHanh = model.BaoHanh,
                MauSac = model.MauSac,
                GiaBan = model.GiaBan,
                MoTa = model.MoTa,
                GhiChu = model.GhiChu,
                Anh = await SaveFile(model.Anh)
            };
            _spBusiness.Create(sanPhamModel);
            return sanPhamModel;
        }


        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            if (!Directory.Exists(_userContentFolder))
            {
                Directory.CreateDirectory(_userContentFolder);
            }
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(output);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        [Route("update-product")]
        [HttpPost]
        public SanPhamModel UpdateProduct([FromBody] SanPhamModel model)
        {
            _spBusiness.Update(model);
            return model;
        }

        //[Route("delete-product")]
        //[HttpPost]
        //public IActionResult DeleteProduct([FromBody] Dictionary<string, object> formData)
        //{
        //    int masp = 0;
        //    if (formData.Keys.Contains("masp") && !string.IsNullOrEmpty(Convert.ToString(formData["masp"])))
        //    { masp = int.Parse(formData["masp"].ToString()); }
        //    _spBusiness.Delete(masp);
        //    return Ok();
        //}

        [Route("delete-product")]
        [HttpPost]
        public IActionResult DeleteProduct([FromBody] Dictionary<string, object> formData)
        {
            string MaSanPham = "";
            if (formData.Keys.Contains("MaSanPham") && !string.IsNullOrEmpty(Convert.ToString(formData["MaSanPham"]))) { MaSanPham = Convert.ToString(formData["MaSanPham"]); }
            _spBusiness.Delete(MaSanPham);
            return Ok();
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenSanPham = "";
                if (formData.Keys.Contains("tenSanPham") && !string.IsNullOrEmpty(Convert.ToString(formData["tenSanPham"]))) { tenSanPham = Convert.ToString(formData["tenSanPham"]); }
                long total = 0;
                var data = _spBusiness.Search(page, pageSize, out total, tenSanPham);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
