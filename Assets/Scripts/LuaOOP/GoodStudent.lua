local Student = require("Student")
local Interface = require("Interface")

GoodStudent = Extends(Student,Interface)
GoodStudent.name = "    GoodStudent"

function GoodStudent:GetName()
    return self.name .. "    GoodStudent"
end

return GoodStudent