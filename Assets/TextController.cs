using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, 
		corridor_1, corridor_2, corridor_3, stairs_0, stairs_1, stairs_2, closet_door, floor, in_closet, freedom
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
		else if (myState == States.corridor_0) {
			state_corridor_0();
		}
		else if (myState == States.corridor_0) {
			state_corridor_0();
		}
		else if (myState == States.corridor_1) {
			state_corridor_1();
		}
		else if (myState == States.corridor_2) {
			state_corridor_2();
		}
		else if (myState == States.corridor_3) {
			state_corridor_3();
		}
		else if (myState == States.stairs_0) {
			state_stairs_0();
		}
		else if (myState == States.stairs_1) {
			state_stairs_1();
		}
		else if (myState == States.stairs_2) {
			state_stairs_2();
		}
		else if (myState == States.closet_door) {
			state_closet_door();
		}
		else if (myState == States.floor) {
			state_floor();
		}
		else if (myState == States.in_closet) {
			state_in_closet();
		}
		else if (myState == States.freedom) {
			state_freedom();
		}
	}

#region State handler methods
	void state_cell() {
		text.text = "You have woken up in a prison cell.\n" +
                    "You see a hand mirror, the door lock,\n" +
					"and bed sheets.\n\n" +
                    "[M to look at the mirror,\nL to look at the " +
                    "lock, or\nS to inspect the sheets]";
		if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		}
		else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
		else if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
	}

	void state_mirror() {
		text.text = "You see a small hand mirror - could be handy.\n\n" +
            "[T to take the mirror or\nR to return to looking around your cell]";
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
		else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_0() {
		text.text = "You see a giant rusty lock on the door.\nIf you could see the reverse side\n" +
		"of the lock, maybe you could figure out a way to free yourself.\n\n" +
			"[R to return to looking around your cell]";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_1() {
		text.text = "You look closely at the lock.\nUsing the hand mirror you can see\n" +
			"that there is a simple unlock mechanism on the reverse side.\n\n" +
				"[U to unlock the door and exit the cell,\nR to return to looking around your cell]";
		if (Input.GetKeyDown(KeyCode.U)) {
			myState = States.corridor_0;
		}
		else if (Input.GetKeyDown(KeyCode.R)) {
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
		text.text = "You're still in a prison cell.\nBut now you have a hand mirror.\n" +
					"You see the door lock and " +
					"bed sheets.\n\n" +
					"[L to look at the " +
                    "lock or\nS to inspect the sheets]";

		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
		else if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		}
	}

	void state_freedom() {
		text.text = "You sneak past the guards and now you're FREE!\n" +
					"Congratulations you have won the game!!\n\n" +
					"[P to play again]";
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}
	}

	void state_corridor_0() {
		text.text = "You are now in a prison corridor.\n" +
                    "You see stairs going up,\n" +
					"a closet door,\n" +
					"and a small pile of trash on the floor\n\n" +
                    "[S to go up the stairs\nC to try the closet door, or\nT to check the trash]";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_0;
		}
		else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet_door;
		}
		else if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.floor;
		}
	}

	void state_corridor_1() {
		text.text = "You are still in a prison corridor.\nBut now you have a makeshift lockpick.\n" +
					"You see stairs going up and " +
					"a closet door.\n\n" +
                    "[S to go up the stairs or\nC to open the closet with your lockpick]";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_1;
		}
		else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.in_closet;
		}
	}

	void state_corridor_2() {
		text.text = "You are still in a prison corridor.\n" +
                    "You see stairs going up and\n" +
					"an open closet with employee clothes inside.\n\n" +
                    "[S to go up the stairs or\nC to re-enter the closet]";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_2;
		}
		else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.in_closet;
		}
	}

	void state_corridor_3() {
		text.text = "You are still in a corridor.\nBut now you are wearing a disguise.\n" +
                    "You see stairs going up and\n" +
					"an open closet for uniforms.\n\n" +
					"[S to go up the stairs or\nU to take off the uniform and go back in the closet]";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.freedom;
		}
		else if (Input.GetKeyDown(KeyCode.U)) {
			myState = States.in_closet;
		}
	}

	void state_stairs_0() {
		text.text = "You start to go up the stairs.\n" +
                    "But you hear people and know that they will arrest you!\n" +
					"You have no choice but to go back down the stairs.\n\n" +
					"[D to go back down the stairs]";
		if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.corridor_0;
		}
	}

	void state_stairs_1() {
		text.text = "You again start to go up the stairs.\n" +
                    "But you still hear people and STILL know that they will arrest you!\n" +
					"You still have no choice but to go back down the stairs.\n\n" +
					"[D to go back down the stairs]";
		if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.corridor_1;
		}
	}

	void state_stairs_2() {
		text.text = "You again start to go up the stairs.\n" +
                    "But you still hear people and STILL know that they will arrest you!\n" +
                    "You need some sort of disguise....\n" +
					"You still have no choice right now but to go back.\n\n" +
					"[D to go back down the stairs]";
		if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.corridor_2;
		}
	}

	void state_closet_door() {
		text.text = "You inspect the closet.\nIt looks like it would contain employee clothing.\n" +
					"It is locked but you think the lock is pretty simple.\n\n" +
					"[C to continue looking around the corridor]";
		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.corridor_0;
		}
	}

	void state_floor() {
		text.text = "You inspect the trash.\nIt looks like there is a bobby pin you could use as a lockpick.\n\n" +
					"[C to continue looking around the corridor or\nL to take the lockpick and clean up the trash]";
		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.corridor_0;
		}
		else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.corridor_1;
		}
	}

	void state_in_closet() {
		text.text = "You are in a closet with employee clothes.\n\n" +
            "[C to continue looking around the corridor or\nD to disguise yourself with a uniform]";
		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.corridor_2;
		}
		else if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.corridor_3;
		}
	}
	
	#endregion
}
