using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke17Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    public AudioClip[] audioClips;

    //You can add any number of fields to this as needed.

    public Joke17Script()
    {
        ButtonText = "Im literally going to explode"; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke17Sequence());
    }

    IEnumerator Joke17Sequence()
    {
        Debug.Log("tell the joke");

        yield return StartCoroutine(TellJoke17());

        Debug.Log("Joke 17 is completed");
    }

    IEnumerator TellJoke17()
    {
        GameObject audioLocation = new GameObject("AudioObject");
        audioLocation.transform.position = Camera.main.transform.position;
        AudioSource audioSource = audioLocation.AddComponent<AudioSource>();
        audioSource.clip = audioClips[0];
        audioSource.Play();

        yield return new WaitForSeconds(audioClips[0].length);


        audioSource.clip = audioClips[1];
        audioSource.Play();

        yield return new WaitForSeconds(audioClips[1].length);

        Destroy(audioLocation);


        yield return null;

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }

    private void Start()
    {
        run();
    }
}
