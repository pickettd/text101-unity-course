using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom
	}
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	
	}

	// Update is called once per frame
	void Update () {
		if (myState == States.cell) {
			state_cell();
		}
		else if (myState == States.mirror) {
			state_mirror();
		}
		else if (myState == States.sheets_0) {
			state_sheets_0();
		}
		else if (myState == States.lock_0) {
			state_lock_0();
		}
		else if (myState == States.cell_mirror) {
			state_cell_mirror();
		}
		else if (myState == States.sheets_1) {
			state_sheets_1();
		}
		else if (myState == States.lock_1) {
			state_lock_1();
		}
		else if (myState == States.freedom) {
			state_freedom();
		}
	}

	void state_cell() {
		text.text = "You have woken up in a prison cell. " +
					"You see a hand mirror, the door lock, " +
					"and bed sheets.\n\n" +
					"[M to look at the mirror, L to look at the " +
					"lock, or S to inspect the sheets]";
		if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
	}

	void state_mirror() {
		text.text = "You see a small hand mirror - could be handy.\n\n" +
			"[T to take the mirror, R to return to looking around your cell]";
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_0() {
		text.text = "You see a giant rusty lock on the door. If you could see the reverse side "+
		"of the lock, maybe you could figure out a way to free yourself.\n\n" +
			"[R to return to looking around your cell]";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_1() {
		text.text = "You look closely at the lock. Using the hand mirror you can see "+
			"that there is a simple unlock mechanism on the reverse side.\n\n" +
				"[U to unlock the door and exit the cell, R to return to looking around your cell]";
		if (Input.GetKeyDown(KeyCode.U)) {
			myState = States.freedom;
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void state_sheets_0() {
		text.text = "You see ordinary bed sheets.\n\n" +
			"[R to return to looking around your cell]";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_sheets_1() {
		text.text = "You STILL see ordinary bed sheets.\n\n" +
			"[R to stop inspecting the sheets]";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void state_cell_mirror() {
		text.text = "You're still in a prison cell. But now you have a hand mirror." +
					"You see the door lock and " +
					"bed sheets.\n\n" +
					"[L to look at the " +
					"lock or S to inspect the sheets]";

		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		}
	}
	void state_freedom() {
		text.text = "You made it to FREEDOM! " +
			"Congratulations you have won the game!!\n\n" +
				"[R to restart the game]";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
}
