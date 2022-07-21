local Object = require("Object")

Class = Object:new()
Class.name = "class"
Class.id = 0
function Class:GetName()
    return self.name
end

function Class:GetId()
    return self.id
end

return Class