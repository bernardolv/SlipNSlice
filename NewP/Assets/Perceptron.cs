﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TrainingSet
{
	public double[] input;
	public double output;
}

public class Perceptron : MonoBehaviour {

	public TrainingSet[] ts;
	double[] weights = {0, 0};
	double bias = 0;
	double totalError = 0;
	// Use this for initialization

	double DotProductBias(double[] v1, double[] v2){
		if (v1 == null || v2 == null)
			return -1;

		if (v1.Length != v2.Length)
			return -1;
		double d = 0;
		for(int x = 0; x < v1.Length; x++)
		{
			d += v1[x] * v2[x];
		}
		d += bias;

		return d;

	}

	double CalcOutput(int i)
	{
		double dp =DotProductBias(weights, ts[i].input);
		if(dp>0) return(1);
		return (0);
	}

	void UpdateWeights(int j){
		double error = ts[j].output - CalcOutput(j);
		totalError += Mathf.Abs((float)error);
		for (int i = 0; i<weights.Length; i++)
		{
			weights[i] = weights[i] + error*ts[j].input[i];
		}
		bias += error;
	}

	void InitialiseWeights(){
		for (int i = 0; i< weights.Length; i++){
			weights[i] = Random.Range(-1.0f, 1.0f);
		}
		bias = Random.Range(-1.0f,1.0f);
	}
	void Train(int epochs){
		InitialiseWeights();

		for (int e = 0; e < epochs; e++){
			totalError = 0;
			for (int t= 0; t<ts.Length; t++ ){
				UpdateWeights(t);
				Debug.Log("W1: " + (weights[0]) + " W2: " + (weights[1])+ " B " + bias);
			}
			Debug.Log("TOTAL ERROR: " + totalError);
		}
	}
	void Start () {
		Train(8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}