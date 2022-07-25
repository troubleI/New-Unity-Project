local _Singleton = require("singleton_base")

local SingletonA = SingletonA or Extends(_Singleton)

SingletonA.name = "SingletonA"

function SingletonA:GetName()
    return self.name
end

return SingletonA