public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;
    public PromptGenerator()
    {
        _prompts = new List<string>
        {

            //fill with prompts here

        };
        _random = new Random();
    }

    public string GetRandomPrompt()
    {
        int i = _random.Next(_prompts.Count);
        return _prompts[i];
    }
}