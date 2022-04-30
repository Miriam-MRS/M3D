using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //SerializeField var is private but shows up in editor
    [SerializeField] Image musicOnIcon;
    [SerializeField] Image musicOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        //check if there are saved data from prev game session
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
           Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if (muted==false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    //set on/off icon
    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
        }
        else
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }
    }
 
    private void Load()
    {
        //if muted==1 -> true
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        //convert from bool to int
        PlayerPrefs.SetInt("muted", muted ? 1 : 0); 
    }
}
