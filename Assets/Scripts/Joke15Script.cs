using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke15Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    public AudioClip[] audioClips;

    //You can add any number of fields to this as needed.

    public Joke15Script()
    {
        ButtonText = "What did the barber do during the sack of Rome by the Vandals in 455 A.D.?"; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke15Sequence());
    }

    IEnumerator Joke15Sequence()
    {
        Debug.Log("tell the joke");

        yield return StartCoroutine(TellJoke15());

        Debug.Log("Joke 15 is completed");
    }

    IEnumerator TellJoke15()
    {
        GameObject audioLocation = new GameObject("AudioObject");
        audioLocation.transform.position = Camera.main.transform.position;
        AudioSource audioSource = audioLocation.AddComponent<AudioSource>();
        audioSource.clip = audioClips[0];
        audioSource.Play();

        yield return new WaitForSeconds(audioClips[0].length - 2);

        //Unimplemented germanic invader entering dragging the corpse of a romanian centurion

        audioSource.clip = audioClips[1];
        audioSource.pitch = 1.1f;
        audioSource.Play();


        yield return new WaitForSeconds(audioClips[1].length);
        yield return new WaitForSeconds(1);


        Destroy(audioLocation);

        yield return null;

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }

}
