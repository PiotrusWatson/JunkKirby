using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Interface for basic state handling **/
public abstract class EveState{
	protected EvaController eva;

	public abstract void Tick();
	public virtual void Init () {

	}
	public virtual void OnStateEnter() {
	}
	public virtual void OnStateExit() {
	}

	public EveState(EvaController eva) {
		this.eva = eva;
	}
}
