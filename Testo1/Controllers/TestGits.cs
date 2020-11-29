using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testGits.Model;
using TestoGits1.Service;

namespace testGits.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestGits : ControllerBase
    {
        private ServiceLayer _service;
        public TestGits( ServiceLayer service)
        {
            _service = service;
        }
        [HttpPost("soal1")]
        public List<char> Soal1(InputSoal1 input)
        {
            return _service.Reveresed(input.input1);
        }


        [HttpPost]
        [Route("soal2")]
        public int Soal2(InputSoal1 input)
        {
            return _service.ConsecutiveOnes(input.input2.ToList());
        }

        [HttpPost]
        [Route("soal3")]
        public string Soal3(string input)
        {
            return _service.PerfectlyBalanced(input);
        }

    }
}
