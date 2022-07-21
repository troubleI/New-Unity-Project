package.path = "E:\\Project\\New-Unity-Project\\New Unity Project\\Assets\\Scripts\\LuaOOP" .."\\?.lua"
local ClassA = require("ClassA")
local SingletonA = require("SingletonA")

--Object为基类，Class为普通类，ClassA继承了Class类，Singleton为单例类，SingletonA继承单例类

local a = ClassA:new()      --实例化
print(a:GetName())          --覆写父类方法
print(a:GetId())            --使用父类方法
print(SingletonA:Instance():GetName())      --单例使用