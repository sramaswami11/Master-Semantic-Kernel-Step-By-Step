using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

namespace Common;

public static class Init
{
    const string modelId = "gpt-3.5-turbo";
    #region OPENAI_APIKEY
    const string myApiKey = "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";
    #endregion

    public static IKernel Setup()
    {
        return new KernelBuilder()
             .WithOpenAIChatCompletionService(
                 modelId,              // The name of your deployment (e.g., "gpt-3.5-turbo")
                 myApiKey             // The API key of your Azure OpenAI service
             ).Build();

    }

    public static IDictionary<string, ISKFunction> ImportPlugins(IKernel kernel,
                                                                string pluginRoot,
                                                                string pluginTopDir)
    {
        var pluginsDirectory = Path.Combine(System.IO.Directory.GetCurrentDirectory(), pluginRoot);
        return kernel.ImportSemanticFunctionsFromDirectory(pluginsDirectory, pluginTopDir);
    }

    public static async Task<KernelResult> GetIntent(IKernel kernel, 
        IDictionary<string, ISKFunction> plugin)
    {

        var myContext = new ContextVariables();

       
        myContext.Set("INPUT", "These pretzels are making me thirsty!");

        var result = await kernel.RunAsync(myContext, plugin["GetIntent"]);
        return result;
    }

    public static async Task<KernelResult> GetIntentTemplatized(IKernel kernel, 
                                            IDictionary<string, ISKFunction> plugin)
    {

        var variables = new ContextVariables
        {
            ["input"] = "Yes",
            ["history"] = @"Bot: How can I help you?
User: Admin of our R&D division of my company has sent us an invite for the Annual Holiday party.",
            ["options"] = "SendEmail, ReadEmail, SendMeeting, RsvpToMeeting, SendChat"
        };

        var result = await kernel.RunAsync(variables, plugin["GetIntentTemp"]);
        return result;
    }



}

