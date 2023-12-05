using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

var kernel = Common.Init.Setup();

var myPlugin = Common.Init.ImportPlugins(kernel, "plugins", "OrchestratorPlugin");
//var result = await Common.Init.GetIntent(kernel, myPlugin);

var myContext = new ContextVariables();
myContext.Set("INPUT", "These pretzels are making me thirsty!");

var result = await Common.Init.RunKernelAsync(kernel, myContext,myPlugin, "GetIntent");

Console.WriteLine(result);

myContext = new ContextVariables
{
    ["input"] = "Yes",
    ["history"] = @"Bot: How can I help you?
User: Admin of our R&D division of my company has sent us an invite for the Annual Holiday party.",
    ["options"] = "SendEmail, ReadEmail, SendMeeting, RsvpToMeeting, SendChat"
};

//result = await Common.Init.GetIntentTemplatized(kernel, myPlugin);
result = await Common.Init.RunKernelAsync(kernel, myContext, myPlugin, "GetIntentTemp");

Console.WriteLine(result);