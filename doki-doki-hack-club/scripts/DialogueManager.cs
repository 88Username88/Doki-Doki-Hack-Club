using Godot;
using System;

public partial class DialogueManager : Node
{
    private Label _nameLabel;
    private Label _speechLabel;
    private Global _global;

    private Sprite2D _elsa;
    private Sprite2D _lucy;
    private Sprite2D _mia;
    private Sprite2D _sussie;

    [Export] public float TypeSpeed = 0.05f;
    private Tween _currentTween;

    public override void _Process(double delta)
    {
        if (_nameLabel.Text == "Elsa") { _elsa.Scale = new Vector2(0.3663f, 0.3663f); }
        else { _elsa.Scale = new Vector2(0.333f, 0.333f); }

        if (_nameLabel.Text == "Lucy") { _lucy.Scale = new Vector2(0.341f, 0.3608f); }
        else { _lucy.Scale = new Vector2(0.310f, 0.328f); }

        if (_nameLabel.Text == "Mia") { _mia.Scale = new Vector2(0.3608f, 0.3608f); }
        else { _mia.Scale = new Vector2(0.328f, 0.328f); }
        
        if ( _nameLabel.Text == "Sussie") { _sussie.Scale = new Vector2(0.3311f, 0.3311f); }
        else { _sussie.Scale = new Vector2(0.301f, 0.301f); }
    }

    public override void _Ready()
    {
        GD.Print("DialogueManager is Ready!");
        _nameLabel = GetNode<Label>("Name");
        _speechLabel = GetNode<Label>("Speech");
        _global = GetNode<Global>("/root/Global");

       
        DisplayDialogueByIndex(_global.CurrentDialogueIndex);

        _nameLabel = GetNode<Label>("Name");
        _speechLabel = GetNode<Label>("Speech");

    
        _global = GetNode<Global>("/root/Global");

        _elsa = GetNode<Sprite2D>("Elsa");
        _lucy = GetNode<Sprite2D>("Lucy");
        _mia = GetNode<Sprite2D>("Mia");
        _sussie = GetNode<Sprite2D>("Sussie");

    }


    public void DisplayDialogueByIndex(int index)
    {
  
        CheckForSceneChange(index);

        Global.DialogueEntry entry = _global.GetDialogueEntry(index);
        if (entry != null)
        {
            DisplayText(entry.SpeakerName, entry.MessageText);
        }
    }

 
    public void DisplayText(string speakerName, string fullText)
    {
        GD.Print($"Attempting to display: {speakerName} - {fullText}");

      
        if (_currentTween != null && _currentTween.IsRunning())
        {
            _currentTween.Kill();
        }

        _nameLabel.Text = speakerName;
        _speechLabel.Text = fullText;
        _speechLabel.VisibleCharacters = 0;
        _currentTween = CreateTween();
        float duration = fullText.Length * TypeSpeed;
        _currentTween.TweenProperty(_speechLabel, "visible_characters", fullText.Length, duration)
                     .SetTrans(Tween.TransitionType.Linear);
    }

   

    public void DisplayNextMessage()
    {
        _global.CurrentDialogueIndex++;
        GD.Print($"Button Pressed! Moving to Index: {_global.CurrentDialogueIndex}");
        CheckForSceneChange(_global.CurrentDialogueIndex);
        DisplayDialogueByIndex(_global.CurrentDialogueIndex);
        UpdateCharacterVisibility(_global.CurrentDialogueIndex);
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


        if (!string.IsNullOrEmpty(targetPath))
        {
            string currentScene = GetTree().CurrentScene.SceneFilePath;
            if (targetPath != currentScene)
            {
                GD.Print($"Switching to NEW scene: {targetPath}");
                GetTree().ChangeSceneToFile(targetPath);
            }
            else
            {
                GD.Print("Blocked a loop: Target scene is the same as current scene.");
            }
        }
    }
     private void UpdateCharacterVisibility(int index)
    {
        _elsa.Visible = false;
        _lucy.Visible = false;
        _mia.Visible = false;
        _sussie.Visible = false;
        switch (index)
        {

            case 1:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;
            case 2:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 3:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 4:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 5:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 6:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 7:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 8:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 9:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 10:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;                
            case 11:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 12:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 13:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 14:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 15:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;                
            case 16:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;                
            case 17:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;                
            case 18:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;                
            case 19:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;                
            case 20:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 21:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 22:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 23:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;
            case 24:
                _lucy.Visible = true;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;
            case 25:
                _lucy.Visible = true;
                _mia.Visible = false;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 26:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 27:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 28:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 29:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 30:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 31:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 32:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 33:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 34:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 35:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 36:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 37:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 38:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 39:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 40:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;     
            case 41:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 42:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 43:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 44:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 45:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 46:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 47:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 48:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 49:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 50:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 51:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 52:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 53:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 54:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 55:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 56:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 57:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 58:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 59:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 60:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 61:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 62:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 63:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 64:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;



            case 65:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;
            case 66:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;
            case 67:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 68:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 69:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 70:
                _lucy.Visible = true;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 71:
                _lucy.Visible = true;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 72:
                _lucy.Visible = true;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = true;
                break;                
            case 73:
                _lucy.Visible = true;
                _mia.Visible = false;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 74:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 75:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 76:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 77:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 78:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 79:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 80:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 81:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 82:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 83:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 84:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 85: 
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 86:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 87:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 88:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 89:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 90:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 91:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 92:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;                
            case 93:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 94:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 95:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 96:
                _lucy.Visible = true;
                _mia.Visible = true;
                _sussie.Visible = true;
                _elsa.Visible = true;
                break;
            case 97:
                _lucy.Visible = false;
                _mia.Visible = true;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 98:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                
            case 99:
                _lucy.Visible = false;
                _mia.Visible = false;
                _sussie.Visible = false;
                _elsa.Visible = false;
                break;                

            default:
                break;
        }
    }

}