using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace FizzBuzz.Controllers
{
    public class FizzBuzzController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult FizzBuzz(string inputList)
        {
            List<string> formatedInputList = !string.IsNullOrEmpty(inputList) ? inputList.Split(new[] { ',' }).Select(p => p.Trim()).ToList() : new List<string>();
            StringBuilder formatedString = new StringBuilder();
            string formatedOutputList = string.Empty;
            foreach(string value in formatedInputList)
            {
                int outputValue = 0;
                bool isNumeric = int.TryParse(value, out outputValue);
                string outValue = string.Empty;
                if(isNumeric)
                {
                    if(outputValue % 15==0)
                    {
                        formatedString.AppendLine(outputDictionary.TryGetValue("15", out outValue) ? outValue : string.Empty);
                    }
                    else if (outputValue % 5 == 0)
                    {
                        formatedString.AppendLine(outputDictionary.TryGetValue("5", out outValue) ? outValue : string.Empty);
                    }
                    else if (outputValue % 3 == 0)
                    {
                        formatedString.AppendLine(outputDictionary.TryGetValue("3", out outValue) ? outValue : string.Empty);
                    }
                    else
                    {
                        formatedString.AppendLine("Divided " + outputValue + " by " + '3');
                        formatedString.AppendLine("Divided " + outputValue + " by " + '5');
                    }
                }
                else
                {
                    formatedString.AppendLine(outputDictionary.TryGetValue("string", out outValue) ? outValue : string.Empty);
                }
                formatedOutputList = formatedString.ToString().Replace(Environment.NewLine, "\n");
            }
            var result = formatedOutputList;
            return Json(result);
        }

        public Dictionary<string, string> outputDictionary = new Dictionary<string, string>()
        {
            {"3","Fizz" },
            {"5","Buzz" },
            {"15","FizzBuzz" },
            {"string","Invalid Item" },
        };
    }
}
