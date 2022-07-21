local Singleton = require("Singleton")

SingletonA = Singleton:new()

SingletonA.name = "SingletonA"

function SingletonA:GetName()
    return self.name
end

return SingletonA