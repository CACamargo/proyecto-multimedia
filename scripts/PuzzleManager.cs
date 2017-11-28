using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartPuzzle (string puzzleName)
    {
        if (puzzleName.Equals("Puzzle1")) {
            Puzzle1 p = gameObject.GetComponent<Puzzle1>();
            if (!p.IsActive())
                p.Begin();
        }
        else if (puzzleName.Equals("Puzzle2"))
        {
            Puzzle2 p = gameObject.GetComponent<Puzzle2>();
            if (!p.IsActive())
                p.Begin();
        }
        else if (puzzleName.Equals("Puzzle3"))
        {
            Puzzle3 p = gameObject.GetComponent<Puzzle3>();
            if (!p.IsActive())
                p.Begin();
        }
    }

    public void SolvePuzzle (string solution)
    {
        if (solution.Equals("panel2"))
        {
            EndPuzzle("Puzzle1");
        }
        if (solution.Equals("book 27"))
        {
            EndPuzzle("Puzzle2");
        }
        if (solution.Equals("book4"))
        {
            EndPuzzle("Puzzle3");
        }
    }

    public void EndPuzzle(string puzzleName)
    {
        if (puzzleName.Equals("Puzzle1"))
        {
            Puzzle1 p = gameObject.GetComponent<Puzzle1>();
            if (p.IsActive())
                p.End();
        }
        if (puzzleName.Equals("Puzzle2"))
        {
            Puzzle2 p = gameObject.GetComponent<Puzzle2>();
            if (p.IsActive())
                p.End();
        }
        if (puzzleName.Equals("Puzzle3"))
        {
            Puzzle3 p = gameObject.GetComponent<Puzzle3>();
            if (p.IsActive())
                p.End();
        }
    }
}
