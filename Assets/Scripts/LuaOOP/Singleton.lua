local Class = require("Class")

Singleton = Class:extends()

function Singleton . Instance(self)
    if not self.instance then
        self.instance = self:new()
    end
    return self.instance
end

Singleton:Init()

return Singleton