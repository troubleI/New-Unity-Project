local __behaviourlist = {awake = {},start = {},update = {},fixedUpdate = {},onDestroy = {}}

local function __executelist(t)
    for _, v in ipairs(t) do
        v()
    end
end
--模仿unity生命周期
function Awake()
    __executelist(__behaviourlist.awake)
end

function Start()
    __executelist(__behaviourlist.start)
end

function Updete()
    __executelist(__behaviourlist.update)
end

function FixedUpdate()
    __executelist(__behaviourlist.fixedUpdate)
end

function OnDestroy()
    __executelist(__behaviourlist.onDestroy)
    for k, _ in ipairs(__behaviourlist) do
        __behaviourlist[k] = nil
    end
    __behaviourlist = nil
end

function AddBehaviourList(t)
    for k, _ in pairs(__behaviourlist) do
        if t[k] then
            table.insert(__behaviourlist[k],t[k])
        end
    end
end

require("lua_manager")