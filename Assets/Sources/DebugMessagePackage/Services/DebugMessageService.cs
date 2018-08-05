//created by snippet - ecs_entity_services
using UnityEngine;



public class DebugMessageService {
	//other Serices include
	//public RandomService randomService = RandomService.game;
	//other Mono class include
	//public BackGroundManager bg_manager;

	public static DebugMessageService singleton = new DebugMessageService();

	Contexts _contexts;

	public void Initialize(Contexts contexts) {
		_contexts = contexts;
		//bg_manager = GameObject.Find ("BackGroundSprite");
	}

	//Note1 : 有幾個概念考量
	//entity有幾種使用方式, 一種是被create一次就需要destroy
	//一種是被create ,然後一直留著, 但裡面的 component 可能會remove掉,或更新掉(並觸發系統)
	//在這次的場景, entity是create後被留著, debugMessage component 會一直被新增->移除
	//另一個系統會佔用著一個entity , 然後在此entity 裡做事
	//但這樣 一個系統就得記住 entity , 老實說,應該就不是一個系統的精神 (系統理應不該存有資料)
	//另一個想法是 Service 提供兩種create_entity 的方式
	//一種是 create_oneshot_entity : 意即create 後,立刻被消除
	//一種是 create_entity : create後會留著,return entity refernce讓call的人記下, 但必須是call的人負責新增和消除(這也代表該人熟悉此系統...)
	//不知還有更佳的方法?

	//Note2 : entity 跟gameobject的關係
	//在ecs system下, entity 跟gameobject 是脫鉤的
	//但實際應用上,兩者仍應有連結
	//範例做法是 entity 下有 n 個 gameobject的概念->這表示系統起來時, entity 單位會先生成,然後創建gameobjects
	//gameobject 會連結它屬於哪個entity
	//但會不會有一個unity gameobject,但自身會連結n個 entity?
	//一個例子就是, 我想生成幾個 gameobject , 而每個gameobject 會有一個debugmessage entity
	//以上觀念可能錯誤
	//entity 是一個工廠中的容器, debugmessage 是容器中的component
	//以這概念來看, 系統 entity 的生成應該是由一個 initSystem 完成全部entity 的生成
	//而裡面的component可以被新增移除
	//所以回到原問題 : "會不會有一個unity gameobject,但自身會連結n個 entity?"
	//應該是不會有才對

	//生成的entity 需要被記著嗎???
	//也許 initSystem 可以記著這些entity (execute / resctive system應該禁止不能)
	//entity生成後, 內容被新增可能是由 碰撞, UI , 時間, FSM state 來觸發
	//一次性生成後消除的entity可能也是會有,所以規劃service 支援

	//A service help for create debug message entity
	public void create_oneshot_entity(string message, DEBUG_MESSAGE_GID gid) {
		var _entity = _contexts.game.CreateEntity ();
		_entity.AddDebugMessage (message);
		_entity.AddDebugMessageGroup (gid);
		_entity.isDebugMessageOneshot = true;
	}

	//TODO : how to link to gameobject ?
	public GameEntity create_entity(string message, DEBUG_MESSAGE_GID gid) {
		var _entity = _contexts.game.CreateEntity ();
		_entity.AddDebugMessage (message);
		_entity.AddDebugMessageGroup (gid);
		return _entity;

	}




	public void console_log(string log, DEBUG_MESSAGE_GID gid) {
		string _log_prefix;
		switch (gid) {
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_0:
			_log_prefix = "<color=green> [DebugMessage 0] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_1:
			_log_prefix = "<color=blue> [DebugMessage 1] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_2:
			_log_prefix = "<color=brown> [DebugMessage 2] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_3:
			_log_prefix = "<color=green> [DebugMessage 3] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_4:
			_log_prefix = "<color=gray> [DebugMessage 4] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_5:
			_log_prefix = "<color=lime> [DebugMessage 5] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_6:
			_log_prefix = "<color=navy> [DebugMessage 6] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_7:
			_log_prefix = "<color=olive> [DebugMessage 7] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_8:
			_log_prefix = "<color=orange> [DebugMessage 8] ";
			break;
		case DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_9:
			_log_prefix = "<color=purple> [DebugMessage 9] ";
			break;
		default :
			_log_prefix = "<color=yello> [DebugMessage  ] ";
			break;

		}
		Debug.Log( _log_prefix + "</color>" + log);
	}


}