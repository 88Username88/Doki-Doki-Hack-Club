using Godot;
using System;


public partial class MainMenu : Node2D
{
	public override void _Ready() {}
	public override void _Process(double delta) {}
	public void _on_exit_button_pressed()
	{
				if (OS.HasFeature("web"))
		{
			GetTree().ReloadCurrentScene();
		}
		else
		{
			GetTree().Quit();
		}
	}
	public void _on_play_button_pressed()
	{
 	GD.Print("--- Play Button Debug Start ---");
    var globalNode = GetNodeOrNull("/root/Global");
    if (globalNode == null)
    {
        GD.PrintErr("CRITICAL: The Autoload node '/root/Global' was not found! Check Project Settings > Autoload.");
        return;
    }
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
