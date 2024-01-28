using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke16Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    public AudioClip[] audioClips;

    //You can add any number of fields to this as needed.

    public Joke16Script()
    {
        ButtonText = "So, today is opposite day."; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke16Sequence());
    }

    IEnumerator Joke16Sequence()
    {
        Debug.Log("tell the joke");

        yield return StartCoroutine(TellJoke16());

        Debug.Log("Joke 16 is completed");
    }

    IEnumerator TellJoke16()
    {
        GameObject audioLocation = new GameObject("AudioObject");
        audioLocation.transform.position = Camera.main.transform.position;
        AudioSource audioSource = audioLocation.AddComponent<AudioSource>();
        audioSource.clip = audioClips[0];
        audioSource.Play();

        yield return new WaitForSeconds(audioClips[0].length - 2);

        Destroy(audioLocation);

        Camera camera = Camera.main;

        camera.transform.Rotate(Vector3.right, 180f);

        yield return new WaitForSeconds(5);

        camera.transform.Rotate(Vector3.right, -180f);


        yield return null;

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }

   
}
