using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke4Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    [Header("Wait times")]
    public float waitForJoke = 4f;
    public float waitForChair = 2f;

    public AudioSource joke4Source;
    public AudioSource chairSource;

    //You can add any number of fields to this as needed.

    public Joke4Script()
    {
        ButtonText = "So you come around here often?"; //put the text for the prompt button here
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
        StartCoroutine(Joke4Sequence());
    }

    

    IEnumerator Joke4Sequence()
    {

        yield return StartCoroutine(TellJoke4());

    }

    IEnumerator TellJoke4()
    {

        joke4Source.Play();

        yield return new WaitForSeconds(waitForJoke);

        chairSource.Play();

        yield return new WaitForSeconds(waitForChair);
        
        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }
}
