local _Class = require("base_class")

local BaseSingleton = BaseSingleton or Extends(_Class)

function BaseSingleton.Instance(self)
    if not self.instance then
        self.instance = _Class.New(self)
    end
    return self.instance
end

return BaseSingleton