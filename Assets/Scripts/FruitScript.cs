using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public GameObject watermelonLeft;
    public GameObject watermelonRight;
    public AudioClip sound;
    private GameObject objSound;

    // Start is called before the first frame update
    public void Start()
    {
        objSound = GameObject.FindGameObjectWithTag("SoundFruitCut");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            objSound.GetComponent<AudioSource>().clip = sound;
            objSound.GetComponent<AudioSource>().Play();

            GameObject left = GenerateWatermelonLeft();
            GameObject right = GenerateWatermelonRight();

            ApplyForce(left, -2f, -2f, ForceMode2D.Impulse);
            ApplyForce(right, 2f, 2f, ForceMode2D.Impulse);

            ApplyTorque(left, ForceMode2D.Impulse);
            ApplyTorque(right, ForceMode2D.Impulse);

            Destroy(gameObject);
        }
    }

    private GameObject GenerateWatermelonLeft()
    {
        Vector3 position = new Vector3(transform.position.x - 2f, transform.position.y, 0f);

        GameObject obj = Instantiate(
            watermelonLeft,
            position,
            watermelonLeft.transform.rotation
        ) as GameObject;

        return obj;
    }

    private GameObject GenerateWatermelonRight()
    {
        GameObject obj = Instantiate(
            watermelonRight,
            transform.position,
            Quaternion.identity
        ) as GameObject;

        return obj;
    }

    private void ApplyForce(GameObject obj, float x, float y, ForceMode2D force)
    {
        Vector2 vector = new Vector2(x, y);

        obj.GetComponent<Rigidbody2D>()
            .AddForce(vector, force);
    }

    private void ApplyTorque(GameObject obj, ForceMode2D force)
    {
        obj.GetComponent<Rigidbody2D>()
            .AddTorque(Random.Range(-2f, 2f), force);
    }
}
