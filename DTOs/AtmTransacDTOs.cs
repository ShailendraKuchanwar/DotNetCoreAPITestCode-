namespace ATMDotNetCoreApp.DTOs
{
    public class AtmTransacDTOs
    {
        public int TransacId { get; set; }       
        public int AccNo { get; set; }
        
        public string DateOfTrans { get; set; }
       
        public int TransacNo { get; set; } = 0;
        
        public double TransacAmt { get; set; }
       
        public int TransacType { get; set; }

        public int TransferToAccNo { get; set; }
    }
}
