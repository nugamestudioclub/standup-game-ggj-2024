using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke7Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    //You can add any number of fields to this as needed.

    [Header("Wait times")]
    public float joke7Wait = 5f;
    public float leaveWait = 6f;

    public AudioSource joke7Source;
    public AudioSource leaveSource;

    public Joke7Script()
    {
        ButtonText = "How about we get someone from the crowd"; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    void Start()
    {
        //run();
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke7Sequence());
    }

    IEnumerator Joke7Sequence()
    {

        yield return StartCoroutine(TellJoke7());

    }

    IEnumerator TellJoke7()
    {
        joke7Source.Play();

        yield return new WaitForSeconds(joke7Wait);

        leaveSource.Play();

        yield return new WaitForSeconds(leaveWait);

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }
}
