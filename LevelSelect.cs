using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelIcon;
    public GameObject thisCanvas;
    public int numberOfLevels = 40;
    public Vector2 iconSpacing;
    private Rect panelDimensions;
    private Rect iconDimensions;
    private int PerPage;
    private int currentLevelCount;
    public GameObject[] levelButtons;
    private string sceneName;
    private int LevelNum;
    public LevelSelect levelSel;


    // Calculations how many panels are needed  
    void Start()
    {
        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
        int maxInARow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int maxInACol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        PerPage = maxInARow * maxInACol;
        int totalPages = Mathf.CeilToInt((float)numberOfLevels / PerPage);
        LoadPanels(totalPages);

        levelSel = Camera.main.GetComponent<LevelSelect>();
        int CompletedLevels = PlayerPrefs.GetInt("CompletedLevels"); //level progression
        int levelReached = CompletedLevels + 1;

        //LevelSelect LvlButton = LevelButtonArr.AddComponent<LevelSelect>();

        Debug.Log(levelButtons);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                GameObject img = levelButtons[i].gameObject.transform.GetChild(0).gameObject;
                img.GetComponent<Image>().color = new Color32(255,255,225,100);
                levelButtons[i].GetComponent<Button>().interactable = false;
            }
        }


    }

    // Total panels
    void LoadPanels(int numberOfPanels)
    {
        GameObject panelClone = Instantiate(levelHolder) as GameObject;
        PageSwiper swiper = levelHolder.AddComponent<PageSwiper>();
        swiper.totalPages = numberOfPanels;

        for (int i = 1; i <= numberOfPanels; i++)
        {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Page-" + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
            SetUpGrid(panel);
            int numberOfIcons = i == numberOfPanels ? numberOfLevels - currentLevelCount : PerPage;
            LoadIcons(numberOfIcons, panel, numberOfLevels);
        }
        Destroy(panelClone);
    }

    //Grid for the icons / loading icon / Number of level
    void SetUpGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = iconSpacing;
    }
    void LoadIcons(int numberOfIcons, GameObject parentObject, int numberOfLevels)
    {
        for (int i = 1; i <= numberOfIcons; i++)
        {

            currentLevelCount++;
            GameObject icon = Instantiate(levelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Level_" + currentLevelCount;
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText(currentLevelCount.ToString());
            levelButtons[currentLevelCount - 1] = icon;

        }

    }

}
