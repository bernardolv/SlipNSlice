using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

	public GameObject paddle;
	public GameObject paddle2;
	public GameObject ball;
	Rigidbody2D brb;
	float yvel;
	float yvel2;
	float paddleMinY = 8.8f;
	float paddleMaxY = 17.4f;
	float paddleMaxSpeed = 15;
	public float numSaved = 0;
	public float numMissed = 0;

	ANN ann;
	ANN ann2;

	// Use this for initialization
	void Start () {
		ann = new ANN(6, 1, 1, 4, 0.11);
		brb = ball.GetComponent<Rigidbody2D>();	
		ann2 = new ANN(6,1,1,4, 0.11);	
	}

	List<double> Run(double bx, double by, double bvx, double bvy, double px, double py, double pv, bool train, ANN myann)
	{
		List<double> inputs = new List<double>();
		List<double> outputs = new List<double>();
		inputs.Add(bx);
		inputs.Add(by);
		inputs.Add(bvx);
		inputs.Add(bvy);
		inputs.Add(px);
		inputs.Add(py);
		outputs.Add(pv);
		if(train)
			return (myann.Train(inputs,outputs));
		else
			return (myann.CalcOutput(inputs,outputs));
	}
	
	// Update is called once per frame
	void Update () {
		float posy = Mathf.Clamp(paddle.transform.position.y+(yvel*Time.deltaTime*paddleMaxSpeed),
			                     paddleMinY,paddleMaxY);
		float posy2 = Mathf.Clamp(paddle2.transform.position.y+(yvel2*Time.deltaTime*paddleMaxSpeed),
			                     paddleMinY,paddleMaxY);
		paddle.transform.position = new Vector3(paddle.transform.position.x, posy, paddle.transform.position.z);
		paddle2.transform.position = new Vector3(paddle2.transform.position.x, posy2, paddle2.transform.position.z);

		List<double> output = new List<double>();
		List<double> output2 = new List<double>();
		int layerMask = 1 << 9;
		RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, brb.velocity, 1000, layerMask);
        
        if (hit.collider != null) 
        {
        	if(hit.collider.gameObject.tag == "tops") //reflect off top
        	{
				Vector3 reflection = Vector3.Reflect(brb.velocity,hit.normal);
        		hit = Physics2D.Raycast(hit.point, reflection, 1000, layerMask);
        	}

	        if(hit.collider != null && hit.collider.gameObject.tag == "backwall")
	        {
			    float dy = (hit.point.y - paddle.transform.position.y);
			        
				output = Run(ball.transform.position.x, 
									ball.transform.position.y, 
									brb.velocity.x, brb.velocity.y, 
									paddle.transform.position.x,
									paddle.transform.position.y, 
									dy,true, ann);
				yvel = (float) output[0];
				yvel2 = 0;
			}
			if(hit.collider != null && hit.collider.gameObject.tag == "frontwall")
	        {
			    float dy = (hit.point.y - paddle2.transform.position.y);
			        
				output2 = Run(ball.transform.position.x, 
									ball.transform.position.y, 
									brb.velocity.x, brb.velocity.y, 
									paddle2.transform.position.x,
									paddle2.transform.position.y, 
									dy,true, ann2);
				yvel2 = (float) output2[0];
				yvel = 0;
			}

        }
        else
        	yvel = 0;
	}
}
