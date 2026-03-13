using Godot;
using System;

public partial class Classroom : Node2D
{
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
	}

	public void _on_main_menu_button_pressed()
	{
    var global = GetNode<Global>("/root/Global");
    global.LastScenePath = GetTree().CurrentScene.SceneFilePath;
    GetTree().ChangeSceneToFile("res://scenes/Main_Menu.tscn");
	}
}
