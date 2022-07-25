package.path = "E:\\Project\\New-Unity-Project\\New Unity Project\\Assets\\Scripts\\LuaOOP" .."\\?.lua"
local SingletonA = require("SingletonA")
local GoodStudent = require("GoodStudent")

--Class为基类，Singleton为单例类
local gStudent = Class.new(GoodStudent,"ss",33)   --多继承
gStudent.a = 0          --测试是否能创建字段
gStudent.Print()       --接口方法
print(gStudent:GetName())
print(gStudent:GetId())

local student1 = Class.new(Student,"aa",11)      --实例化
local student2 = Class.new(Student,"bb",22)      --多个对象测试
print(student1:GetName())          --覆写父类方法
print(student1:GetId())            --使用父类方法
print(student2:GetName())
print(student2:GetId())

print(Singleton.Instance(SingletonA).name)      --单例使用