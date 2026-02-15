using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMDotNetCoreApp.Models
{
    [Table("TblAtmTransaction")]
    public class AtmTransactionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransacId { get; set; }
        [Required]
        public int AccNo { get; set; }

        [Required] 
        public DateTime DateOfTrans {  get; set; }

        [Required]
        public int TransacNo { get; set; } = 0;

        [Required] 
        public double TransacAmt {  get; set; }

        [Required] 
        public int TransacType { get; set; }

        [Required]
        public int TransferToAccNo { get; set; }

    }
}
