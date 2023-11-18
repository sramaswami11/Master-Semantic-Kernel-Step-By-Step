using Microsoft.SemanticKernel;

namespace Common;

public static class Init
{
    const string modelId = "gpt-3.5-turbo";
    #region OPENAI_APIKEY
    const string myApiKey = "{Your API Key}";
    #endregion

    public static IKernel Setup()
    {
        return new KernelBuilder()
             .WithOpenAIChatCompletionService(
                 modelId,              // The name of your deployment (e.g., "gpt-3.5-turbo")
                 myApiKey             // The API key of your Azure OpenAI service
             ).Build();

    }


}

