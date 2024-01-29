using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke6Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    //You can add any number of fields to this as needed.

    [Header("Wait times")]
    public float joke6Wait = 6f;
    public float comicSansWait = 3f;

    public AudioSource joke6Source;

    public GameObject text;

    public Joke6Script()
    {
        ButtonText = "My favorite font is Comic Sans."; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    void Start()
    {
        //run();
        text.SetActive(false);
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke6Sequence());
    }

    IEnumerator Joke6Sequence()
    {

        yield return StartCoroutine(TellJoke6());

    }

    IEnumerator TellJoke6()
    {
        joke6Source.Play();

        yield return new WaitForSeconds(joke6Wait);

        text.SetActive(true);

        yield return new WaitForSeconds(comicSansWait);

        text.SetActive(false);

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }
}
