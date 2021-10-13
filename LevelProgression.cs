using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgression : MonoBehaviour
{
    //push level buttons to level array
    private Button[] levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); //level progression


        for (int i = 0; i < levelButtons; i++)
        {
               if (i + 1 > levelReached)
            levelButtons[i].interactable = false;
        }
    }

    // Update is called once per frame
    // lis‰‰ vicotry kohtaan PlayerPrefs.SetInt("levelReached", currentlevel + 1 );
}
