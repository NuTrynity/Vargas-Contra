using UnityEngine;

public class AudioComponent : MonoBehaviour
{
    public static AudioComponent instance;
    [SerializeField] private AudioSource audio_source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void play_sound(AudioClip sound, Transform transform, float volume)
    {
        AudioSource audio = Instantiate(audio_source, transform.position, Quaternion.identity);
        audio.clip = sound;
        audio.volume = volume;
        audio.Play();

        float clip_lenght = audio.clip.length;
        Destroy(audio, clip_lenght);
    }

    public void play_sound_array(AudioClip[] sounds, Transform transform, float volume)
    {
        int rng = Random.Range(0, sounds.Length);

        play_sound(sounds[rng], transform, volume);
    }
}
