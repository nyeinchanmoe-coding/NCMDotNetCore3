using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NCMDotNetCore.RestApiWithNLayer.Features.MyanmarMonths
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarMonthsController : ControllerBase
    {
        private async Task<MyanmarMonths> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("Months.json");
            var Model = JsonConvert.DeserializeObject<MyanmarMonths>(jsonStr);
            return Model;
        }
        [HttpGet]
        public async Task<IActionResult> Months()
        {
            var Model = await GetDataAsync();
            return Ok(Model.Tbl_Months);
        }
        [HttpGet("{MonthMm}")]
        public async Task<IActionResult> MonthInfo(string MonthMm)
        {
            var Model = await GetDataAsync();
            return Ok(Model.Tbl_Months.FirstOrDefault(x => x.MonthMm == MonthMm));
        }
    }


    public class MyanmarMonths
    {
        public Tbl_Months[] Tbl_Months { get; set; }
    }

    public class Tbl_Months
    {
        public int Id { get; set; }
        public string MonthMm { get; set; }
        public string MonthEn { get; set; }
        public string FestivalMm { get; set; }
        public string FestivalEn { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
    }

}
