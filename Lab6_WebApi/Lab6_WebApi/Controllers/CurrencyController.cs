using Microsoft.AspNetCore.Mvc;

namespace lab6_WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

[Route("api/[controller]")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private static double _exchangeRate = 27.5;
    private static Timer _timer;

    static CurrencyController()
    {
        _timer = new Timer(UpdateExchangeRate, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    private static void UpdateExchangeRate(object? state)
    {
        _exchangeRate = new Random().NextDouble() * 10 + 30;
    }

    [HttpGet("exchange-rate")]
    public IActionResult Get()
    {
        return Ok(new
        {
            ExchangeRate = _exchangeRate,
        });
    }
    
}
