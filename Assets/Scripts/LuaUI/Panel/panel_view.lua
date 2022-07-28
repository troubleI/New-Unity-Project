local _Class = require("Base/base_class")
local _ResourceManager = require("resource_manager")

local PanelView = PanelView or Extends(_Class)

PanelView.parent_manager = false;
--存放button与其参数
PanelView.btn_list = {}
PanelView.btn_parameter = {}
--对应unity的panel
PanelView.panel_object = false
PanelView.now_panel = false
PanelView.parent_transform = false

function PanelView:SetPanel(path,transform,parent)
    local panel = _ResourceManager.Load(path)
    self.panel_object = panel
    self.parent_transform = transform
    self.parent_manager = parent
end

function PanelView:AddBtn(name,func,...)
    self.btn_list[name] = func
    self.btn_parameter[name] = ...
end

function PanelView:ClickPanel(name)
    self.parent_manager:ClickPanel(name)
end

-- 初始化button
function PanelView:InitBtn()
    --优化只查找自己下的物体
    for k, v in pairs(self.btn_list) do
        local btn = _ResourceManager.TransformFind(self.now_panel,k)
        btn:GetComponent("Button").onClick:AddListener(function ()
            self[v](self,self.btn_parameter[k])
        end)
    end
end

-- 判断对应panel是否存在
function PanelView:IsActive()
    return self.now_panel
end

function PanelView:OnEnable()
    self.now_panel = _ResourceManager.Instantiate(self.panel_object,self.parent_transform)
    self:InitBtn()
end

function PanelView:OnDisable()
    if self.now_panel then
        _ResourceManager.Destroy(self.now_panel)
        self.now_panel = false 
    end
end

return PanelView