local _Class = require("Base/base_class")

local PanelView = PanelView or Extends(_Class)

PanelView.panel_object = false

function PanelView:SetPanel(panel)
    self.panel_object = panel
end

function PanelView:OnActive()
    if self.panel_object.activeSelf then
        self:OnDisable()
    else
        self:OnEnable()
    end
end

function PanelView:OnEnable()
    self.panel_object:SetActive(true) 
end

function PanelView:OnDisable()
    self.panel_object:SetActive(false) 
end

return PanelView