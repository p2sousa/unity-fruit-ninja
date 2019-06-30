using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBombScript : MonoBehaviour
{
    public GameObject bomb;
    public float sizeScreen;
    public float force;

    // Start is called before the first frame update
    public void Start()
    {
        Invoke("Generate", 1f);
    }

    // Update is called once per frame
    public void Update()
    {

    }

    private void Generate()
    {
        InvokeRepeating("GenerateGroupBomb", 1, 6f);
    }

    private void GenerateGroupBomb()
    {
        if (Random.Range(0, 6) > 2)
        {
            StartCoroutine("GenerateBomb");
        }
    }

    private IEnumerator GenerateBomb()
    {
        int number = Random.Range(0, 3);
        for (int i = 0; i < number; i++)
        {
            float random = Random.Range(-sizeScreen, sizeScreen);
            Vector3 position = new Vector3(random, transform.position.y, 0f);
            GameObject bombClone = Instantiate(
                bomb,
                position,
                Quaternion.identity
            ) as GameObject;

            AddForce(bombClone);
            AddTorque(bombClone);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void AddForce(GameObject bombClone)
    {
        bombClone.GetComponent<Rigidbody2D>().AddForce(
            new Vector2(0, force),
            ForceMode2D.Impulse
        );
    }

    private void AddTorque(GameObject bombClone)
    {
        bombClone.GetComponent<Rigidbody2D>().AddTorque(
            Random.Range(-20f, 20f)
        );
    }
}
