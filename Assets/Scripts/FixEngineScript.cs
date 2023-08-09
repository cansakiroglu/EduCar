using UnityEngine;
using UnityEngine.UI;

public class FixEngineScript : MonoBehaviour
{
    public Collider playerCollider;
    public Collider fixEngineCollider;
    public GameObject car;
    public Slider slider;
    public Text interactText;

    private PrometeoCarController controller;
    private float time = -1;

    private void Start()
    {
        controller = car.GetComponent<PrometeoCarController>();
    }

    private void Update()
    {
        if (playerCollider.bounds.Intersects(fixEngineCollider.bounds) && PlayerPrefs.GetInt("EngineBroken") == 1)
        {
            interactText.text = "Press [F] to fix the engine";
            if (Input.GetKeyDown(KeyCode.F))
            {
                time = Time.time;
                slider.transform.gameObject.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("EngineBroken") == 1)
        {
            interactText.text = "";
        }
        if (time != -1)
        {
            slider.value = (Time.time - time) / 2f * 1.94f;
            if (Time.time - time >= 2f)
            {
                slider.transform.gameObject.SetActive(false);
                time = -1;
                controller.FixEngine();
            }
        }
    }

    
}
