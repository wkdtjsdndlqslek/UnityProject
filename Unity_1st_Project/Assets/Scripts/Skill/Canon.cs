using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Lean.Pool;

public class Canon : MonoBehaviour
{
    public float _canonCooltime =30;
    public float CanonCooltime { get; set; }
    public float NoCoolDuration = 5f;
    public GameObject canonAimingArea;
    private bool isActive=false;
    public GameObject canonBall;
    public Transform canonPosition;
    public Transform muzzlePosition;
    public float StartCanonCooltime { get; set; }
    private Coroutine NoCoolCor = null;
    public Button shootCanonButton;

    private void Awake()
    {
        CanonCooltime = _canonCooltime;
        StartCanonCooltime=-CanonCooltime;
    }

    private void Start()
    {
        GameManager.Instance.Canon = this;
        shootCanonButton.onClick.AddListener(SkillOn);
    }

    private void Update()
    {
        Aiming();
    }

    private void SkillOn()
    {
        if (Time.time >= StartCanonCooltime + CanonCooltime)
        {
            isActive = !isActive;
            canonAimingArea.SetActive(isActive);
            StartCanonCooltime = Time.time;
        }
    }

    private void Aiming()
    {
        if (canonAimingArea.activeSelf==true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            canonAimingArea.transform.position =new Vector3(mousePos.x, canonAimingArea.transform.position.y, canonAimingArea.transform.position.z);
            if (canonAimingArea.transform.position.x<-3.61)
            {
                canonAimingArea.transform.position = new Vector3(-3.61f, canonAimingArea.transform.position.y);
            }
            else if (canonAimingArea.transform.position.x>8)
            {
                canonAimingArea.transform.position = new Vector3(8f, canonAimingArea.transform.position.y);
            }
            Vector2 fireDirection = canonAimingArea.transform.position-canonPosition.position;
            canonPosition.up = fireDirection;
            GameManager.Instance.aimArea = canonAimingArea.transform;
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        LeanPool.Spawn(canonBall, muzzlePosition.position, muzzlePosition.rotation);
        canonAimingArea.SetActive(false);
        isActive = false;
    }

    public void accessNoCool()
    {
        if (NoCoolCor != null)
        {
            StopCoroutine(NoCoolCor);
            NoCoolCor = null;
        }
        NoCoolCor = StartCoroutine(NoCool());
    }

    public IEnumerator NoCool()
    {
        CanonCooltime=0;
        yield return new WaitForSeconds(NoCoolDuration);
        CanonCooltime =_canonCooltime;
    }
}
