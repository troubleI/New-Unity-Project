local _Class = require("Base/base_class")
local _ResourceManager = require("resource_manager")

local PanelView = PanelView or Extends(_Class)

PanelView.panel_object = false
PanelView.now_panel = false

function PanelView:SetPanel(panel)
    self.panel_object = panel
end

function PanelView:IsActive()
    return self.now_panel
end

function PanelView:OnEnable(transform)
    self.now_panel = _ResourceManager.Instantiate(self.panel_object,transform)
end

function PanelView:OnDisable()
    _ResourceManager.Destroy(self.now_panel)
    self.now_panel = false
end

return PanelView