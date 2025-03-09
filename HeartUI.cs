using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public GameObject heartPrefab; // Assign a heart image prefab in Inspector
    public Transform heartsParent; // UI panel where hearts will be stored

    private List<GameObject> hearts = new List<GameObject>();
    private int currentHealth;

    public void SetMaxHealth(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsParent);
            hearts.Add(heart);
        }
        currentHealth = maxHealth;
    }

    public void UpdateHealth(int health)
    {
        currentHealth = health;

        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }
}
