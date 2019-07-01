using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    private int numberVertex = 0;
    private bool pressButtonMouse = false;
    private LineRenderer line;
    public GameObject explosion;
    public AudioClip sound;
    private GameObject objSound;

    // Start is called before the first frame update
    public void Start()
    {
        line = GetComponent<LineRenderer>();
        objSound = GameObject.FindGameObjectWithTag("SoundBlade");
    }

    // Update is called once per frame
    [System.Obsolete]
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressButtonMouse = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            pressButtonMouse = false;
        }

        if (pressButtonMouse)
        {
            CreateLine();
        }
        else
        {
            DeleteLine();
        }
    }

    [System.Obsolete]
    private void CreateLine()
    {
        objSound.GetComponent<AudioSource>().clip = sound;
        objSound.GetComponent<AudioSource>().Play();

        line.SetVertexCount(numberVertex + 1);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        line.SetPosition(numberVertex, mousePosition);
        numberVertex++;

        BoxCollider2D linerCollider = gameObject.AddComponent<BoxCollider2D>();
        linerCollider.transform.position = line.transform.localPosition;
        linerCollider.size = new Vector2(0.1f, 0.1f);
    }

    [System.Obsolete]
    private void DeleteLine()
    {
        numberVertex = 0;
        line.SetVertexCount(0);

        BoxCollider2D[] linesCollider = GetComponents<BoxCollider2D>();

        for (int i = 0; i < linesCollider.Length; i++)
        {
            Destroy(linesCollider[i]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            GameObject explosionClone = Instantiate(
                explosion, 
                collision.transform.position, 
                Quaternion.identity
            ) as GameObject;

            Destroy(explosionClone, 5f);
            Destroy(collision.gameObject);
        }
    }
}
