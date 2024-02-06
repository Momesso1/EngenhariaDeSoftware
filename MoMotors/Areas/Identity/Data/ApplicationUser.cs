using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using MoMotors.Areas.Identity.Models;
using MoMotors.Models;

namespace MoMotors.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<VeiculosModel> Veiculos { get; set; }

        public virtual ICollection<ChatIAModel> ChatIA { get; set; }


    }

}
