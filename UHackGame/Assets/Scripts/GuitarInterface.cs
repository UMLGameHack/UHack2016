using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * These are the enumerated values that the guitar can possibly output.
 * Use these to control the game.
 */ 
public enum GuitarNotes
{
    //these are the 5 major notes that sound "great"
    Major1,
    Major2,
    Major3,
    Major5,
    Major6,
    //these are 2 additional notes that sound "good"
    Major4,
    Major7,
    //these are 5 extra notes that sound "ok": use sparingly
    Flat9,
    Minor3,
    Dim5,
    Flat13,
    Dom7
}

/*
 * Every time you probe the guitar for input, multiple notes could be playing at once.
 * This structure will contain a list with all the currently playing guitar notes, as well as all of the 
 */ 
public struct GuitarInput
{
    public List<GuitarNotes> Notes;
    public List<GuitarNotes> OldNotes;
}
/*
 * This is the class that will be used for guitar input.
 * 
 * GuitarInputGetInput will most likely be its only publicly accessable method.
 *      Unless there are some other methods we'll need for init
 */ 
public abstract class GuitarInterface : MonoBehaviour
{
    /*
     * GetInput()
     *   Will probe the microphone jack for input and return a GuitarInput object
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

    // Use to initialize
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
	
	}

    protected GuitarInput G1;

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
