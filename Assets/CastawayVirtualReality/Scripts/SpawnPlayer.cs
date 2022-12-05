using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject refToSpawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        refToSpawnedObject.transform.position = transform.position;
    }

   
}
