using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke27Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    public AudioClip voicePrompt;

    public AudioClip audienceResponse;

    //You can add any number of fields to this as needed.

    public Joke27Script()
    {
        ButtonText = "Vomit"; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke27Sequence());
    }

    IEnumerator Joke27Sequence()
    {
        Debug.Log("tell the joke");

        yield return StartCoroutine(TellJoke27());

        Debug.Log("Joke 27 is completed");
    }

    IEnumerator TellJoke27()
    {
        GameObject audioLocation = new GameObject("AudioObject");
        audioLocation.transform.position = Camera.main.transform.position;
        AudioSource audioSource = audioLocation.AddComponent<AudioSource>();
        AudioSource backgroundAudioSource = audioLocation.AddComponent<AudioSource>();

        audioSource.clip = voicePrompt;
        audioSource.Play();

        yield return new WaitForSeconds(voicePrompt.length - 4f);

        backgroundAudioSource.clip = audienceResponse;
        backgroundAudioSource.volume = 1f;
        backgroundAudioSource.Play();

        yield return new WaitForSeconds(audienceResponse.length);

        Destroy(audioLocation, 0);

        yield return null;

        Debug.Log("Animation completed");

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }
}
