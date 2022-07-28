local _Class = require("Base/base_class")
local _Singleton = require("Base/singleton_base")
local _PanelView = require("Panel/panel_view")
local _ResourceManager = require("resource_manager")

local PanelManager = PanelManager or Extends(_Singleton)

--保存所有panel
PanelManager.panel_list = {}
--配置panel
function PanelManager:AddPanel(path,name,parent_path)
    local panel_view = _Class.New(_PanelView)
    local parent_transform = _ResourceManager.FindGameObject(parent_path).transform
    panel_view:SetPanel(path,parent_transform,self)
    self.panel_list[name] = panel_view
end
--配置button
function PanelManager:AddButton(panelName,name,func,...)
    self.panel_list[panelName]:AddBtn(name,func,...)
end

function PanelManager:ClickPanel(name)
    if self.panel_list[name]:IsActive() then
        self.panel_list[name]:OnDisable()
    else
        self.panel_list[name]:OnEnable()
    end
end

function PanelManager:ClosePanel()
    for k, v in pairs(self.panel_list) do
        if k ~= "PanelMain" and v:IsActive() then
            v:OnDisable()
        end
    end
end

return PanelManager