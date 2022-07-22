local Singleton = require("Singleton")

SingletonA = Singleton:extends()

SingletonA.name = "SingletonA"

function SingletonA:GetName()
    return self.name
end

for key, value in pairs(SingletonA) do
    SingletonA.value_table[key] = value
end

SingletonA:Init()

return SingletonA