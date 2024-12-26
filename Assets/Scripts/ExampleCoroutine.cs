using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCoroutine : MonoBehaviour
{    
    void Start()
    {
        // Execute coroutines in parallel
        //StartCoroutine(nameof(FirstCoroutine));
        //StartCoroutine(nameof(SecondCoroutine));

        StartCoroutine(nameof(RunInSequence));
    }
    IEnumerator RunInSequence()
    {
        // Execute coroutines in sequence
        yield return StartCoroutine(nameof(FirstCoroutine));
        yield return StartCoroutine(nameof(SecondCoroutine));
    }
    IEnumerator FirstCoroutine()
    {
        Debug.Log("Hola");
        yield return new WaitForSeconds(1);     // The method will arrive till here in the 1st frame and will wait for 1s
        Debug.Log("I'm a jedi");                // The courutine will continue its execution from this point
                                                                              // in the next frame        
    }
    IEnumerator SecondCoroutine()
    {
        Debug.Log("y me llamo");
        yield return new WaitForSeconds(1);     // The method will arrive till here in the 1st frame and will wait for 1s
        Debug.Log("Alejandro");                // The courutine will continue its execution from this point
                                                // in the next frame        
    }
}
