using UnityEngine;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
    public Button skill;
    public GameObject aimingArea;
    private bool isActive=false;
    public GameObject canonBall;
    public Transform canon;
    public Transform muzzle;

    private void Start()
    {
        skill.onClick.AddListener(SkillOn);
    }

    private void Update()
    {
        Aiming();
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
            Vector2 fireDirection = aimingArea.transform.position-canon.position;
            canon.up = fireDirection;
            GameManager.Instance.aimArea = aimingArea.transform;
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        Instantiate(canonBall,muzzle);
        aimingArea.SetActive(false);
        isActive = false;
    }
}
