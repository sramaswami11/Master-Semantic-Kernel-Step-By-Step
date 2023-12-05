using HandlebarsDotNet;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

var kernel = Common.Init.Setup();
//var result = await kernel.RunAsync("95", weatherPlugin["ToCelsius"]);

// Import the Math Plugin
var weatherPlugin = kernel.ImportFunctions(new Plugins.WeatherPlugin.Weather(), "WeatherPlugin");
// Make a request that runs the Sqrt function
var result = await Common.Init.RunKernelAsync(kernel,"95", weatherPlugin,"ToCelsius");
Console.WriteLine(result.GetValue<double>());



//Create the context variables for the Temperature Difference function
var contextVariables = new ContextVariables
{
    ["city1"] = "Atlanta",
    ["city2"] = "Houston"
};
result = await Common.Init.RunKernelAsync(kernel, contextVariables, weatherPlugin, "GetTemperatureDifference");
Console.WriteLine(result.GetValue<double>());

//Make a request that runs the GetTemperatureDifference function
//result = await kernel.RunAsync(contextVariables, weatherPlugin["GetTemperatureDifference"]);
//Console.WriteLine(result);
