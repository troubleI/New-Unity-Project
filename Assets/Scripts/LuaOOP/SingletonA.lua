local Singleton = require("Singleton")

SingletonA = Extends(Singleton)

SingletonA.name = "SingletonA"

function SingletonA:GetName()
    return self.name
end

return SingletonA