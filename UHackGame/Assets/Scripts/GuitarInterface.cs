using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
 * These are the enumerated values that the guitar can possibly output.
 * Use these to control the game.
 * 
 * Ignore the integer representations. those are for random melody gen.
 */ 
public enum GuitarNotes
{
    //these are the 5 major notes that sound "great"
    Major1 = 1,
    Major2 = 3,
    Major3 = 5,
    Major5 = 8,
    Major6 = 10,
    //these are 2 additional notes that sound "good"
    Major4 = 6,
    Major7 = 12,
    //these are 5 extra notes that sound "ok": use sparingly
    Flat9 = 2,
    Minor3 = 4,
    Dim5 = 7,
    Flat13 = 9,
    Dom7 = 11
}


/*
 * Every time you probe the guitar for input, multiple notes could be playing at once.
 * This structure will contain a list with all the currently playing guitar notes, 
 * as well as all of the notes that were last played
 */ 
public struct GuitarInput
{
    public List<GuitarNotes> Notes;
    public List<GuitarNotes> OldNotes;
}
/*
 * This is the class that will be used for guitar input.
 * 
 * GuitarInterface() public constructor to make a new instance.
 * 
 * GuitarInput GuitarInput() is used to get a list of notes played from the guitar input.
 * 
 * List<GuitarNotes> GetRandomMelody(int n) generates a random melody with n notes in it.
 *      Returns a list of GuitarNotes
 *      
 * string NoteToString(GuitarNotes note) given a note, returns a displayable string.
 *      
 * 
 */ 
public abstract class GuitarInterface : MonoBehaviour
{

    //contains lists of notes that *might* sound good in series
    #region Melodies
    public List<GuitarNotes> SoundsGood1 = new List<GuitarNotes> { GuitarNotes.Major1, GuitarNotes.Major3, GuitarNotes.Major5, GuitarNotes.Major1 };
    public List<GuitarNotes> SoundsGood2 = new List<GuitarNotes> { GuitarNotes.Major3, GuitarNotes.Major6, GuitarNotes.Major3, GuitarNotes.Major6, GuitarNotes.Major5, GuitarNotes.Major3, GuitarNotes.Major2, GuitarNotes.Major1 };
    public List<GuitarNotes> SoundsGood3 = new List<GuitarNotes> { GuitarNotes.Major5, GuitarNotes.Major5, GuitarNotes.Major7, GuitarNotes.Major1, GuitarNotes.Major1, GuitarNotes.Major7, GuitarNotes.Major1, GuitarNotes.Major1 };
    public List<GuitarNotes> SoundsGood4 = new List<GuitarNotes> { GuitarNotes.Major1, GuitarNotes.Major1, GuitarNotes.Major1, GuitarNotes.Major5, GuitarNotes.Major1, GuitarNotes.Major1, GuitarNotes.Major1, GuitarNotes.Major6 };
    public List<GuitarNotes> SoundsGood5 = new List<GuitarNotes> { GuitarNotes.Major3, GuitarNotes.Major5, GuitarNotes.Major2, GuitarNotes.Major1, GuitarNotes.Major3, GuitarNotes.Major5, GuitarNotes.Major7, GuitarNotes.Major1 };
    #endregion
   
    public GuitarInterface()
    {
        MajorKeyOf = "C"; //unchangable until later. but probably not later.
    }
    
    public string NoteToString(GuitarNotes note)
    {
        GuitarNotes n = note;
        //converts to int for easy switch
        switch( (int)note )
        {
            case 1:
                return "C";
            case 2:
                return "D\u266F";
            case 3:
                return "D";
            case 4:
                return "E\u226D";
            case 5:
                return "E";
            case 6:
                return "F";
            case 7:
                return "F\u226F";
            case 8:
                return "G";
            case 9:
                return "A\u226D";
            case 10:
                return "A";
            case 11:
                return "B\u226D";
            case 12:
                return "B";
            default:
                //never should reach here
                return "C";
        }   
    }
    
    /*
     * GetInput()
     *   Will probe the microphone jack for input and return a GuitarInput object -- which is just a list of all the notes currently being played.
     *   This is a lame mocked version to use for testing until M.I. and Andy get the guitar working
     *   
     *   This must be overridden
     */
    public virtual GuitarInput GetInput()
    {
        G1 = new GuitarInput();
        G1.Notes.Add(GuitarNotes.Major1);
        G1.OldNotes.Add(GuitarNotes.Major1);

        return G1;
    }

    /*
     * 
     * 
     *  This function is cryptic and messy and use magic numbers, and way too complicated
     *   I know. Sorry mang. music theory gets me pumped.
     *   
     *   It just returns a list of GuitarNotes that sounds good
     * 
     */
    public List<GuitarNotes> GetRandomMelody(int n)
    {

        //generates some random factors for the melody
        float repetitivity = Random.Range(0.2f,.8f); //probability of repeating the last note.
        float tendencyForTriad = Random.Range(0.4f, 1.0f); //probability of using a triad tone
        int beginAndEndOnTonic = (Random.Range(0.0f, 1.0f) > .8 ? 1 : 0); //begin and end on tonic
        int minorKey = (Random.Range(0.0f, 1.0f) > .8 ? 1 : 0); // is the melody minor? (Treat the 6th like the tonic)
        int isBlues = (Random.Range(0.0f, 1.0f) > .8 ? 1 : 0); //is this melody the blues? if so, second to last note is dom 7th
        float grossNoteChance = Random.Range(0.0f, 0.25f); //hey even a gross note happens every now and then
        
        //establishes tonics and triads and handles minor key things
        GuitarNotes one;
        GuitarNotes three;
        GuitarNotes five;
        GuitarNotes domSeven;

        if( minorKey == 0)
        {
            one = GuitarNotes.Major1;
            three = GuitarNotes.Major3;
            five = GuitarNotes.Major5;
            domSeven = GuitarNotes.Dom7;
        } else
        {
            one = GuitarNotes.Major6;
            three = GuitarNotes.Major1;
            five = GuitarNotes.Major3;
            domSeven = GuitarNotes.Major5;
        }

        //list containing the melody
        List <GuitarNotes> melody = new List<GuitarNotes>();

        //for each note, generates a random value
        for(int i = 0; i < n; i++)
        {
            //test absolute conditions first
            if( beginAndEndOnTonic == 1 && (i == 0 || i == n))
            {
                melody.Add(one);
                continue;
            }
            if (isBlues == 1 && (i == n - 1))
            {
                melody.Add(domSeven);
                continue;
            }
            // handles repetetivity then triads then gross notes
            if(repetitivity > Random.Range(0.0f,1.0f) && i > 0)
            {
                melody.Add(melody[i - 1]);
                continue;
            }
            if(tendencyForTriad > Random.Range(0.0f,1.0f))
            {
                GuitarNotes newNote = one;
                int x = Random.Range(0, 2);
                if (x == 0)
                    newNote = one;
                else if (x == 1)
                    newNote = three;
                else if (x == 2)
                    newNote = five;
                melody.Add(newNote);
                continue;
            }
            //gross notes happen, but not on the last note :(
            if(grossNoteChance > Random.Range(0.0f,1.0f) && i != n)
            {
                int x = Random.Range(0,4);
                if( x == 0)
                {
                    melody.Add(GuitarNotes.Flat9);           
                }
                else if( x == 1)
                {
                    melody.Add(GuitarNotes.Flat13);
                }
                else if(x == 2)
                {
                    melody.Add(GuitarNotes.Dim5);
                }
                else if(x == 3)
                {
                    melody.Add(GuitarNotes.Flat13);
                }
                else if(x == 4)
                {
                    melody.Add(GuitarNotes.Major7);
                }
                continue;
            }

            //nothing super special happened. Throw in a dom7, a maj 4 or a maj 6
            int r = Random.Range(0, 2);
            if (r == 0)
                melody.Add(GuitarNotes.Dom7);
            else if (r == 1)
                melody.Add(GuitarNotes.Major4);
            else if (r == 2)
                melody.Add(GuitarNotes.Major6);


        }
        return melody;
    }
    // Use to initialize
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
	
	}

    protected GuitarInput G1;
    protected string MajorKeyOf;

}

/*
 * Early-stage fake guitar-input device just for testing.
 * 
 * This will read input from the keyboard and output a guitar note.
 * 
 * 
 */
public class FakeGuitarInterface : GuitarInterface
{
    
    public FakeGuitarInterface()
    {
        MajorKeyOf = "C";
        G1 = new GuitarInput();
        G1.Notes = new List<GuitarNotes>();
        G1.OldNotes = new List<GuitarNotes>();
    }

    public override GuitarInput GetInput()
    {
        //moves 'Notes' into oldNotes
        G1.OldNotes.Clear();
        G1.OldNotes.AddRange(G1.Notes);
        //Clears out Notes;
        G1.Notes.Clear();

        //tests for down keys and puts them in notes
        if (Input.GetKeyDown(KeyCode.A ))
        {
            G1.Notes.Add(GuitarNotes.Major1);
        }
        if(Input.GetKeyDown(KeyCode.W ))
        {
            G1.Notes.Add(GuitarNotes.Major2);
        }
        if (Input.GetKeyDown(KeyCode.S ))
        {
            G1.Notes.Add(GuitarNotes.Major3);
        }
        if (Input.GetKeyDown(KeyCode.D ))
        {
            G1.Notes.Add(GuitarNotes.Major5);
        }
        if (Input.GetKeyDown(KeyCode.Space ))
        {
            G1.Notes.Add(GuitarNotes.Major6);
        }
        if (Input.GetKeyDown(KeyCode.Q ))
        {
            G1.Notes.Add(GuitarNotes.Major4);
        }
        if (Input.GetKeyDown(KeyCode.E ))
        {
            G1.Notes.Add(GuitarNotes.Major7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1 ))
        {
            G1.Notes.Add(GuitarNotes.Flat9);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2 ))
        {
            G1.Notes.Add(GuitarNotes.Minor3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3 ))
        {
            G1.Notes.Add(GuitarNotes.Dim5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4 ))
        {
            G1.Notes.Add(GuitarNotes.Flat13);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5 ))
        {
            G1.Notes.Add(GuitarNotes.Dom7);
        }

        return G1;
    }
}
