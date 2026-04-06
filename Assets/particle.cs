using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateAndDeactivate());
    }

    // Update is called once per frame
  
    IEnumerator ActivateAndDeactivate()
    {
        // Activate this object
        gameObject.SetActive(true);

        // Wait for 0.1 seconds
        yield return new WaitForSeconds(1f);

        // Deactivate this object
        gameObject.SetActive(false);
    }
}
