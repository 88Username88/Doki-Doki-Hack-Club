using Godot;
using System;

public partial class DialogueManager : Node
{
    private Label _nameLabel;
    private Label _speechLabel;
    private Global _global; // Reference to your Global Autoload

    [Export] public float TypeSpeed = 0.05f; // Time in seconds per character
    private Tween _currentTween; // Keep a reference to the current tween

    public override void _Process(double delta)

    {

    }

    public override void _Ready()
    {
        GD.Print("DialogueManager is Ready!"); // Debug line
        _nameLabel = GetNode<Label>("Name");
        _speechLabel = GetNode<Label>("Speech");
        _global = GetNode<Global>("/root/Global");

        // Example: Display the first message (index 0)
        DisplayDialogueByIndex(_global.CurrentDialogueIndex);

        // Get references to your labels
        _nameLabel = GetNode<Label>("Name");
        _speechLabel = GetNode<Label>("Speech");

        // Get reference to the Global Autoload
        _global = GetNode<Global>("/root/Global");


    }

    // Call this method to display a specific dialogue entry by its index
    public void DisplayDialogueByIndex(int index)
    {
        // Check if this specific index should trigger a scene transition
        CheckForSceneChange(index);

        Global.DialogueEntry entry = _global.GetDialogueEntry(index);
        if (entry != null)
        {
            DisplayText(entry.SpeakerName, entry.MessageText);
        }
    }

    // This method handles the typewriter effect
    public void DisplayText(string speakerName, string fullText)
    {
        GD.Print($"Attempting to display: {speakerName} - {fullText}"); // Debug line

        // Stop any ongoing tween to prevent conflicts
        if (_currentTween != null && _currentTween.IsRunning())
        {
            _currentTween.Kill();
        }

        // 1. Set the Name label immediately
        _nameLabel.Text = speakerName;

        // 2. Set the Speech text and hide all characters initially
        _speechLabel.Text = fullText;
        _speechLabel.VisibleCharacters = 0;

        // 3. Create a Tween to animate the visible_characters property
        _currentTween = CreateTween();

        // Calculate duration based on text length and speed
        float duration = fullText.Length * TypeSpeed;

        // Animate from 0 to the total number of characters
        _currentTween.TweenProperty(_speechLabel, "visible_characters", fullText.Length, duration)
                     .SetTrans(Tween.TransitionType.Linear);
    }

    // You can add methods here to advance dialogue, e.g., on a button press
    // For example:
    // private int _currentDialogueIndex = 0;
    // public void _on_next_button_pressed()
    // {
    //     _currentDialogueIndex++;
    //     if (_currentDialogueIndex < _global.GetDialogueCount())
    //     {
    //         DisplayDialogueByIndex(_currentDialogueIndex);
    //     }
    //     else
    //     {
    //         GD.Print("End of dialogue!");
    //         // Handle end of dialogue, e.g., hide dialogue box
    //     }
    // }
    public void DisplayNextMessage()
    {
        // 1. Increment the index
        _global.CurrentDialogueIndex++;

        // 2. Debug print to see exactly what index triggered the loop
        GD.Print($"Button Pressed! Moving to Index: {_global.CurrentDialogueIndex}");

        // 3. Check for scene change BEFORE displaying text
        CheckForSceneChange(_global.CurrentDialogueIndex);

        // 4. Display the text
        DisplayDialogueByIndex(_global.CurrentDialogueIndex);
    }

    private void CheckForSceneChange(int index)
    {
        string currentScenePath = GetTree().CurrentScene.SceneFilePath;
        string targetPath = "";

        switch (index)
        {
            case 1: targetPath = "res://scenes/Sidewalk.tscn"; break;
            case 5: targetPath = "res://scenes/Black.tscn"; break;
            case 6: targetPath = "res://scenes/Classroom.tscn"; break;
            case 22: targetPath = "res://scenes/Black.tscn"; break;
            case 23: targetPath = "res://scenes/Classroom.tscn"; break;
            case 63: targetPath = "res://scenes/Black.tscn"; break;
            case 65: targetPath = "res://scenes/House.tscn"; break;
            case 66: targetPath = "res://scenes/Black.tscn"; break;
            case 70: targetPath = "res://scenes/Classroom.tscn"; break;
            case 98: targetPath = "res://scenes/Black.tscn"; break;
            case 100: targetPath = "res://scenes/Main_Menu.tscn"; _global.CurrentDialogueIndex = 1; break;
        }

        // --- THE LOOP FIX (CIRCUIT BREAKER) ---
        if (!string.IsNullOrEmpty(targetPath))
        {
            string currentScene = GetTree().CurrentScene.SceneFilePath;

            // ONLY change if the target is DIFFERENT from where we are now
            if (targetPath != currentScene)
            {
                GD.Print($"Switching to NEW scene: {targetPath}");
                GetTree().ChangeSceneToFile(targetPath);
            }
            else
            {
                GD.Print("Blocked a loop: Target scene is the same as current scene.");
            }
            //         string targetScene = "";

            // switch (index)
            // 	{
            // 	case 1:
            // 		targetScene = "res://scenes/Sidewalk.tscn";
            //             break;



            //     case 7: 
            //         targetScene = "res://scenes/Classroom.tscn";
            //         break;

            //     case 21: 
            //         targetScene = "res://scenes/Black.tscn";
            // 		break;

            // 	case 22: 
            //     targetScene = "res://scenes/Classroom.tscn";
            // 		break;

            // 	case 64: 
            //         targetScene = "res://scenes/Black.tscn";
            //         break;

            //     case 66: 
            //         targetScene = "res://scenes/House.tscn";
            // 			break;

            // 		case 67: 
            //         targetScene = "res://scenes/Black.tscn";
            // 			break;


            // 		case 70: 
            //         targetScene = "res://scenes/Classroom.tscn";
            // 			break;

            // 		case 97: 
            //         targetScene = "res://scenes/Black.tscn";
            //         break;



            // }        if (targetScene != "")
            //     {
            //         GetTree().ChangeSceneToFile(targetScene);
            //     }

            // if (!string.IsNullOrEmpty(targetScene))
            // {
            //     GD.Print($"Changing scene to: {targetScene}");
            //     GetTree().ChangeSceneToFile(targetScene);
            // }
        }
    }
}