Class = {}

--深拷贝表
local function DeepCopy(table)	
	if type(table) ~= "table" then   --判断表中是否有表
        return table;
    end
    local NewTable = {};
    if table.parent then
        NewTable = DeepCopy(table.parent)
    end
	for k,v in pairs(table) do  --把旧表的key和Value赋给新表
        if k ~= "newObj" and k ~= "new" then
            NewTable[DeepCopy(k)] = DeepCopy(v)
        end
	end
	return NewTable
end

--继承接口
local function GetInterface(table , interface)
    for _, value in ipairs(interface) do
        for k, v in pairs(value) do
            table[k] = v
        end
    end
end

--执行构造方法
local function Constructor(table , parent,...)
    if parent.parent then
        Constructor(table,parent.parent,...)
    end
    if parent.newObj then
        parent.newObj(table,...)
    end
end

--类的继承
function Extends(self , ...)
    local class = {}
    class.parent = self
    class.interface = {...}
    return class
end

--生成对象
function Class.new(self,...)
    local o = DeepCopy(self)
    GetInterface(o,self.interface)
    Constructor(o,self,...)
    setmetatable(o,{__newindex = function ()
        print("key is null")
    end})
    return o
end

--构造方法
function Class.newObj(self)
    
end

return Class