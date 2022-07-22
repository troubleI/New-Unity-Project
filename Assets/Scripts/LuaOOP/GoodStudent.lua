local Student = require("Student")

GoodStudent = Student:extends()
GoodStudent.name = "    GoodStudent"

function GoodStudent:GetName()
    return self.name .. "    GoodStudent"
end

GoodStudent:Init()

return GoodStudent