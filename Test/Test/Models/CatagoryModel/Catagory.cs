//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Models.CatagoryModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Catagory
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Code Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
    }
}
