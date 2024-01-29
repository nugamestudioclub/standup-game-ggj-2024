using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke3Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    [Header("You know what's crazy?")]
    public float youKnowWhatsCrazyWait = 3f;
    public float goCrazyFadeIn = 3f;
    public float goCrazyWait = 12f;

    public AudioSource crazySource;
    public AudioSource crazyMusic;


    //You can add any number of fields to this as needed.

    public Joke3Script()
    {
        ButtonText = "You know whats crazy?"; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    //for testing
    void Start()
    {
        //run();
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke3Sequence());
    }

    IEnumerator Joke3Sequence()
    {

        yield return StartCoroutine(TellJoke3());

    }

    IEnumerator TellJoke3()
    {
        //play audio "You know what's crazy?"
        crazySource.Play();

        yield return new WaitForSeconds(youKnowWhatsCrazyWait);

        //play audio of going crazy, play video of going crazy
        crazyMusic.Play();

        crazyMusic.volume = 0f;
        float timeStamp = 0f;
        while (timeStamp < goCrazyFadeIn)
        {
            crazyMusic.volume = (timeStamp / goCrazyFadeIn) * 0.8f;
            timeStamp += Time.deltaTime;
            yield return null;
        }

        //any programming of the player going crazy

        yield return new WaitForSeconds(goCrazyWait);

        crazyMusic.Stop();

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }
}
