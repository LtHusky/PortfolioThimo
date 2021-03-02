using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class Video : MonoBehaviour
{ 
    // VARIABLES.
    public UnityEvent EndVideo;
    public double time;
    public double currentTime;
    public GameObject pauseplay;

    // FUNCTIONS.
    void Start()
    { // Set videoclip total time & get UI images.
        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }

    void Update()
    { // Call event when video ends.
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= time)
        {
            pauseplay.SetActive(false);
            EndVideo.Invoke();
        }
    }
}