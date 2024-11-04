using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Button skill;
    public GameObject aimingArea;
    private bool isActive=false;
    public GameObject canonBall;
    public float canonSpeed =4f;

    private void Start()
    {
        skill.onClick.AddListener(SkillOn);
    }

    private void Update()
    {
        Aiming();
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }

    private void SkillOn()
    {
        isActive = !isActive;
        aimingArea.SetActive(isActive);
    }

    private void Aiming()
    {
        if (aimingArea.activeSelf==true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            aimingArea.transform.position =new Vector3(mousePos.x, aimingArea.transform.position.y, aimingArea.transform.position.z);
            if (aimingArea.transform.position.x<-3.61)
            {
                aimingArea.transform.position = new Vector3(-3.61f, aimingArea.transform.position.y);
            }
            else if (aimingArea.transform.position.x>8)
            {
                aimingArea.transform.position = new Vector3(8f, aimingArea.transform.position.y);
            }
        }
    }

    private void Fire()
    {
        canonBall.SetActive(true);
        Vector3 canonBallRotation = (aimingArea.transform.position-canonBall.transform.position).normalized;
        canonBall.transform.rotation =new Quaternion(canonBallRotation.x,canonBallRotation.y,canonBallRotation.z,0);
        canonBall.transform.Translate(canonBallRotation*canonSpeed*Time.deltaTime);
    }
}
