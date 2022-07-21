local Object = require("Object")

Singleton = Object:new()

function Singleton : Instance()
    if not self.instance then
        self.instance = self
    end
    return self.instance
end

return Singleton