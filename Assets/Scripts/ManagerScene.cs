using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScene : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject winBar;

    public BoolVariable isPaused;
    public FloatVariable winBarValue;
    public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(isPaused._value);
        winPanel.SetActive(false);
    }
    void Update()
    {
        winBar.GetComponent<Image>().fillAmount = winBarValue._value;
    }

    public void Pause()
    {
        pausePanel.SetActive(isPaused._value);
    }

}
