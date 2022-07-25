local Class = require("Class")

People = Extends(Class)
People.name = "People"
People.id = 0

--构造方法
function People.newObj(o,name,id)
    o.name = name
    o.id = id
end

function People:GetName()
    return self.name .. "    people"
end

function People:GetId()
    return self.id .. "    people"
end

return People