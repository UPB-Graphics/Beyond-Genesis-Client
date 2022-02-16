using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager: MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton
    public static CharacterManager instance;
    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    public int characterChosen;

}
