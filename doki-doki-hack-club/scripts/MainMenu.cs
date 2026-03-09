using Godot;
using System;


public partial class MainMenu : Node2D
{
	//Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Your code here


	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Your code here


	}

	public void _on_exit_button_pressed()
	{
				if (OS.HasFeature("web"))
		{
			// Restarts the scene for web players on itch.io
			GetTree().ReloadCurrentScene();
		}
		else
		{
			// Closes the app on Windows/macOS/Linux
			GetTree().Quit();
		}
	}

	public void _on_play_button_pressed()
	{
 GD.Print("--- Play Button Debug Start ---");

    // 1. Check if the Global node even exists
    var globalNode = GetNodeOrNull("/root/Global");
    if (globalNode == null)
    {
        GD.PrintErr("CRITICAL: The Autoload node '/root/Global' was not found! Check Project Settings > Autoload.");
        return;
    }

    // 2. Check if we can cast it to your Global class
    if (globalNode is Global global)
    {
        GD.Print($"SUCCESS: Found Global node. Current LastScenePath value: '{global.LastScenePath}'");

        if (string.IsNullOrEmpty(global.LastScenePath))
        {
            GD.PrintErr("FAILURE: LastScenePath is empty. Hardcoding a fix now...");
            global.LastScenePath = "res://scenes/Sidewalk.tscn";
        }

        GD.Print($"Final Attempt: Changing scene to {global.LastScenePath}");
        GetTree().ChangeSceneToFile(global.LastScenePath);
    }
    else
    {
        GD.PrintErr("CRITICAL: Found a node at /root/Global, but it is NOT the 'Global' class. Did you attach the right script?");
    }
    
    GD.Print("--- Play Button Debug End ---");
	}

}
