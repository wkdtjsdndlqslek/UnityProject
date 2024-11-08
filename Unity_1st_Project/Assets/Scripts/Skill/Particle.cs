using System.Collections;
using UnityEngine;
using Lean.Pool;

public class Particle : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.2f);
        LeanPool.Despawn(gameObject);
    }
}

