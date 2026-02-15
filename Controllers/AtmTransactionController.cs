using ATMDotNetCoreApp.DB;
using ATMDotNetCoreApp.DTOs;
using ATMDotNetCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ATMDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmTransactionController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;
        private readonly ILogger<AtmTransactionController> _logger;

        public AtmTransactionController(AppDbContext appDbContext, ILogger<AtmTransactionController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        [HttpPost("SaveTransac")]
        [Authorize]
        public IActionResult SaveTransaction(AtmTransacDTOs dTOs)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var transac = new AtmTransactionModel
                {
                    AccNo = dTOs.AccNo,
                    DateOfTrans = DateTime.Now,
                    TransacAmt = dTOs.TransacAmt,
                    TransacType = dTOs.TransacType,
                    TransferToAccNo = dTOs.TransferToAccNo
                };
                _appDbContext.AtmTransactionModels.Add(transac);
                _appDbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, transac);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "unexpected error...");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

       // [HttpGet("GeBal/{Id}")]
        [HttpPost("GetBalance")]
        [Authorize]
        public IActionResult GetBalance(int AccNo)
        {
            if(AccNo == 0)
                return BadRequest("Invalid Account Number..");
                        
            var query = _appDbContext.AtmTransactionModels.Where(a => a.AccNo == AccNo);

            // Sum safely by transaction type. cast to nullable double to avoid Sum() on empty sequences throwing.
            var deposit = query.Where(a => a.TransacType == 1).Select(a => (double?)a.TransacAmt).Sum() ?? 0.0;
            var withdraw = query.Where(a => a.TransacType == 2).Select(a => (double?)a.TransacAmt).Sum() ?? 0.0;
            var transfer = query.Where(a => a.TransacType == 3).Select(a => (double?)a.TransacAmt).Sum() ?? 0.0;


            var balance = deposit - withdraw- transfer;

            var result = new
            {
                AccNo = AccNo,
                DepositAmount = deposit,
                WithdrawAmount = withdraw,
                TransferAmount = transfer,
                Balance = balance
            };

            return Ok(result);
        }
    }    
}
