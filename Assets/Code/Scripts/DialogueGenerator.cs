using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGenerator : MonoBehaviour {

    private List<string> names;

    // 0-3 controls how vague the customer will describe what they want to the player
    private int vagueness = 0;

    // dictionaries for storing the clothing items with
    // descriptors of all levels of vagueness
    Dictionary<string, List<string>> d_top;
    Dictionary<string, List<string>> d_bottom;
    Dictionary<string, List<string>> d_feet;

    // call all init dictionary funcs
    public void Awake() {
        names = new List<string>();
        InitNames();
        d_top = new Dictionary<string, List<string>>();
        InitDTop();
        d_bottom = new Dictionary<string, List<string>>();
        InitDBottom();
        d_feet = new Dictionary<string, List<string>>();
        InitDFeet();
    }

    // add all names to name list
    private void InitNames() {
        names.Add("Alan");
        names.Add("Alex");
        names.Add("Brande");
        names.Add("Brenda");
        names.Add("Cronk");
        names.Add("Kyle");
        names.Add("Miles");
        names.Add("Charles");
        names.Add("Jesus");
        names.Add("Stacey");
        names.Add("Gregor");
        names.Add("Frank");
        names.Add("Kain");
        names.Add("Gwen");
        names.Add("Mary");
        names.Add("Beth");
        names.Add("Helen");
        names.Add("Gordo");
        names.Add("Daisy");
        names.Add("Peach");
        names.Add("Prudence");
        names.Add("Anne");
        names.Add("Bea");
        names.Add("Shrark");
        names.Add("Kayden");
    }

    // add every top item to the dictionary under the appropriate key
    // and add all descriptors
    private void InitDTop() {
        d_top["jacket_black"] = new List<string>();
        d_top["jacket_black"].Add("black jackets"); // explicit
        d_top["jacket_black"].Add("black"); // unclear
        d_top["jacket_black"].Add("badass vibes"); // vague
        d_top["jacket_black"].Add("to be prepared, yet inconspicuous"); // mind reader

        d_top["jacket_denim"] = new List<string>();
        d_top["jacket_denim"].Add("denim jackets"); // explicit
        d_top["jacket_denim"].Add("denim"); // unclear
        d_top["jacket_denim"].Add("jeanish stuff"); // vague
        d_top["jacket_denim"].Add(" to be stylish and warm"); // mind reader

        d_top["shirt_short_blue"] = new List<string>();
        d_top["shirt_short_blue"].Add("short sleeved, blue shirts"); // explicit
        d_top["shirt_short_blue"].Add("things blue and short"); // unclear
        d_top["shirt_short_blue"].Add("beachwear"); // vague
        d_top["shirt_short_blue"].Add("inconspicuous clothes"); // mind reader

        d_top["shirt_short_green"] = new List<string>();
        d_top["shirt_short_green"].Add("short sleeved, green shirts");
        d_top["shirt_short_green"].Add("green");
        d_top["shirt_short_green"].Add("stuff I can go to the gym in");
        d_top["shirt_short_green"].Add("natural colors");

        d_top["shirt_short_magenta"] = new List<string>();
        d_top["shirt_short_magenta"].Add("short sleeved, magenta shirts"); // explicit
        d_top["shirt_short_magenta"].Add("magenta"); // unclear
        d_top["shirt_short_magenta"].Add("multi-coloured shirts"); // vague
        d_top["shirt_short_magenta"].Add("contrast"); // mind reader

        d_top["tank_top_black"] = new List<string>();
        d_top["tank_top_black"].Add("black tank tops"); // explicit
        d_top["tank_top_black"].Add("to go sleeveless"); // unclear
        d_top["tank_top_black"].Add("stuff I can go to the gym in"); // vague
        d_top["tank_top_black"].Add("beachwear"); // mind reader
        
        d_top["tank_top_lavender"] = new List<string>();
        d_top["tank_top_lavender"].Add("lavender tank tops"); // explicit
        d_top["tank_top_lavender"].Add("lavender tops"); // unclear
        d_top["tank_top_lavender"].Add("stuff I can go to the gym in"); // vague
        d_top["tank_top_lavender"].Add("beachwear"); // mind reader

        d_top["tank_top_teal"] = new List<string>();
        d_top["tank_top_teal"].Add("teal tank tops"); // explicit
        d_top["tank_top_teal"].Add("to go sleeveless"); // unclear
        d_top["tank_top_teal"].Add("ocean-ish colors"); // vague
        d_top["tank_top_teal"].Add("beachwear"); // mind reader
    }

    // add every bottom item to the dictionary under the appropriate key
    // and add all descriptors
    private void InitDBottom() {
        d_bottom["dress_long_lavender"] = new List<string>();
        d_bottom["dress_long_lavender"].Add("long, lavender dresses"); // explicit
        d_bottom["dress_long_lavender"].Add("lavender"); // unclear
        d_bottom["dress_long_lavender"].Add("don't like pants"); // vague
        d_bottom["dress_long_lavender"].Add("formalwear"); // mind reader
        
        d_bottom["dress_long_maroon"] = new List<string>();
        d_bottom["dress_long_maroon"].Add("long, maroon dresses"); // explicit
        d_bottom["dress_long_maroon"].Add("maroon"); // unclear
        d_bottom["dress_long_maroon"].Add("don't like pants"); // vague
        d_bottom["dress_long_maroon"].Add("formalwear"); // mind reader
        
        d_bottom["dress_red"] = new List<string>();
        d_bottom["dress_red"].Add("red dresses"); // explicit
        d_bottom["dress_red"].Add("red"); // unclear
        d_bottom["dress_red"].Add("don't like pants"); // vague
        d_bottom["dress_red"].Add("formalwear"); // mind reader

        d_bottom["pants_black"] = new List<string>();
        d_bottom["pants_black"].Add("black pants"); // explicit
        d_bottom["pants_black"].Add("black"); // unclear
        d_bottom["pants_black"].Add("goth stuff"); // vague
        d_bottom["pants_black"].Add("to hide my legs"); // mind reader

        d_bottom["pants_denim"] = new List<string>();
        d_bottom["pants_denim"].Add("denim pants"); // explicit
        d_bottom["pants_denim"].Add("denim"); // unclear
        d_bottom["pants_denim"].Add("jeanish stuff"); // vague
        d_bottom["pants_denim"].Add("to hide my legs"); // mind reader

        d_bottom["skirt_magenta"] = new List<string>();
        d_bottom["skirt_magenta"].Add("magenta skirts"); // explicit
        d_bottom["skirt_magenta"].Add("magenta"); // unclear
        d_bottom["skirt_magenta"].Add("anything that isn't pants"); // vague
        d_bottom["skirt_magenta"].Add("anything that shows off my legs"); // mind reader
    }

    private void InitDFeet() {
        d_feet["shoe_red"] = new List<string>();
        d_feet["shoe_red"].Add("red shoes"); // explicit
        d_feet["shoe_red"].Add("red"); // unclear
        d_feet["shoe_red"].Add("rosy"); // vague
        d_feet["shoe_red"].Add("anything that accentuates my sunny disposition"); // mind reader

        d_feet["shoe_black_converse"] = new List<string>();
        d_feet["shoe_black_converse"].Add("black converses"); // explicit
        d_feet["shoe_black_converse"].Add("black"); // unclear
        d_feet["shoe_black_converse"].Add("goth stuff"); // vague
        d_feet["shoe_black_converse"].Add("stuff that's good for dates"); // mind reader
        
        d_feet["shoe_blue"] = new List<string>();
        d_feet["shoe_blue"].Add("blue shoes"); // explicit
        d_feet["shoe_blue"].Add("blue"); // unclear
        d_feet["shoe_blue"].Add("ocean-ish colors"); // vague
        d_feet["shoe_blue"].Add("whatever reminds me of the clematis"); // mind reader
        
        d_feet["shoe_brown"] = new List<string>();
        d_feet["shoe_brown"].Add("brown shoes"); // explicit
        d_feet["shoe_brown"].Add("brown"); // unclear
        d_feet["shoe_brown"].Add("earthy tones"); // vague
        d_feet["shoe_brown"].Add("anything inconspicuous"); // mind reader

        d_feet["shoe_canvas"] = new List<string>();
        d_feet["shoe_canvas"].Add("canvas shoes"); // explicit
        d_feet["shoe_canvas"].Add("canvas"); // unclear
        d_feet["shoe_canvas"].Add("tenty stuff"); // vague
        d_feet["shoe_canvas"].Add("anything inconspicuous"); // mind reader

        d_feet["shoe_black"] = new List<string>();
        d_feet["shoe_black"].Add("black shoes"); // explicit
        d_feet["shoe_black"].Add("black"); // unclear
        d_feet["shoe_black"].Add("goth stuff"); // vague
        d_feet["shoe_black"].Add("anything inconspicuous"); // mind reader
        
        d_feet["shoe_female_black"] = new List<string>();
        d_feet["shoe_female_black"].Add("black flats"); // explicit
        d_feet["shoe_female_black"].Add("black"); // unclear
        d_feet["shoe_female_black"].Add("whatever makes me feel like a femme fatale"); // vague
        d_feet["shoe_female_black"].Add("formalwear"); // mind reader

        d_feet["shoe_female_pink"] = new List<string>();
        d_feet["shoe_female_pink"].Add("pink flats"); // explicit
        d_feet["shoe_female_pink"].Add("pink"); // unclear
        d_feet["shoe_female_pink"].Add("rosy stuff"); // vague
        d_feet["shoe_female_pink"].Add("formalwear"); // mind reader

        d_feet["shoe_female_white"] = new List<string>();
        d_feet["shoe_female_white"].Add("white flats"); // explicit
        d_feet["shoe_female_white"].Add("white"); // unclear
        d_feet["shoe_female_white"].Add("daisy colored"); // vague
        d_feet["shoe_female_white"].Add("formalwear"); // mind reader
    }

    public string[] Generate() {
        string[] dialogue = new string[4];
        // generate intro sentence
        string sentence = "Hi, I'm ";
        sentence += names[Random.Range(0, names.Count)];
        sentence += ".";
        dialogue[0] = sentence; // add sentence to dialogue return
        
        // generate top clue sentence
        sentence = "For tops, I like ";
        List<string> d_topKeys = new List<string>(d_top.Keys); // fetch all key for tops
        string top_key = d_topKeys[Random.Range(0, d_topKeys.Count)];
        FindObjectOfType<LevelController>().SetWantedTop(top_key);
        sentence += d_top[top_key][vagueness]; // get random descriptor for the top
        sentence += ".";
        dialogue[1] = sentence; // add sentence to dialogue return

        // generate bottom clue sentence
        sentence = "For bottoms, I like ";
        List<string> d_bottomKeys = new List<string>(d_bottom.Keys); // fetch all key for bottoms
        string bottom_key = d_bottomKeys[Random.Range(0, d_bottomKeys.Count)];
        FindObjectOfType<LevelController>().SetWantedBottom(bottom_key);
        sentence += d_bottom[bottom_key][vagueness]; // get random descriptor for the bottom
        sentence += ".";
        dialogue[2] = sentence; // add sentence to dialogue return

        // generate feet clue sentence
        sentence = "For my feet, I like ";
        List<string> d_feetKeys = new List<string>(d_feet.Keys); // fetch all key for feet
        string feet_key = d_feetKeys[Random.Range(0, d_feetKeys.Count)];
        FindObjectOfType<LevelController>().SetWantedFeet(feet_key);
        sentence += d_feet[feet_key][vagueness]; // get random descriptor for the feet
        sentence += ".";
        dialogue[3] = sentence; // add sentence to dialogue return

        return dialogue;
    }

    public void IncreaseVagueness() {
        if(vagueness >= 3) vagueness = 3; // if vagueness is at max or greater set to max
        else ++vagueness; // otherwise increase vagueness by 1
    }
}