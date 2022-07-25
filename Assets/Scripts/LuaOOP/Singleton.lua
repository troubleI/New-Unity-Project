local Class = require("Class")

Singleton = Extends(Class)

function Singleton.Instance(self)
    if not self.instance then
        self.instance = Class.new(self)
    end
    return self.instance
end

return Singleton