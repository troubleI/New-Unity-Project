local Class = require("Class")

People = Class:extends()
People.name = "People"
People.id = 0

function People:newObj(o,name,id)
    self.parent:newObj(o)
    o.id = id
end

function People:GetName()
    return self.name .. "    people"
end

function People:GetId()
    return self.id .. "    people"
end

People:Init()

return People