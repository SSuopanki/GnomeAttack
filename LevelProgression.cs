using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelProgression : MonoBehaviour
{
    //private GameObject LevelButtonArr;
    public LevelSelect levelSel;
    private string sceneName;
    private int LevelNum;
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name.Substring(6);
        LevelNum = int.Parse(sceneName);
        
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
}
