using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : MonoBehaviour
{
    [SerializeField]
    private int _hungerLvl;
    [SerializeField]
    private int _expLvl;
    [SerializeField]
    private int _slimeLvl;
    private int _colour; //0G, 1B, 2R (Slime colour)
    [SerializeField]
    private string _name;

    public static Slime instance { get; private set; }

    private void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
            LoadState();
            updateState();
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void updateState() {
        InvokeRepeating("decreaseHunger", 10f, 10f);
    }

    void decreaseHunger() {
        hungerLvl -= 2; // Subtract 2 from hunger every 10 seconds
    }

    public int expLvl {
        get { return _expLvl; }
        set {
            _expLvl = value;
            if (_expLvl >= 100) {
                _expLvl = 0;
                slimeLvl += 1;
            }
            SaveState();
        }
    }

    public int hungerLvl {
        get { return _hungerLvl; }
        set {
            _hungerLvl = value;
            if (_hungerLvl > 100) {
                _hungerLvl = 100;
            } else if (_hungerLvl < 0) {
                _hungerLvl = 0;
            }
            SaveState();
        }
    }

    public string name {
        get { return _name; }
        set {
            _name = value;
            SaveState();
        }
    }

    public int slimeLvl {
        get { return _slimeLvl; }
        set {
            _slimeLvl = value;
            if (_slimeLvl < 1) {
                _slimeLvl = 1;
            }
            SaveState();
        }
    }

    public int colour {
        get { return _colour; }
        set {
            _colour = value;
            SaveState();
        }
    }

    void SaveState() {
        PlayerPrefs.SetInt("hungerLvl", _hungerLvl);
        PlayerPrefs.SetInt("expLvl", _expLvl);
        PlayerPrefs.SetInt("slimeLvl", _slimeLvl);
        PlayerPrefs.SetInt("colour", _colour);
        PlayerPrefs.SetString("name", _name);
        PlayerPrefs.Save();
    }

    void LoadState() {
        _hungerLvl = PlayerPrefs.GetInt("hungerLvl", 100);
        _expLvl = PlayerPrefs.GetInt("expLvl", 0);
        _slimeLvl = PlayerPrefs.GetInt("slimeLvl", 1);
        _colour = PlayerPrefs.GetInt("colour", 0);
        _name = PlayerPrefs.GetString("name", "");
    }
}