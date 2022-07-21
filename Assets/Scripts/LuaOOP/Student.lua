local People = require("People")

Student = People:extends()
Student.name = "Student"

function Student:GetName()
    return self.name .. "student"
end

return Student