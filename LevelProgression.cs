using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgression : MonoBehaviour
{

    //private GameObject LevelButtonArr;
    public LevelSelect levelSel;
    void Start()
    {
        levelSel = Camera.main.GetComponent<LevelSelect>();
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); //level progression

        //LevelSelect LvlButton = LevelButtonArr.AddComponent<LevelSelect>();

        Debug.Log(levelSel.levelButtons);

        for (int i = 0; i < levelSel.levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelSel.levelButtons[i].GetComponent<Button>().interactable = false;

            }
        }

    }
    // lisää vicotry kohtaan PlayerPrefs.SetInt("levelReached", currentlevel + 1 );
}
