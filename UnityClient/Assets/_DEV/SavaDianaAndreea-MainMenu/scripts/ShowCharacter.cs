using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public GameObject[] characters = new GameObject[6];
    //ordinea maleA, maleB, femaleA, femaleB, FEMALEC, maleC
    // Start is called before the first frame update
    void Start()
    {
        //set active the chosen character from character Menu
        int charChosen = CharacterManager.instance.characterChosen;
        characters[charChosen].SetActive(true);
    }

    
}
