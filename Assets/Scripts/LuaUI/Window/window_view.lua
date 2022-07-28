local _Class = require("Base/base_class")
local _ResourceManager = require("resource_manager")

local WindowView = WindowView or Extends(_Class)

WindowView.parent_manager = false;
--存放button与其参数
WindowView.btn_list = {}
WindowView.btn_parameter = {}
--对应unity的panel
WindowView.window_object = false
WindowView.now_window = false
WindowView.parent_transform = false

function WindowView:SetWindow(path,transform,parent)
    local window = _ResourceManager.Load(path)
    self.window_object = window
    self.parent_transform = transform
    self.parent_manager = parent
end

function WindowView:AddBtn(name,func,...)
    self.btn_list[name] = func
    self.btn_parameter[name] = ...
end

function WindowView:ClickWindow(name)
    self.parent_manager:ClickWindow(name)
end

function WindowView:BackBtn()
    self.parent_manager:BackBtn()
end

-- 初始化button
function WindowView:InitBtn()
    --优化只查找自己下的物体
    for k, v in pairs(self.btn_list) do
        local btn = _ResourceManager.TransformFind(self.now_window,k)
        btn:GetComponent("Button").onClick:AddListener(function ()
            self[v](self,self.btn_parameter[k])
        end)
    end
end

function WindowView:OnEnable()
    self.now_window = _ResourceManager.Instantiate(self.window_object,self.parent_transform)
    self:InitBtn()
end

function WindowView:OnDisable()
    if self.now_window then
        _ResourceManager.Destroy(self.now_window)
        self.now_window = false 
    end
end

return WindowView