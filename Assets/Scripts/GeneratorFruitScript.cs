using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorFruitScript : MonoBehaviour
{
    public GameObject watermelon;
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
        InvokeRepeating("GenerateGroupFruit", 1, 6f);
    }

    private void GenerateGroupFruit()
    {
        StartCoroutine("GenerateFruit");
    }

    private IEnumerator GenerateFruit()
    {
        for (int i = 0; i < 5; i++)
        {
            float random = Random.Range(-sizeScreen, sizeScreen);
            Vector3 position = new Vector3(random, transform.position.y, 0f);
            GameObject watermelonClone = Instantiate(
                watermelon, 
                position, 
                Quaternion.identity
            ) as GameObject;
                
            AddForce(watermelonClone);
            AddTorque(watermelonClone);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void AddForce(GameObject fruitClone)
    {
        fruitClone.GetComponent<Rigidbody2D>().AddForce(
            new Vector2(0, force),
            ForceMode2D.Impulse
        );
    }

    private void AddTorque(GameObject fruitClone)
    {
        fruitClone.GetComponent<Rigidbody2D>().AddTorque(
            Random.Range(-20f, 20f)
        );
    }

}
