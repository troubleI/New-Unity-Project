local Singleton = require("Singleton")

SingletonA = Singleton:extends()

SingletonA.name = "SingletonA"

function SingletonA:GetName()
    return self.name
end

return SingletonA