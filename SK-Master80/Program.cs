using Microsoft.SemanticKernel.Plugins.Core;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

const string ChatTranscript =
        @"
            Jim: Hey Tim, have you been following the news about the explosion of AI in the US?

Tim: Yeah, it's crazy how rapidly it's advancing. I mean, just a few years ago, it was all about smartphones, and now AI is everywhere.

Jim: Absolutely. It's not just in tech anymore. AI is influencing healthcare, finance, education – you name it. The impact is staggering.

Tim: True. I read that AI is transforming how businesses operate. They're using it for everything from customer service to optimizing supply chains.

Jim: And let's not forget self-driving cars. Tesla and other companies are pushing the boundaries of what's possible. It's like we're living in a sci-fi movie.

Tim: It does feel like that sometimes. But with all this progress, there are concerns too. I mean, what about job displacement and ethical considerations?

Jim: Good point. Automation could replace certain jobs, but it might also create new ones. As for ethics, there's the whole debate about bias in AI algorithms. We need to tread carefully.

Tim: Yeah, the bias issue is serious. If AI systems are making decisions, they need to be fair and unbiased. Otherwise, it could lead to some major problems.

Jim: Absolutely. And then there's the question of regulation. How do we ensure responsible AI development without stifling innovation?

Tim: Balancing regulation and innovation is tricky. We want to avoid hindering progress, but at the same time, we can't let AI run wild without any oversight.

Jim: Totally agree. It's a complex landscape. But one thing's for sure – the impact of AI on society is profound, and we're just scratching the surface.

Tim: Agreed, Jim. The future is exciting and a bit daunting. We need to stay informed and be part of the conversation about how AI shapes our world.

Jim: Couldn't have said it better, Tim. Let's keep an eye on this and see how it unfolds.
         ";

var kernel = Common.Init.Setup();

var time = kernel.ImportFunctions(new TimePlugin());

var result = await kernel.RunAsync(time["UtcNow"]);
Console.WriteLine(result);

var conversationSummaryPlugin = kernel.ImportFunctions(new ConversationSummaryPlugin(kernel));

KernelResult summary = await kernel.RunAsync(
                            ChatTranscript,
            conversationSummaryPlugin["SummarizeConversation"]);

Console.WriteLine("Generated Summary:");
Console.WriteLine(summary.GetValue<string>());
