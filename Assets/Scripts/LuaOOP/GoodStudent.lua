local Student = require("Student")
local Interface = require("Interface")

GoodStudent = Extends(Student,Interface)
GoodStudent.name = "    GoodStudent"

--构造方法
function GoodStudent.newObj(o,name)
    o.name = name
end

function GoodStudent:GetName()
    return self.name .. "    GoodStudent"
end

return GoodStudent