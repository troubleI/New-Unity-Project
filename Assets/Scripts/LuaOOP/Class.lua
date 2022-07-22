Class = {}

Class.Constructor = {}

--深拷贝表
local function DeepCopy(table,is_Class)	
	if type(table) ~= "table" then   --判断表中是否有表
        return table;
    end
    local NewTable = {};
	for k,v in pairs(table) do  --把旧表的key和Value赋给新表
        if k ~= "newObj" then
            if k ~= "new" and k ~= "Constructor" or is_Class then
                NewTable[DeepCopy(k)] = DeepCopy(v)
            end
        end
	end
	return NewTable
end

--继承接口
local function GetInterface(table , ...)
    local interface = {...}
    for _, value in ipairs(interface) do
        for k, v in pairs(value) do
            table[k] = v
        end
    end
end

--类的继承
function Extends(self , ...)
    local class = DeepCopy(self,true)
    GetInterface(class,...)
    return class
end

--生成对象
function Class.new(self,...)
    local o = DeepCopy(self,false)
    setmetatable(o,{__newindex = function ()
        print("key is null")
    end})
    for _, value in ipairs(self.Constructor) do
        value(o,...)
    end
    return o
end

--构造方法
function Class.newObj(self)
    
end

--保存构造方法
function Class.Init(self)
    if self.newObj ~= nil then
        self.Constructor[#self.Constructor+1] = self.newObj
    end
end

Class:Init()

return Class