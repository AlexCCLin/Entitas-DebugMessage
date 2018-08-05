//created by snippet - ecs_game_controller
using Entitas;
using UnityEngine;

public class DebugSystemUniTestController : MonoBehaviour {

	public DebugServices services = DebugServices.singleton;

	Systems _systems;

	void Awake() {
		var contexts = Contexts.sharedInstance;
		services.Initialize(contexts, this);
		_systems = new DebugSystems(contexts);
	}

	void Start() {
		_systems.Initialize();
	}

	void Update() {
		_systems.Execute();
		_systems.Cleanup();
	}

	void OnDestroy() {
		_systems.TearDown();
	}
}