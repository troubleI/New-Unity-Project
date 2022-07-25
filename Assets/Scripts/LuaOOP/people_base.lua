local _Class = require("base_class")

local BasePeople = BasePeople or Extends(_Class)
BasePeople.name = "People"
BasePeople.id = 0

--构造方法
function BasePeople.__newobj(o,name,id)
    o.name = name
    o.id = id
end

--析构方法
function BasePeople.__delete(o)
    o.name = nil
    o.id = nil
end

function BasePeople:GetName()
    return self.name .. "    people"
end

function BasePeople:GetId()
    return self.id .. "    people"
end

return BasePeople