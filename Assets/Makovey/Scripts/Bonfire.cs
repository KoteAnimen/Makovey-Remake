using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
	public float minIntensity;
	public float maxIntensity;
	public float minInterval;
	public float maxInterval;
	public float minXPosition;
	public float maxXPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeLight());
    }
	
	IEnumerator ChangeLight()
	{
		while(true)
		{
			yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
			this.GetComponent<Light>().intensity = Random.Range(minIntensity, maxIntensity);
			this.transform.localPosition = new Vector3(Random.Range(minXPosition, maxXPosition), 0.17f, 22f);
		}
	}
	

    
}
