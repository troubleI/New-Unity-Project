local _Class = require("Base/base_class")
local _Singleton = require("Base/singleton_base")
local _Stack = require("Base/lua_stack")
local _WindowView = require("Window/window_view")
local _ResourceManager = require("resource_manager")
local _PanelManager = require("Panel/panel_manager")

local WindowManager = WindowManager or Extends(_Singleton)

--保存所有window
WindowManager.window_list = {}
--保存打开的window
WindowManager.window_stack = _Class.New(_Stack)
--现在正在打开的页面
WindowManager.now_window = false

--配置window
function WindowManager:AddWindow(path,name,parent_path)
    local window_view = _Class.New(_WindowView)
    local parent_transform = _ResourceManager.FindGameObject(parent_path).transform
    window_view:SetUI(path,parent_transform,self)
    self.window_list[name] = window_view
end
--配置button
function WindowManager:AddButton(windowName,name,func,...)
    self.window_list[windowName]:AddBtn(name,func,...)
end

-- 打开window
function WindowManager:ClickWindow(name)
    if self.now_window then
        self.window_stack:Push(self.now_window)
        self.window_list[self.now_window]:OnDisable()
    else
        _Singleton.Instance(_PanelManager):ClosePanel()
    end
    if name ~= "WindowMain" then
        self.now_window = name 
    end
    self.window_list[name]:OnEnable()
end

-- 返回按钮
function WindowManager:BackBtn()
    if self.window_stack.over == 0 then
        self:CloseWindow()
    else
        self.window_list[self.now_window]:OnDisable()
        self.now_window = self.window_stack:Pop()
        self.window_list[self.now_window]:OnEnable()
    end
end

function WindowManager:CloseWindow()
    self.window_stack:Clear()
    for k, v in pairs(self.window_list) do
        if k ~= "WindowMain" then
            v:OnDisable()
        end
    end
    self.now_window = false
end

return WindowManager