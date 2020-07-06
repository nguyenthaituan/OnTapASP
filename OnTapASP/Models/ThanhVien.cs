﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnTapASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class ThanhVien
    {
        [DisplayName("Mã nhân viên")]
        public string MaTV { get; set; }
        [DisplayName("Họ nhân viên")]
        public string HoTV { get; set; }
        public string TenTV { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string AnhTV { get; set; }
        public string MaTinh { get; set; }
    
        public virtual Tinh Tinh { get; set; }
    }
}
