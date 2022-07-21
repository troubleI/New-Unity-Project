package.path = "E:\\Project\\New-Unity-Project\\New Unity Project\\Assets\\Scripts\\LuaOOP" .."\\?.lua"
local Student = require("Student")
local SingletonA = require("SingletonA")

--Class为基类，Singleton为单例类

local student1 = Student:new("aa",11)      --实例化
local student2 = Student:new("bb",22)      --实例化
print(student1:GetName())          --覆写父类方法
print(student1:GetId())            --使用父类方法
print(student2:GetName())          --覆写父类方法
print(student2:GetId())            --使用父类方法

print(SingletonA:Instance().name)      --单例使用