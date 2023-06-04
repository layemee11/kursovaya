using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public float triggerX; // Координата X, при достижении которой срабатывает катсцена

    private void Update()
    {
        if (transform.position.x >= triggerX)
        {
            StartCutscene();
        }
    }

    private void StartCutscene()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.DisableMovement();

        // Воспроизведение анимации или последовательности катсцены
        Debug.Log("Катсцена началась...");

        // Загрузка следующей сцены
        SceneManager.LoadScene("Level 2");
    }
}
