using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance { get; private set; }

    private void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
            LoadState();
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public List<Item> items = new List<Item>();
    public int balance = 0;

    public bool Add(Item item) {
        if (items.Count > 19) {
            return false;
        }
        items.Add(item);
        SaveState();
        return true;
    }

    public void Remove(Item item) {
        items.Remove(item);
        SaveState();
    }

    public int Count(Item item) {
        int count = 0;
        foreach (var i in items) {
            if (item.type == i.type) count++;
        }
        return count;
    }

    public string[] ToStringArray() {
        string[] result = new string[items.Count];
        int j = 0;
        foreach (var i in items) result[j++] = i.ToString();
        return result;
    }

    public void SetFromStringArray(string[] input) {
        items = new List<Item>();
        for (int i = 0; i < input.Length; i++) items.Add(new Item(input[i]));
        SaveState();
    }

    public void OnDeath() {
        items = new List<Item>();
        balance = 100;
        SaveState();
    }

    void SaveState() {
        PlayerPrefs.SetInt("balance", balance);
        PlayerPrefs.SetInt("itemCount", items.Count);
        for (int i = 0; i < items.Count; i++) {
            PlayerPrefs.SetString($"item_{i}", items[i].ToString());
        }
        PlayerPrefs.Save();
    }

    void LoadState() {
        balance = PlayerPrefs.GetInt("balance", 100);
        int itemCount = PlayerPrefs.GetInt("itemCount", 0);
        items = new List<Item>();
        for (int i = 0; i < itemCount; i++) {
            string itemData = PlayerPrefs.GetString($"item_{i}", "");
            if (!string.IsNullOrEmpty(itemData)) {
                items.Add(new Item(itemData));
            }
        }
    }
}