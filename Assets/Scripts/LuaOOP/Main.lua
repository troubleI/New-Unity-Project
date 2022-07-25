package.path = "E:\\Project\\New-Unity-Project\\New Unity Project\\Assets\\Scripts\\LuaOOP" .."\\?.lua"
--Class为基类，Singleton为单例类
local _Class = require("base_class")
local _Singleton = require("singleton_base")
local _SingletonA = require("singleton_a")
local _Student = require("student_base")
local _GoodStudent = require("student_good")

print(_Singleton.Instance(_SingletonA):GetName())      --单例使用

local gStudent = _Class.New(_GoodStudent,"ss",33)   --多继承
gStudent.a = 0          --测试是否能创建字段
gStudent.__print()       --接口方法
print(gStudent:GetName())
print(gStudent:GetId())

local student1 = _Class.New(_Student,"aa",11)      --实例化
local student2 = _Class.New(_Student,"bb",22)      --多个对象测试
print(student1:GetName())          --覆写父类方法
print(student1:GetId())            --使用父类方法
print(student2:GetName())
print(student2:GetId())

student1:AddList(gStudent)          --测试析构
_Class.DeleteMe(_Student,student1)
print(gStudent.name)