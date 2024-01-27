using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makePoop : MonoBehaviour
{
    public Transform poopSpwan;
    public GameObject poopPre;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(poopPre, poopSpwan.position, Quaternion.identity);
        }
    }
}
