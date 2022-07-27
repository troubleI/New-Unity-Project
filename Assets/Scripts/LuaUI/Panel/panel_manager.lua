local _Class = require("Base/base_class")
local _Singleton = require("Base/singleton_base")
local _PanelView = require("Panel/panel_view")
local _ResourceManager = require("resource_manager")

local PanelManager = PanelManager or Extends(_Singleton)
--保存父物体，便于生成
local parent_transform = _ResourceManager.FindGameObject("Canvas").transform
--保存所有panel
PanelManager.panel_list = {}
--配置panel
function PanelManager:AddPanel(path,name)
    local panel = _ResourceManager.Load(path)
    local panel_view = _Class.New(_PanelView)
    panel_view:SetPanel(panel)
    self.panel_list[name] = panel_view
end
--监听click事件
function PanelManager:ClickPanel()
    for k, v in pairs(self.panel_list) do
        local btn = _ResourceManager.FindGameObjects(k .. "_btn")
        for i = 0, btn.Length - 1 do
            btn[i]:GetComponent("Button").onClick:AddListener(function ()
                if v:IsActive() then
                    v:OnDisable()
                else
                    v:OnEnable(parent_transform)
                end
            end)
        end
    end
end

function PanelManager:ClosePanel()
    for _, v in pairs(self.panel_list) do
        if v:IsActive() then
            v:OnDisable()
        end
    end
end

return PanelManager