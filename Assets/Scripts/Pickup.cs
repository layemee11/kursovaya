using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    public PlayableDirector cutsceneDirector;
    public GameObject Son;
    public GameObject NoSon; // Новый объект NoSon
    private PlayerController playerController;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(slotButton, inventory.slots[i].transform);
                    Destroy(gameObject);
                }
            }
            cutsceneDirector.Play();
            if (Son != null)
            {
                Son.SetActive(false);
                NoSon.SetActive(true);
            }
        }
    }
}
