using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerBehaviour : MonoBehaviour {

	public virtual bool Init(){
		return true;
	}

	public virtual void AfterLoading(){
	}
}
