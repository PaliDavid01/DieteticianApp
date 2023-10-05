using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Storage
{
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float Kilocalorie { get; set; }
        public float Kilojoule { get; set; }
        public float Carbohydrate { get; set; }
        public float Cholesterol { get; set; }
        public float Saturatedfat { get; set; }
        public float Transfat { get; set; }
        public float Natrium_mg { get; set; }
        public float Fluorite_mg { get; set; }
        public float Salt { get; set; }
        public float Sugar { get; set; }
        public int Scale { get; set; }
        public DateTime Updated {  get; set; }
        public string UpdatedBy { get; set; }

    }
}
