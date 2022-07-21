local Class = require("Class")

People = Class:extends()
People.name = "People"
People.id = 0

function People.new(self,name,id)
    local o = self:extends()
    o.name = name
    o.id = id
    return o
end

function People:GetName()
    return self.name .. "people"
end

function People:GetId()
    return self.id .. "people"
end

return People