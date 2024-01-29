using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Joke2Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; }

    public int OccurrenceWeight { get; private set; }

    public UnityEvent onJokeStarted { get; private set; }

    public UnityEvent onJokeCompleted { get; private set; }

    public GameObject thing;

    [Header("wait times")]
    public float waitVolunteerLine = 6f;
    public float waitNeverMind = 3f;

    public AudioSource joke2Source;
    public AudioSource joke2Response;

    private void Start()
    {
        //run();
    }

    public Joke2Script()
    {
        ButtonText = "I?m gonna need a volunteer for this one.";
        OccurrenceWeight = 3;

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }


    public void run()
    {

        onJokeStarted.Invoke();

        StartCoroutine(Joke2Sequence());

    }

    IEnumerator Joke2Sequence()
    {

        yield return StartCoroutine(TellJoke2());

    }

    IEnumerator TellJoke2()
    {
        //play audio of "i'm gonna need volunteer"
        joke2Source.Play();

        yield return new WaitForSeconds(6);

        //play audio "never mind then"
        joke2Response.Play();
        yield return new WaitForSeconds(3);
        

        onJokeCompleted.Invoke();
    }
}
