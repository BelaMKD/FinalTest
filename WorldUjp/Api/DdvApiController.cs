using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldUjp.Api
{
    [Route("api/ddv")]
    [ApiController]
    public class DdvApiController : ControllerBase
    {
        private readonly IDDVRepository dDVRepository;

        public DdvApiController(IDDVRepository dDVRepository)
        {
            this.dDVRepository = dDVRepository;
        }
        [HttpGet]
        public IActionResult GetAllDDVs()
        {
            var data = dDVRepository.GetAll(); ;
            return Ok(data);
        }
    }
}