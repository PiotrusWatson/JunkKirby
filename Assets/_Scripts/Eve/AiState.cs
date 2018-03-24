using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Interface for basic state handling **/
public abstract class AiState{
	protected GameObject AI;

	public abstract void Tick();
	public virtual void Init () {

	}
	public virtual void OnStateEnter() {
	}
	public virtual void OnStateExit() {
	}

	public AiState(GameObject AI) {
		this.AI = AI;
	}
}
