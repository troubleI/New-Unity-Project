local _Class = require("Base/base_class")

local Stack = Stack or Extends(_Class)

Stack.over = 0
Stack.list = {}

function Stack:Push(v)
    self.over = self.over + 1
    self.list[self.over] = v
end

function Stack:Pop()
    if self.over ~= 0 then
        self.over = self.over - 1
        return self.list[self.over + 1]
    end
end

function Stack:Clear()
    self.over = 0
end

return Stack