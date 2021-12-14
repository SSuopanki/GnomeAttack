using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelButton : MonoBehaviour
{
    private GameObject btn;
    private Button c_btn;
    private string btn_name;

    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject;
        c_btn = this.GetComponent<Button>();
        c_btn.onClick.AddListener(TaskOnClick);

        btn_name = btn.name;
    }

    void TaskOnClick()
    {
        PlayerPrefs.SetFloat("MusicVolume", SoundManager.ambientVolume);
        PlayerPrefs.SetFloat("fxVolume", SoundManager.fxVolume);
        PlayerPrefs.Save();
        Debug.Log ("Pressed level button");
        SceneManager.LoadScene(btn_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
