using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.RegularExpressions;

namespace PasswordStrengthChecker.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class WeatherForecastController : ControllerBase
    //{
    //    private static readonly string[] Summaries = new[]
    //    {
    //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //    };

    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet]
    //    public IEnumerable<WeatherForecast> Get()
    //    {
    //        var rng = new Random();
    //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateTime.Now.AddDays(index),
    //            TemperatureC = rng.Next(-20, 55),
    //            Summary = Summaries[rng.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    //}
    [ApiController]
    [Route("[controller]")]
    public class PasswordStrengthCheckerController : ControllerBase
    {
        [HttpGet]
        public string GetSomething()
        {
            return "Something";
        }

        //public static PasswordScore CheckStrength(string password)
        [HttpPost]
        public String PostNewPassword(string password)
        {
            int minLength = 8;
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string digits = "0123456789";
            string specialChars = "#?@!,-'/`_*$";
            //string password = "2woRDsss";
            int score = 0;
            if (password.Length >= (minLength))
            {
                score++;
            }

            if (Contains(password, uppercase))
            {
                score++;
            }

            if (Contains(password, lowercase))
            {
                score++;
            }

            if (Contains(password, digits))
            {
                score++;
            }

            if (Contains(password, specialChars))
            {
                score++;
            }

            String Strength = string.Empty;
            switch (score)
            {
                case 1:
                    Strength = "Very Weak";
                    break;
                case 2:
                    Strength = "Weak";
                    break;
                case 3:
                    Strength = "Average";
                    break;
                case 4:
                    Strength = "Strong";
                    break;
                case 5:
                    Strength = "Very Strong";
                    break;
                default:
                    Strength = "Very Weak";
                    break;
            }

            return Strength;
        }

        public static bool Contains(string target, string list)
        {
            return target.IndexOfAny(list.ToCharArray()) != -1;
        }
    }
}
