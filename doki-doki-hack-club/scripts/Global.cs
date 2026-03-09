using Godot;
using System;
using System.Collections.Generic;

public partial class Global : Node
{
	   // --- Dialogue Management ---

    // Custom class to hold a single dialogue entry
    public class DialogueEntry
    {
        public string SpeakerName { get; set; }
        public string MessageText { get; set; }

        public DialogueEntry(string speaker, string message)
        {
            SpeakerName = speaker;
            MessageText = message;
        }
    }

    // A list to store all your dialogue sequences
    private List<DialogueEntry> _dialogueList = new List<DialogueEntry>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		GD.Print("Global Autoload is active!");
		InitializeDialogue(); // Call this to populate your dialogue list
	}
	
	 private void InitializeDialogue()
    {
        // Add your dialogue messages here in the desired order
        _dialogueList.Add(new DialogueEntry("Y/N", "Another morning as a highschool student. Waiting for my childhood friend before walking to school.")); // Index 0
        _dialogueList.Add(new DialogueEntry("Y/N", "I've only got 3 more days to pick a club, maybe i'll check out Elsa's club since she keeps mentioning it.")); // Index 1
        _dialogueList.Add(new DialogueEntry("Elsa", "Hey! Y/N, there you are! I though you left without me for a minute")); // Index 2
		_dialogueList.Add(new DialogueEntry("Y/N", "I would've if you were any later, we're going to miss homeroom"));
		_dialogueList.Add(new DialogueEntry("Elsa", "Dont worry, we'll make it on time if we cut through the field. Let's get going then"));
		_dialogueList.Add(new DialogueEntry(" ", "*You and Elsa hurridly walk to class*"));

		_dialogueList.Add(new DialogueEntry("Y/N", "Man that was a boring lesson. I'm glad the day is over."));
		_dialogueList.Add(new DialogueEntry("Y/N", "But I still need to pick a club..."));
		_dialogueList.Add(new DialogueEntry(" ", "as you look up from your desk you notice you're the only one in the room"));
		_dialogueList.Add(new DialogueEntry(" ", "*knock knock*"));
		_dialogueList.Add(new DialogueEntry(" ", "someone slides open the classroom door. as you turn your head you see it's Elsa"));
		_dialogueList.Add(new DialogueEntry("Elsa", "Hey, shouldn't you be in club?"));
		_dialogueList.Add(new DialogueEntry("Y/N", "Nah, I still haven't picked one yet. Are you not going to your club today?"));
		_dialogueList.Add(new DialogueEntry("Elsa", "well - since you're not in a club, I came to ask if you wanted to come to mine today."));
		_dialogueList.Add(new DialogueEntry("Elsa", "You know, to check it out and all"));
		_dialogueList.Add(new DialogueEntry("Y/N", "What club is it again?"));
		_dialogueList.Add(new DialogueEntry("Elsa", "*hmph* It's the Hack Club silly. I've told you about it like a million times already"));
		_dialogueList.Add(new DialogueEntry("Y/N", "I dont know, im no good at hacking. Or coding as a whole."));
		_dialogueList.Add(new DialogueEntry("Elsa", "Just come for today, you never know what could happen."));
		_dialogueList.Add(new DialogueEntry("Y/N", "Alright, let's go."));
		_dialogueList.Add(new DialogueEntry(" ", "*You and elsa walk to a classroom at the end of the corridor"));

		_dialogueList.Add(new DialogueEntry("Elsa", "Hey Everyone! I've come bearing potential members! Well just one member but thats better than you guys."));
		_dialogueList.Add(new DialogueEntry("Elsa", "Alright let's gather quickly. We need to discuss duties."));
		_dialogueList.Add(new DialogueEntry(" ", "as you sit at a few desks pushed together to form a round table you are introduced to the members of the Hack Club"));
		_dialogueList.Add(new DialogueEntry("Elsa", "This is Lucy, she founded the club."));
		_dialogueList.Add(new DialogueEntry("Elsa", "Next to her is Sussie, the youngest."));
		_dialogueList.Add(new DialogueEntry("Elsa", "And this is Mia, the most knowledgable of us."));
		_dialogueList.Add(new DialogueEntry("Elsa", "And there's ME! the vice president of this club."));
		_dialogueList.Add(new DialogueEntry("Y/N", "Hey everyone, nice to meet you."));
		_dialogueList.Add(new DialogueEntry("Sussie", "Should we really be letting just anyone in our club?"));
		_dialogueList.Add(new DialogueEntry("Lucy", "It's good to get new members, no matter who they are."));
		_dialogueList.Add(new DialogueEntry("Mia", "Yes, I agree"));
		_dialogueList.Add(new DialogueEntry("Sussie", "*hmph* Fine, but we need to ask them some questions first."));
		_dialogueList.Add(new DialogueEntry("Lucy", "Go ahead Sussie"));
		_dialogueList.Add(new DialogueEntry("Sussie", "M-me?"));
		_dialogueList.Add(new DialogueEntry("Lucy", "You suggested we ask questions did you not"));
		_dialogueList.Add(new DialogueEntry("Sussie", "I guess so.. - Alright!"));
		_dialogueList.Add(new DialogueEntry("Sussie", "So uhh do you like coding?"));
		_dialogueList.Add(new DialogueEntry("Y/N", "I guess so, yeah. Although i'm not very good at it"));
		_dialogueList.Add(new DialogueEntry("Sussie", "Why did you even come here if you're not good at it?"));
		_dialogueList.Add(new DialogueEntry("Y/N", "Well Elsa is my friend and she insisted I check it out."));
		_dialogueList.Add(new DialogueEntry("Mia", "Can I ask a question Sussie?"));
		_dialogueList.Add(new DialogueEntry("Sussie", "Of course you can, you dont need to ask me *hmph*"));
		_dialogueList.Add(new DialogueEntry("Mia", "What do you like to code Y/N?"));
		_dialogueList.Add(new DialogueEntry("Y/N", "Well little things I guess like small games."));
		_dialogueList.Add(new DialogueEntry("Lucy", "Oh! I forgot to mention, I brought some snacks if you guys are hungry."));
		_dialogueList.Add(new DialogueEntry("Sussie", "Hey! don't tell me you got those boring crisps again."));
		_dialogueList.Add(new DialogueEntry("Lucy", "Nope, this time I got those strawberry donuts you like."));
		_dialogueList.Add(new DialogueEntry("Sussie", "Nice, pass them here."));
		_dialogueList.Add(new DialogueEntry("Lucy", "*chuckles*"));
		_dialogueList.Add(new DialogueEntry("Elsa", "Hey! that't enough chit chat. We need to decide on a club activity otherwise we wont be authorised"));
		_dialogueList.Add(new DialogueEntry("Elsa", "anyone got any ideas?"));
		_dialogueList.Add(new DialogueEntry("Lucy", "Why dont we ask our newest member"));
		_dialogueList.Add(new DialogueEntry("Y/N", "Me? I'm just here to check it out"));
		_dialogueList.Add(new DialogueEntry("Elsa", "C'mon Y/N, pleaseeee"));
		_dialogueList.Add(new DialogueEntry("Y/N", "Well I do need to join a club soon so I suppose so"));
		_dialogueList.Add(new DialogueEntry("Elsa", "Yay!"));
		_dialogueList.Add(new DialogueEntry("Y/N", "I cant think of any activity ideas though"));
		_dialogueList.Add(new DialogueEntry("Lucy", "How about we each go home today and code a little program to show tomorrow?"));
		_dialogueList.Add(new DialogueEntry("Sussie", "-Hey! I dont have a computer at home though"));
		_dialogueList.Add(new DialogueEntry("Lucy", "I'll help you in the library at lunch then"));
		_dialogueList.Add(new DialogueEntry("Mia", "I like this idea."));
		_dialogueList.Add(new DialogueEntry("Elsa", "Me too! Alright, meeting ajurned."));
		_dialogueList.Add(new DialogueEntry(" ", "the rest of the hour Sussie and Mia chatted while Lucy and Elsa discussed club forms"));
		_dialogueList.Add(new DialogueEntry(" ", "quickly the day came to an end and you and Elsa walked eachother home"));

		_dialogueList.Add(new DialogueEntry("Y/N", "Time to code something I guess."));

		_dialogueList.Add(new DialogueEntry(" ", "its the next day, school is out and clubs are starting."));
		_dialogueList.Add(new DialogueEntry(" ", "as you open the door to Hack Club you spot Mia and Sussie having a heated argument while Elsa is trying to break it up."));
		_dialogueList.Add(new DialogueEntry("Elsa", "Guys, stop fighting!"));
		_dialogueList.Add(new DialogueEntry(" ", "Lucy steps in past you as the argument immedietly stops"));
		_dialogueList.Add(new DialogueEntry("Lucy", "Sorry i'm late guys, got distracted."));
		_dialogueList.Add(new DialogueEntry("Lucy", "Everything alright?"));
		_dialogueList.Add(new DialogueEntry("Elsa", "Yep, just a little quarel"));
		_dialogueList.Add(new DialogueEntry("Sussie", "Mia started it!"));
		_dialogueList.Add(new DialogueEntry("Mia", "Did not!"));
		_dialogueList.Add(new DialogueEntry("Lucy", "No need to argue right now you two, we have our projects to show remember."));
		_dialogueList.Add(new DialogueEntry("Sussie", "I guess- "));
		_dialogueList.Add(new DialogueEntry("Elsa", "Alright everyone, let's huddle!"));
		_dialogueList.Add(new DialogueEntry("Sussie", "Oh oh, let me show mine first!"));
		_dialogueList.Add(new DialogueEntry("Lucy", "Let's see it"));
		_dialogueList.Add(new DialogueEntry(" ", "Sussie's project is a rudimentary version of snake with love hearts rather than apples"));
		_dialogueList.Add(new DialogueEntry("Lucy", "I'll go next then"));
		_dialogueList.Add(new DialogueEntry(" ", "Lucy's project is a calculator that uses words rather than numbers"));
		_dialogueList.Add(new DialogueEntry("Y/N", "I guess i'll go next"));
		_dialogueList.Add(new DialogueEntry(" ", "everyone nods and smiles, interested by your project"));
		_dialogueList.Add(new DialogueEntry("Lucy", "Wow, nice considering you said you weren't a good coder"));
		_dialogueList.Add(new DialogueEntry("Elsa", "Yeah! now my turn"));
		_dialogueList.Add(new DialogueEntry(" ", "Elsa's project is a little 2D platformer"));
		_dialogueList.Add(new DialogueEntry("Elsa", "You said you liked games yesterday so I make this for you Y/N"));
		_dialogueList.Add(new DialogueEntry("Y/N", "Thanks, I like it"));
		_dialogueList.Add(new DialogueEntry("Lucy", "Mia, and your project?"));
		_dialogueList.Add(new DialogueEntry("Mia", "I dont really want to show it anymore"));
		_dialogueList.Add(new DialogueEntry("Lucy", "I'm sure it is good, we'd all like to see it"));
		_dialogueList.Add(new DialogueEntry("Mia", "a-Alright then"));
		_dialogueList.Add(new DialogueEntry(" ", "Mia's project looks to be a single line of code that reads 'char(mia).delete'"));
		_dialogueList.Add(new DialogueEntry("Sussie", "Huh, that's it? Even mine was better than that"));
		_dialogueList.Add(new DialogueEntry("Lucy", "Mia, what is this?"));
		_dialogueList.Add(new DialogueEntry("Mia", "My final goodbye-"));
		_dialogueList.Add(new DialogueEntry(" ", "as mia presses enter her body begins to slowly disappear"));
		_dialogueList.Add(new DialogueEntry(" ", "..."));

    }

    // Method to get a dialogue entry by its index
    public DialogueEntry GetDialogueEntry(int index)
    {
        if (index >= 0 && index < _dialogueList.Count)
        {
            return _dialogueList[index];
        }
        GD.PrintErr($"Dialogue entry at index {index} does not exist!");
        return null; // Or throw an exception
    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// Set your default starting scene here
	public string LastScenePath = "res://scenes/Sidewalk.tscn"; 

	public int CurrentDialogueIndex = 0; // Add this to track progress globally
	
}
