using Godot;
using System;

public partial class House : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_main_menu_button_pressed()
	{
	   // Access the Global autoload
    var global = GetNode<Global>("/root/Global");
    
    // Save the current scene path to the global variable
    global.LastScenePath = GetTree().CurrentScene.SceneFilePath;
    
    // Switch to the Main Menu
    GetTree().ChangeSceneToFile("res://scenes/Main_Menu.tscn");
	}
}
