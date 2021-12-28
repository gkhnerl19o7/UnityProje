using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Menu : MonoBehaviour
{
    public AudioSource muzik;
    public TextMeshProUGUI lbl_ses;
    public int level;
    private void Start()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else level = 1;   
    }
    void update() 
    {
        seskontrol();
       
    }
    
    public void seskontrol() 
    {
        if (muzik.mute==false)
        {
            lbl_ses.text = "Ses: Kapalý";
            muzik.mute = true;
        }
        else
        {
            lbl_ses.text = "Ses: Açýk";
            muzik.mute = false;
        }
    }
    
    public void oyna() 
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
}
