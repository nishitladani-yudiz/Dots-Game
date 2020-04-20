using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] toSpawn;
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Dot"))
        {
            Instantiate(toSpawn[Random.Range(0, 6)], new Vector2(col.transform.position.x, col.transform.position.y + 2f), Quaternion.identity);
        }
    }
}
