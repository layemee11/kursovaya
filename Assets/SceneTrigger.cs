using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public float triggerX; // ���������� X, ��� ���������� ������� ����������� ��������

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

        // ��������������� �������� ��� ������������������ ��������
        Debug.Log("�������� ��������...");

        // �������� ��������� �����
        SceneManager.LoadScene("Level 2");
    }
}
