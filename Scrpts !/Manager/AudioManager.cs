
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip itemPickup;
    AudioSource audioSource;
    //okay ive built out editors to easily add audios but who cares :sob: im just doing this its sooo uggy
    private bool isWalking = false;
    private float timer;
    private float nextWalkSoundTime;
    [SerializeField] float minTimeBetweenFootsteps = 0.2f;
    [SerializeField] float maxTimeBetweenFootsteps = 0.5f;
    [SerializeField] private float minPitch = 0.75f;

    [SerializeField] private float maxPitch = 1.25f;
    public List<AudioClip> walkingAudios;
    // Static instance of GameManager
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        // Check if Instance already exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject); // Enforce singleton pattern
        }
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
        nextWalkSoundTime = Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps);
        timer = 0;
    }
    void Update(){
        HandleWalk();
    }
    private void HandleWalk(){
        if(!isWalking) return;
        timer += Time.deltaTime;
        if(timer > nextWalkSoundTime){
            PlayRandomAudio(walkingAudios);
            timer = 0;
            nextWalkSoundTime = Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps);
        }
    }
    public void PlayAudio(AudioClip audio){
        if(audio == null){
            Debug.LogError("Error: AudioManager Doesn't Have This Audio");
        }
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(audio);
    }

    public void PlayRandomAudio(List<AudioClip> audioClips){
        PlayAudio(audioClips[Random.Range(0, audioClips.Count)]);
    }

    public void StartWalking(){
        isWalking = true;
    }
    public void StopWalking(){
        isWalking = false;
    }
    public void PlayItemPickUp(){
        PlayAudio(itemPickup);
    }
}

