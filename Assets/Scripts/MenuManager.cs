using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject play;
    public List<Scene> listscenes;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem.SetSelectedGameObject(play);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
