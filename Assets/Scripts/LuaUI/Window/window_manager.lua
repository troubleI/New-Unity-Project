local _Class = require("Base/base_class")
local _Stack = require("Base/lua_stack")
local _WindowView = require("Window/window_view")
local _ResourceManager = require("resource_manager")

local WindowManager = WindowManager or Extends(_Class)
--保存父物体，便于生成
local parent_transform = _ResourceManager.FindGameObject("WindowManager").transform
--返回按钮
WindowManager.back_btn = false
--保存所有window
WindowManager.window_list = {}
--保存打开的window
WindowManager.window_stack = _Class.New(_Stack)
--现在正在打开的页面
WindowManager.now_window = false

--配置window
function WindowManager:AddWindow(path,name)
    local window = _ResourceManager.Load(path,parent_transform)
    local window_view = _Class.New(_WindowView)
    window_view:SetWindow(window)
    self.window_list[name] = window_view
end

--监听返回按钮
function WindowManager:ClickBackBtn(path)
    self.back_btn = _ResourceManager.Load(path,parent_transform)
    self.back_btn:GetComponent("Button").onClick:AddListener(function ()
        if self.window_stack.over == 0 then
            self:CloseWindow()
        else
            self.window_list[self.now_window]:OnDisable()
            self.now_window = self.window_stack:Pop()
            self.window_list[self.now_window]:OnEnable()
        end
    end)
end

--监听click事件
function WindowManager:ClickWindow()
    for k, v in pairs(self.window_list) do
        local btn = _ResourceManager.FindGameObjects(k .. "_btn")
        for i = 0, btn.Length - 1 do
            btn[i]:GetComponent("Button").onClick:AddListener(function ()
                self.back_btn:SetActive(true)
                if self.now_window then
                    self.window_stack:Push(self.now_window)
                    self.window_list[self.now_window]:OnDisable()
                end
                self.now_window = k
                v:OnEnable()
            end)
        end
    end
end

function WindowManager:CloseWindow()
    self.window_stack:Clear()
    self.back_btn:SetActive(false)
    for _, v in pairs(self.window_list) do
        v:OnDisable()
    end
    self.now_window = false
end

return WindowManager