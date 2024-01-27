using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<muerte>().TomarDaño(20);
    }
}
