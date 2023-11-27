using Microsoft.SemanticKernel;

var kernel = Common.Init.Setup();

var myPlugin = Common.Init.ImportPlugins(kernel, "plugins", "OrchestratorPlugin");
var result = await Common.Init.GetIntent(kernel, myPlugin);
Console.WriteLine(result);

result = await Common.Init.GetIntentTemplatized(kernel, myPlugin);

Console.WriteLine(result);