local People = require("People")

Student = Extends(People)
Student.name = "Student"

function Student.newObj(o,name)
    o.name = name
end

function Student:GetName()
    return self.name .. "    student"
end

Student:Init()

return Student