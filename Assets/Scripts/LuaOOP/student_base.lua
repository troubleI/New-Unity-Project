local _People = require("people_base")

local BaseStudent = BaseStudent or Extends(_People)
BaseStudent.student_name = "Student"
BaseStudent.good_list = {}
BaseStudent.__delete_stack = {}

--构造方法
function BaseStudent.__newobj(o,name)
    o.student_name = name
end

--析构方法
function BaseStudent.__delete(o)
    o.student_name = nil
    o.good_list = nil
end

function BaseStudent:GetName()
    return self.student_name .. "    student"
end

function BaseStudent:AddList(obj)
    table.insert(self.good_list,obj)
    table.insert(self.__delete_stack,obj)
end

return BaseStudent