package.path = "E:\\Project\\New-Unity-Project\\New Unity Project\\Assets\\Scripts\\LuaOOP" .."\\?.lua"
local Student = require("Student")
local SingletonA = require("SingletonA")
local GoodStudent = require("GoodStudent")

--Class为基类，Singleton为单例类
local gStudent = GoodStudent:new("ss",33)   --多继承
print(gStudent:GetName())
print(gStudent:GetId())

local student1 = Student:new("aa",11)      --实例化
local student2 = Student:new("bb",22)      --多个对象测试
print(student1:GetName())          --覆写父类方法
print(student1:GetId())            --使用父类方法
print(student2:GetName())          
print(student2:GetId())            

print(SingletonA:Instance().name)      --单例使用