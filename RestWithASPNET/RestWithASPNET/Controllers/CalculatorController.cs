using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    //SOMA
    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) 
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    //SUBTRAÇÃO
    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber) {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
            var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(subtraction.ToString());
        }
        return BadRequest("Invalid Input");
    }

    //MULTIPLICAÇÃO
    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber) {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
            var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(multiplication.ToString());
        }
        return BadRequest("Invalid Input");
    }

    //DIVISÃO
    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber) {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
            var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(division.ToString());
        }
        return BadRequest("Invalid Input");
    }

    //Média
    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult Mean(string firstNumber, string secondNumber) {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
            var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2 ;
            return Ok(mean.ToString());
        }
        return BadRequest("Invalid Input");
    }

    //Raiz Quadrada
    [HttpGet("square-root/{firstNumber}")]
    public IActionResult SquareRoot(string firstNumber) {
        if (IsNumeric(firstNumber)) {
            var squareRoot = ConvertToDouble(firstNumber);
            var result = Math.Sqrt(squareRoot);
            return Ok(result.ToString());
        }
        return BadRequest("Invalid Input");
    }

    private bool IsNumeric(string strNumber) {
        double number;
        bool isNumber = double.TryParse(
            strNumber, 
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);
        return isNumber;
    }
    private decimal ConvertToDecimal(string strNumber) {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue)) 
        { 
            return decimalValue;
        }
        return 0;
    }
    private double ConvertToDouble(string strNumber) {
        double doubleValue;
        if (double.TryParse(strNumber, out doubleValue)) {
            return doubleValue;
        }
        return 0;
    }
}
