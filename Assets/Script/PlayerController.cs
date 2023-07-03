using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float touchXDelta = 0;
    float newX = 0;
    public float xSpeed;
    public float limitX;
    Vector3 baslangýcnoktasý;
    public Animator anim;
    public GameObject player;
    public GameObject SpedB;
    void Awake()
    {
        baslangýcnoktasý = transform.position;
    }
    private void Start()
    {

    }

    void resetPlayer()
    {
        transform.position = baslangýcnoktasý;
    }
    void Update()
    {
        SwipCheck();


    }
    void SwipCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        else
        {
            touchXDelta = 0;
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Resle"))
        {
            resetPlayer();
        }
        else if (other.gameObject.CompareTag("SpeedBoost"))
        {
            SpedB.SetActive(true);
            runningSpeed = runningSpeed + 5;
            StartCoroutine(Slow());
        }
    }
    private IEnumerator Slow()
    {
        yield return new WaitForSeconds(2.0f);
        SpedB.SetActive(false);
        runningSpeed = runningSpeed -5;
    }


}
