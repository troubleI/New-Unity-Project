local People = require("People")

Student = People:extends()
Student.name = "Student"

function Student:newObj(o,name,...)
    self.parent:newObj(o,name,...)
    o.name = name
end

function Student:GetName()
    return self.name .. "    student"
end

Student:Init()

return Student