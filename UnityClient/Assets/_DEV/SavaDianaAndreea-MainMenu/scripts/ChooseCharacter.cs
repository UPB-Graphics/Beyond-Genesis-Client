using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChooseCharacter : MonoBehaviour
{
    int currentChar;
    public GameObject CharacterMenu;
    public GameObject MainMenu;
    // Start is called before the first frame update
    
    public void ChooseChar(int charIndex) {
        currentChar = charIndex;
        CharacterManager.instance.characterChosen = currentChar;
        CharacterMenu.SetActive(false);
        MainMenu.SetActive(true);
        
    }
}
