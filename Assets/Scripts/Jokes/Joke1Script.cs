using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke1Script : MonoBehaviour, JokeInterface
{

    // = "this joke is funny";
    // int occurrenceWeight
    // public string ButtonText { get => text; private set => text = value; }
    public string ButtonText { get; private set; }

    public int OccurrenceWeight { get; private set; }

    public UnityEvent onJokeStarted { get; private set; }

    public UnityEvent onJokeCompleted { get; private set; }


    [Header("Wait times")]
    public float waitForESound = 5f;

    public AudioSource eSource;


    public Joke1Script()
    {
        ButtonText = "E";
        OccurrenceWeight = 5;

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    void Start()
    {
        //run();
    }


    public void run()
    {

        onJokeStarted.Invoke();

        StartCoroutine(Joke1Sequence());

    }

    IEnumerator Joke1Sequence()
    {

        
        yield return StartCoroutine(TellJoke1());

    }

    IEnumerator TellJoke1()
    {

        //play E sound
        eSource.Play();

        yield return new WaitForSeconds(5); //or however long the audio is

        onJokeCompleted.Invoke();

        yield return null;
    }
}
