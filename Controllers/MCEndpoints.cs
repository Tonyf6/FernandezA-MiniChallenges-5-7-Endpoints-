using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace testssstest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MCEndpoints : ControllerBase
     {
        [HttpPost("MadLib")]
        public IActionResult MadLib([FromBody] MadLibInputModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string story = $"Once upon a time, {input.Name} went to the {input.Place} and {input.Action}.";

            return Ok(story);
        }

        [HttpGet("OddOrEven/{number}")]
        public IActionResult OddOrEven(int number)
        {
            string result = (number % 2 == 0) ? "even" : "odd";

            return Ok($"The number {number} is {result}.");
        }

        [HttpPost("ReverseIt/Alphanumeric")]
        public IActionResult ReverseAlphanumeric([FromBody] string input)
        {
            string reversed = new string(input.Reverse().ToArray());

            return Ok($"You entered {input}, reversed is {reversed}");
        }

        [HttpPost("ReverseIt/NumbersOnly")]
        public IActionResult ReverseNumbersOnly([FromBody] string input)
        {
            if (!input.All(char.IsDigit))
                return BadRequest("Invalid input. Only numbers are allowed.");

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);

            return Ok($"You entered {input}, reversed is {reversed}");
        }
    }

    public class MadLibInputModel
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string Action { get; set; }
    }
}