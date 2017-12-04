using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartController : MonoBehaviour
{
    public GameObject kb;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("spawnRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnRoutine()
    {
        yield return new WaitForSeconds(3);
        Instantiate(kb, transform.position, Quaternion.identity);
        StopCoroutine("spawnRoutine");
    }
}
