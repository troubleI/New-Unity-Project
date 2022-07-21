Object = {}

local function search(k,t)
    for i = 1, #t do
        local a = t[i][k]
        if a then
            return a
        end
    end
end

function Object.new(...)
    local class = {}
    local parent = {...}

    setmetatable(class,{__index = function (_,k)
        return search(k,parent)
    end})

    class.__index = class

    return class
end

return Object