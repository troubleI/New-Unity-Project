local BaseClass = BaseClass or {}

--深拷贝表
local function __deepcopy(now_table)	
	if type(now_table) ~= "table" then   --判断表中是否有表
        return now_table;
    end
    local new_table = {};
    if now_table.parent_class then
        new_table = __deepcopy(now_table.parent_class)
    end
	for k,v in pairs(now_table) do  --把旧表的key和Value赋给新表
        if k ~= "__newobj" and k ~= "New" then
            new_table[__deepcopy(k)] = __deepcopy(v)
        end
	end
	return new_table
end

--继承接口
local function __getInterface(table_obj , interface_class)
    for _, value in ipairs(interface_class) do
        for k, v in pairs(value) do
            table_obj[k] = v
        end
    end
end

--执行构造方法
local function __constructor(table_obj , table_class,...)
    if table_class.parent_class then
        __constructor(table_obj,table_class.parent_class,...)
    end
    if table_class.__newobj then
        table_class.__newobj(table_obj,...)
    end
end

--执行delete
local function __destructor(table_obj,table_class)
    if table_class.__delete then        --执行自身delete
        table_class.__delete(table_obj)
    end
    if table_class.parent_class then    --执行父类delete
        __destructor(table_obj,table_class.parent_class)
    end
    if table_class.__delete_stack then    --删除依赖对象
        for i = #table_obj.__delete_stack, 1, -1 do
            BaseClass.DeleteMe(table_class,table_obj.__delete_stack[i])
        end
        table_obj.__delete_stack = nil
    end
end

--类的继承
function Extends(self , ...)
    local class = {}
    class.parent_class = self
    class.interface_class = {...}
    return class
end

--生成对象
function BaseClass.New(self,...)
    local o = __deepcopy(self)
    __getInterface(o,self.interface_class)
    __constructor(o,self,...)
    setmetatable(o,{__newindex = function ()
        print("key is null")
    end})
    return o
end

--构造方法
function BaseClass.__newobj(self)
    
end

--删除依赖
function BaseClass.DeleteMe(self,o)
    __destructor(o,self)
    for k, _ in pairs(o) do
        o[k] = nil
    end
end

--delete方法
function BaseClass.__delete(self)
    
end

return BaseClass