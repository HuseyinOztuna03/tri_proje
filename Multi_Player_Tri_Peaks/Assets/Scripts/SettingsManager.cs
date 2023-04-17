using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this; // In first scene, make us the singleton.
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
    //        //instance = this;
    //        //DontDestroyOnLoad(this.gameObject);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(3840, 2160, true);
    }

    public void LoadTriPeaks()
    {
        SceneManager.LoadScene("TriPeaks");
    }
}

   
