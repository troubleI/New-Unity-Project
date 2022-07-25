local _Student = require("student_base")
local _Interface = require("interface_base")

local GoodStudent = GoodStudent or Extends(_Student,_Interface)
GoodStudent.goodstudent_name = "    GoodStudent"

--构造方法
function GoodStudent.__newobj(o,name)
    o.goodstudent_name = name
end

--析构方法
function GoodStudent.__delete(o)
    o.goodstudent_name = nil
end

function GoodStudent:GetName()
    return self.goodstudent_name .. "    GoodStudent"
end

return GoodStudent