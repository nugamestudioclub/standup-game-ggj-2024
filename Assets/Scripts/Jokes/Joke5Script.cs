using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke5Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    //You can add any number of fields to this as needed.

    [Header("Wait times")]
    public float forteWait = 5f;
    public float sadViolinWait = 3f;

    public AudioSource forteSource;
    public AudioSource violinSource;

    public Joke5Script()
    {
        ButtonText = "I?m not great at making music puns. They?re not exactly my forte."; //put the text for the prompt button here
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
        StartCoroutine(Joke5Sequence());
    }

    IEnumerator Joke5Sequence()
    {

        

        yield return StartCoroutine(TellJoke5());

    }

    IEnumerator TellJoke5()
    {
        forteSource.Play();

        yield return new WaitForSeconds(forteWait);

        violinSource.Play();

        yield return new WaitForSeconds(sadViolinWait);

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }
}
