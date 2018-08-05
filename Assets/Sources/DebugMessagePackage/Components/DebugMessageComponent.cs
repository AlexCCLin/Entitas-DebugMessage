//created by snippet - ecs_icomponent
using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum DEBUG_MESSAGE_GID {
	DEBUG_MESSAGE_GID_0,
	DEBUG_MESSAGE_GID_1,
	DEBUG_MESSAGE_GID_2,
	DEBUG_MESSAGE_GID_3,
	DEBUG_MESSAGE_GID_4,
	DEBUG_MESSAGE_GID_5,
	DEBUG_MESSAGE_GID_6,
	DEBUG_MESSAGE_GID_7,
	DEBUG_MESSAGE_GID_8,
	DEBUG_MESSAGE_GID_9
}

[Game]
public sealed class DebugMessageComponent : IComponent {
	public string message;
}

[Game]
public sealed class DebugMessageMaskComponent : IComponent {
	//一個flag表示此 entity 的 message 是否遮罩,不被顯示出來 
	//如果entity 裡沒有此flag,表示可以 show出
}

[Game]
public sealed class DebugMessageOneshotComponent : IComponent {
	//一個flag表示是 oneshot entity 的 message 
	//cleanupsystem發現會把entity 消掉
}

[Game]
public sealed class DebugMessageGroupComponent : IComponent {
	//public int group_id;
	public DEBUG_MESSAGE_GID gid;
	//一個值表示此 entity 的 message 是屬於哪一個group
	//default = 0 ,表示是global debug message
}

