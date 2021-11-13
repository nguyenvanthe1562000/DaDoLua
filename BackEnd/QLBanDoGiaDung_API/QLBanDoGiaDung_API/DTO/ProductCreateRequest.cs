using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBanDoGiaDung_API.DTO
{
    public class ProductCreateRequest
    {
        public string MaSanPham         { get; set; }
        public string TenSanPham     { get; set; }
        public string MaLoai        { get; set; }
        public string TenLoai        { get; set; }
        public string MaHang        { get; set; }
        public string TenHang       { get; set; }
        public string XuatXu            { get; set; }
        public string BaoHanh       { get; set; }
        public string MauSac         { get; set; }
        public double GiaBan        { get; set; }
        public string MoTa       { get; set; }
        public string GhiChu         { get; set; }
        public IFormFile Anh        { get; set; }
    }
}
