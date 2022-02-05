using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBigObject : MonoBehaviour
{

    public GameObject prefab;
    private void Awake()
    {
            for(int i = 0; i< 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                Instantiate(prefab, new Vector3(j, 0, i), Quaternion.identity);
            }
        }
    }


}
