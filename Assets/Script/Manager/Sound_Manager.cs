using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager instance;

    [SerializeField] Sound[] sound = null;
    [SerializeField] AudioSource BGM_Source;
    [SerializeField] AudioSource SFX_Source;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void BGM_Sound(string P_Music)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (P_Music == sound[i].name)
            {
                BGM_Source.clip = sound[i].clip;
                BGM_Source.Play();
            }
        }
    }

    public void SFX_Sound(string S_Music)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (S_Music == sound[i].name)
            {
                SFX_Source.clip = sound[i].clip;
                SFX_Source.Play();
            }
        }
    }

    public void Sound_Volume(float volume)
    {
        BGM_Source.volume = volume;
    }

    public void SFX_Sound_Volume(float volume)
    {
        SFX_Source.volume = volume;
    }
}
