using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Mainmenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject progressMenu;
    public Image progressbarValue;

    List<AsyncOperation> sceneToLoad = new List<AsyncOperation>();
    private void Awake()
    {
        mainMenu.SetActive(true);
        progressMenu.SetActive(false);

    }
    public void StartGame()
    {
        progressMenu.SetActive(false);
        sceneToLoad.Add(SceneManager.LoadSceneAsync("Scene 2"));
        sceneToLoad.Add(SceneManager.LoadSceneAsync("Scene 3", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());
    }

     public IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for(int i = 0; i < sceneToLoad.Count; i++)
        {
            while (!sceneToLoad[i].isDone)
            {
                totalProgress += sceneToLoad[i].progress;
                progressbarValue.fillAmount = totalProgress / sceneToLoad.Count;
                yield return null;
            }
           
        }
    }
     
}
