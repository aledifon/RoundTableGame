using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Lights GO (used for ActivateLights methods)
    [SerializeField] private float timeText;
    [SerializeField] private float timeImage;
    [SerializeField] private GameObject[] lights;

    // Renderer Cube Material (used for Fading method)
    [SerializeField] private Renderer rendCube;

    // Canvas Text vars (used for Writting Machine method)
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private string textToShow;

    // Silent hill test
    [SerializeField] private Image image;
    private AudioSource audioSource;

    // Coroutines flags
    private bool isCoroutineRunning;

    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;


    private void Awake()
    {
        //textToShow = "Are you ready for an easy script steguitas ;-)?";
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Start()
    {
        //CalculateNumber();
        //StartCoroutine("FirstCoroutine");         //Coroutine call
        //StartCoroutine(nameof(FirstCoroutine));     //Coroutine call (Prefered call)
        //StartCoroutine(nameof(ActivateLights));
        //StartCoroutine(nameof(ActivateLightsByIndex));
        Debug.Log("HOLA");
        yield return new WaitForSeconds(1);
        Debug.Log("I'm a Jedi");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(nameof(Move));
        }        
        else if (Input.GetKeyDown(KeyCode.F))
        {
            StartAudio();
            StartCoroutine(nameof(ShowText));   // Call to the coroutine
            StartCoroutine(nameof(ShowImage));   // Call to the coroutine 
            //isCoroutineRunning = true;                            
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            if (isCoroutineRunning)
            {
                StopCoroutine(nameof(ActivateLightsByIndex));   // Freeze the coroutine (Also posible to freeze all the coroutines StopAllCoroutines())
                isCoroutineRunning = false;                     // Set to false at ending
            }

        }            
    }
    
    IEnumerator FirstCoroutine()
    {
        Debug.Log("Hola");
        yield return new WaitForSeconds(timeText);     // The method will arrive till here in the 1st frame and will wait for 1s
        Debug.Log(timeText + " seconds after --> I'm a jedi");                // The courutine will continue its execution from this point
                                                // in the next frame
        yield return new WaitForSeconds(timeText);
        Debug.Log(timeText + " seconds after");        // in the next frame
    }
    IEnumerator ActivateLights()
    {
        lights[0].SetActive(true);
        yield return new WaitForSeconds(timeText);
        lights[1].SetActive(true);
        yield return new WaitForSeconds(timeText);
        lights[2].SetActive(true);
    }
    IEnumerator ActivateLightsByIndex()
    {
        //isCoroutineRunning = true;                      // Set to true at starting
        //for (int i = 0; i <= lights.Length-1; i++)
        //{
        //    lights[i].SetActive(true);
        //    yield return new WaitForSeconds(time);
        //}
        foreach (var light in lights)
        {
            light.SetActive(true);
            yield return new WaitForSeconds(timeText);
        }
        //isCoroutineRunning = false;                     // Set to false at ending
    }
    IEnumerator Fade()
    {
        // Getting the Cube Color material
        Color c = rendCube.material.color;
        for(float alpha = 1; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            rendCube.material.color = c;
            yield return new WaitForSeconds(timeText);
        }
        isCoroutineRunning = false;
    }
    IEnumerator ShowText()
    {        
        textUI.text = "";   // Clean the shown text
        foreach(char c in textToShow)
        {
            textUI.text += c;
            yield return new WaitForSeconds(timeText);
        }
        //StartCoroutine(nameof(ShowImage));  // Call to the coroutine                
    }

    IEnumerator ShowImage()
    {
        // Getting the Image Color material
        Color color = image.color;
        for (float alpha = 0; alpha <= 1; alpha += 0.1f)
        {
            color.a = alpha;
            image.color = color;
            yield return new WaitForSeconds(timeImage);
        }
        // In order to assure the alpha takes its max. value
        color.a = 1;
        image.color = color;
        Debug.Log(image.color.a);
    }
    IEnumerator Move()
    {
        float distance = Vector3.Distance(player.position, target.position);

        // As long as my target point has not been reached
        while(distance >= Mathf.Epsilon)
        {
            player.position = Vector3.MoveTowards(player.position, target.position, speed * Time.deltaTime);
            distance = Vector3.Distance(player.position, target.position);
            yield return null;
        }
    }
    void StartAudio()
    {
        //Start playing the audio
        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
