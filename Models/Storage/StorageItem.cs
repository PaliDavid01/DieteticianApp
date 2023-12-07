using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Storage
{
    public class StorageItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(Id))]
        public string MaterialId { get; set; }
        public int Amount { get; set; }
        public int PackageSize { get; set; }
        public DateTime StoredAt {  get; set; }
        public float Price { get; set; }
        public string StoredBy { get; set; }
        public Material Type { get; set; }
        
        public bool IsOpened {get; set;}
        
    }
}
