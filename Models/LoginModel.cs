using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMDotNetCoreApp.Models
{
    [Table("TblLoginMaster")]
    public class LoginModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccNo { get; set; }
        public int ActPin { get; set; }
        public string ActName { get; set; }
        public int AccIsActive { get; set; }
    }
}
