local _Class = require("Base/base_class")

local LuaBehaviour = LuaBehaviour or Extends(_Class)

function LuaBehaviour.__newobj(o)
    AddBehaviourList(o)
end

function LuaBehaviour.Awake()
    
end

function LuaBehaviour.Start()
    
end

function LuaBehaviour.Update()
    
end

function LuaBehaviour.FixedUpdate()
    
end

function LuaBehaviour.OnDestroy()
    
end

return LuaBehaviour