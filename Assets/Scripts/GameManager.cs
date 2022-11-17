using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }
    
    //resources

    public List<Sprite> playerSpites;
    public List<Sprite> weaponSprite;
    public List<int> weaponPrices;
    public List<int> xpTable;
    
    //references
    public player player;
    
    //public weapon weapon
    
    //loguc
    public int pesos;
    public int experience;

    //save state(progress)
    
    /*
     *int preferedSkin
     * int pesos
     * int experience
     * int weaponLevel
     * 
     */
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";
        
        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        //change skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //change weapon level

        Debug.Log("load state");

    }
    
}
