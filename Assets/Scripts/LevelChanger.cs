using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    private Animator anim;

    public Vector3 position;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Level 2");
    }
}
