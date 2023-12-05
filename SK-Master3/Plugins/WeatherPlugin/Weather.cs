using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.WeatherPlugin;

public  class Weather
{
    private  Dictionary<string, double> cityTemperatures = new Dictionary<string, double>
    {
        {"Atlanta", 53},
        {"Boston", 37},
        {"Chicago", 32},
        {"Detroit", 32},
        {"El Paso", 59},
        {"Frankfurt", 41},
        {"Green Bay", 26},
        {"Houston", 60},
        {"Indianapolis", 34},
        {"Jacksonville", 66}
    };

    [SKFunction, Description("Convert Fahrenheit to Celsius")]
    public double ToCelsius([Description("The number to convert to Celsius")] double input)
    {
        var value =  (input - 32) * 5/9;
        return value;
    }

    [SKFunction, Description("Get temperature difference between two cities")]
    public double GetTemperatureDifference(string city1, string city2)
    {
        if (cityTemperatures.ContainsKey(city1) && cityTemperatures.ContainsKey(city2))
        {
            double temperatureCity1 = cityTemperatures[city1];
            double temperatureCity2 = cityTemperatures[city2];
            return Math.Abs(temperatureCity1 - temperatureCity2);
        }
        else
        {
            // Handle cases where city names are not found in the dictionary
            Console.WriteLine("Invalid city names.");
            return -1; // Use -1 to indicate an error or invalid input
        }
    }


}
