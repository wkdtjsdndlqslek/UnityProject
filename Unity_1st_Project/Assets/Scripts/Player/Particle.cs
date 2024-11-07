using System.Collections;
using UnityEngine;

public class Particle : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}

