Class = {}

Class.value_table = {}

--调用父类
local function search(c,k)
    return c.value_table[k]
end

--类的继承
function Class.extends(self , ...)
    local class = {}
    class.parent = self

    setmetatable(class,{__index = function (_,k)
        return search(class.parent,k)
    end})

    --class.__index = class
    -- function class.extends(...)
    --     local c = Class.extends(...)
    --     return c
    -- end

    return class
end

--生成对象
function Class.new(self,...)
    local o = {}
    setmetatable(o,{__index = self,
    __newindex = function (t,k,v)
        if self.value_table[k] ~= nil then
            rawset(t,k,v)
        else
            print("不存在这个key")
        end
    end})
    self:newObj(o,...)
    return o
end

--构造方法
function Class:newObj(o)

end

function Class.Init(self)
    for key, value in pairs(self) do
        self.value_table[key] = value
    end
end

Class:Init()

return Class