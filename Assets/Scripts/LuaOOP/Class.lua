Class = {}
--调用父类
local function search(k,t)
    for i = 1, #t do
        local a = t[i][k]
        if a then
            return a
        end
    end
end
--类的继承
function Class.extends(...)
    local class = {}
    local parent = {...}

    setmetatable(class,{__index = function (_,k)
        return search(k,parent)
    end})

    class.__index = class

    -- function class.extends(...)
    --     local c = Class.extends(...)
    --     return c
    -- end

    return class
end

--生成对象
function Class.new(self)
    local o = self : extends()
    return o
end

return Class