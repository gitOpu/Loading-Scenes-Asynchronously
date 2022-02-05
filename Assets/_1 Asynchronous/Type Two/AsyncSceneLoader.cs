using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LoadingBy
{
    Distance, Trigger
}
public class AsyncSceneLoader : MonoBehaviour
{

    public LoadingBy loadingBy;
    public bool isLoaded;
    public Transform player;
    public float distance;

    void Update()
    {
        if(loadingBy == LoadingBy.Distance)
        {
             distance = Vector3.Distance(transform.position, player.position);
            if (distance <= 7)
            {
                if (!isLoaded)
                {
                    isLoaded = true;
                    SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
                }

            }
            else if (isLoaded)
            {
                SceneManager.UnloadSceneAsync(gameObject.name);
                isLoaded = false;
            }
        }
    }


}
