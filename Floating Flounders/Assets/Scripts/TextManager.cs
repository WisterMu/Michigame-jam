using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public TextMeshProUGUI commandTextDebug;
    List<string> dialogueList = new List<string>();
    List<string> commandList = new List<string>();
    int dialogueIndex = 0;
    int emptyLineCount = 0;
    public TextAsset dialogueInput;     // Drag and drop text file to load
    public bool isActive = false;       // if the dialogue box is currently open
    public OverworldCharacterController playerController;       // for freezing the character when necessary

    // singleton stuff
    public static TextManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        uiText.text = "Initial text";
        // Debug.Log("Initial Capacity: " + dialogueList.Capacity.ToString());
        LoadTextFile(dialogueInput);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: animate text appearing letter by letter?
    }

    // Call this method to change the text of this object directly
    public void UpdateTextOverride(string newText)
    {
        // only updates the text when it's not empty
        if (string.IsNullOrWhiteSpace(newText))
        {
            // empty string can be used as a buffer action
            Debug.Log("EMPTY LINE " + emptyLineCount);
            emptyLineCount++;
        }
        else
        {
            uiText.text = newText;
        }
    }

    // Call this method to change the text using its internal list of strings
    public void UpdateText()
    {
        // test display for commands to be synced with dialogue
        string command = commandList[dialogueIndex];
        string newText = dialogueList[dialogueIndex];

        // only updates the text when it's not empty
        if (string.IsNullOrWhiteSpace(newText))
        {
            // empty string can be used as a buffer action
            // Debug.Log("EMPTY LINE " + emptyLineCount);
            emptyLineCount++;
            dialogueIndex = (dialogueIndex + 1) % dialogueList.Count;   // iterate dialogue index, loop back if overflow
        }
        else
        {
            uiText.text = newText;                                      // swaps text to next one in list
            dialogueIndex = (dialogueIndex + 1) % dialogueList.Count;   // iterate dialogue index, loop back if overflow
        }

        commandTextDebug.text = command;
        if (string.IsNullOrWhiteSpace(command))
        {
            // empty command, do nothing
        }
        else
        {
            // this is a command
            if (command.StartsWith("Appear"))
            {
                Debug.Log("Enabling Dialogue from command");
                ImageManager.Instance.EnableDialogue();
                isActive = true;
                // playerController.SetFrozen(true);
            }
            else if (command.StartsWith("Disappear"))
            {
                Debug.Log("Disabling Dialogue from command");
                ImageManager.Instance.DisableDialogue();
                isActive = false;
                // playerController.SetFrozen(false);
            }

            // finding which characters are referenced
            List<string> involvedCharacters = new List<string>();
            if (command.Contains("Rovin"))
            {
                involvedCharacters.Add("Rovin");
            }
            if (command.Contains("Mithya"))
            {
                involvedCharacters.Add("Mithya");
            }
            if (command.Contains("Kai"))
            {
                involvedCharacters.Add("Kai");
            }
            if (command.Contains("Julian"))
            {
                involvedCharacters.Add("Julian");
            }
            if (command.Contains("Cassian"))
            {
                involvedCharacters.Add("Cassian");
            }
            if (command.Contains("Yuxero"))
            {
                involvedCharacters.Add("Yuxero");
            }

            if (command.Contains("Enter"))
            {
                // new character is entering
                foreach (string characterName in involvedCharacters)
                {
                    ImageManager.Instance.EnableCharacter(characterName);
                }
            }
            else if (command.Contains("Leave"))
            {
                // character is leaving
                foreach (string characterName in involvedCharacters)
                {
                    ImageManager.Instance.DisableCharacter(characterName);
                }
            }
        }
    }

    // Parse a text file to load into the list of strings for the dialogue
    public void LoadTextFile(TextAsset textFile)
    {
        // Debug.Log(textFile);
        if (textFile)   // only loads if the text file exists
        {
            // empties out any previous text
            dialogueList.Clear();
            commandList.Clear();
            dialogueIndex = 0;

            string text = textFile.ToString();              // Convert TextAsset to string
            string[] textArray = text.Split("\n");          // Split file into separate lines
            // each entry in textArray should be a line in the text file

            // string prevLine = null;
            foreach (string line in textArray)  // Check each line separately to see if it's a command or not
            {
                // splits each line based on /
                // left half of line before / is dialogue, right half of line is command
                if (string.IsNullOrWhiteSpace(line))
                {
                    // empty line
                    dialogueList.Add(null);
                    commandList.Add(null);
                }
                else
                {
                    string formattedLine = line;
                    if (!line.Contains("//"))     // dialogue by itself, no command
                    {
                        formattedLine = line + "//";     // add the slash to end for splitting to work
                    }
                    Debug.Log("LINE: " + formattedLine);
                    string[] splitLine = formattedLine.Split("//");
                    foreach (string test in splitLine)
                    {
                        Debug.Log("ITEM: " + test);
                    }
                    string dialogueLine = splitLine[0].Trim(), commandLine = splitLine[1].Trim();

                    if (string.IsNullOrWhiteSpace(dialogueLine))
                    {
                        dialogueList.Add(null);
                    }
                    else
                    {
                        dialogueList.Add(dialogueLine);
                    }

                    if (string.IsNullOrWhiteSpace(commandLine))
                    {
                        commandList.Add(null);
                    }
                    else
                    {
                        commandList.Add(commandLine);
                    }
                }
            }
        }

        // print out the stored lines for debugging
        for (int i = 0; i < commandList.Count(); i++)
        {
            Debug.Log("COMMAND: " + commandList[i] + "\nDIALOGUE: " + dialogueList[i]);
        }

        // should be equal
        if (commandList.Count() != dialogueList.Count())
        {
            Debug.Log("ERROR: COMMAND AND DIALOGUE ARE OUT OF SYNC.\nCOMMAND COUNT: " + commandList.Count()
            + "\nDIALOGUE COUNT: " + dialogueList.Count());
        }
        else
        {
            Debug.Log("Command and Dialogue are synced!");
        }

    }

    // Debug function for converting a normal string to a literal string (all special characters are escaped)
    string ToLiteral(string input)
    {
        StringBuilder literal = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            switch (c)
            {
                case '\n': literal.Append(@"\n"); break;
                case '\r': literal.Append(@"\r"); break;
                case '\t': literal.Append(@"\t"); break;
                case '\\': literal.Append(@"\\"); break;
                case '\0': literal.Append(@"\0"); break;
                case '\b': literal.Append(@"\b"); break;
                case '\f': literal.Append(@"\f"); break;
                default: literal.Append(c); break;
            }
        }
        return literal.ToString();
    }


}