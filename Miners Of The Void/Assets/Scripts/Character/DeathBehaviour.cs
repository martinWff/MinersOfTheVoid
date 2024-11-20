using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBehaviour : MonoBehaviour
{
    public int backScene;

    public void OnDied()
    {
        PlayerMovementController controller = FindObjectOfType<PlayerMovementController>();
        if (controller != null)
        {
            controller.StartCoroutine(DeathEffect());
        }
        gameObject.SetActive(false);


    }
    private IEnumerator DeathEffect()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(backScene);

    }
}
