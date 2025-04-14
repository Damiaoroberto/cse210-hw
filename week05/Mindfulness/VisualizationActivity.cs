public class VisualizationActivity : Activity
{
    private List<string> _scenarios = new List<string>
    {
        "Imagine yourself walking through a peaceful forest. The leaves rustle gently and birds chirp above.",
        "Visualize sitting beside a calm lake at sunset, the sky painted with hues of orange and pink.",
        "Picture yourself lying on soft grass, looking up at a sky full of stars.",
        "Envision a peaceful beach, waves rolling in softly as the sun warms your skin.",
        "Imagine being in a quiet room filled with candlelight and a soft breeze moving the curtains."
    };

    public VisualizationActivity() : base("Visualization Activity", 
        "This activity will guide you through a calming mental visualization to help ease your mind and reduce stress.")
    {
    }

    
    protected override void PerformActivity()  
    {
        DisplayStartMessage();

        Random rand = new Random();
        string scenario = _scenarios[rand.Next(_scenarios.Count)];

        Console.WriteLine("\nClose your eyes and picture the following:\n");
        Console.WriteLine($"\"{scenario}\"");
        Console.WriteLine("\nFocus on every detail. Breathe deeply and stay in the moment.");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            ShowSpinner(5);
            Console.WriteLine("Let your mind explore the environment...");
            ShowSpinner(5);
        }

        DisplayEndMessage();
    }
}
