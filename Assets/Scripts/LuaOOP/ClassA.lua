local Class = require("Class")

ClassA = Class:new()
ClassA.name = "ClassA"
function ClassA:GetName()
    return self.name
end

return ClassA