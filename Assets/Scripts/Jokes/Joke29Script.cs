using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke29Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    public AudioClip voicePrompt;

    public AudioClip voiceResponse;

    public AudioClip tragicMusic;

    //You can add any number of fields to this as needed.

    public Joke29Script()
    {
        ButtonText = "Talk about life"; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke29Sequence());
    }

    IEnumerator Joke29Sequence()
    {
        Debug.Log("tell the joke");

        yield return StartCoroutine(TellJoke29());

        Debug.Log("Joke 29 is completed");
    }

    IEnumerator TellJoke29()
    {
        GameObject audioLocation = new GameObject("AudioObject");
        audioLocation.transform.position = Camera.main.transform.position;
        AudioSource audioSource = audioLocation.AddComponent<AudioSource>();
        AudioSource backgroundAudioSource = audioLocation.AddComponent<AudioSource>();

        audioSource.clip = voicePrompt;
        audioSource.Play();

        backgroundAudioSource.clip = tragicMusic;
        backgroundAudioSource.volume = 0;
        backgroundAudioSource.Play();

        float timeToAnimate = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < timeToAnimate)
        {

            elapsedTime += Time.deltaTime;
            backgroundAudioSource.volume += (0.1f - backgroundAudioSource.volume) / 2000;

            yield return null;
        }

        yield return new WaitForSeconds(voicePrompt.length - 2 * timeToAnimate - 3.2f);

        elapsedTime = 0f;

        while (elapsedTime < timeToAnimate)
        {

            elapsedTime += Time.deltaTime;
            backgroundAudioSource.volume += -backgroundAudioSource.volume / 2000;

            yield return null;
        }

        backgroundAudioSource.volume = 0;

        yield return new WaitForSeconds(3);

        backgroundAudioSource.volume = 0.15f;

        audioSource.clip = voiceResponse;
        audioSource.Play();
        yield return new WaitForSeconds(voiceResponse.length);
        Destroy(audioLocation, 0);

        yield return null;

        Debug.Log("Animation completed");

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }
}
